using Application.DTOs;
using Application.Requests.Payments;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Payments
{
    public class RevenueStatisticHandler : IRequestHandler<RevenueStatisticRequest, Response<RevenueStatisticDto>>
    {
        private readonly IPaymentRepo _paymentRepo;

        public RevenueStatisticHandler(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public async Task<Response<RevenueStatisticDto>> Handle(RevenueStatisticRequest request,CancellationToken cancellationToken)
        {
            // ⚠️ Sau này nên Include Order + OrderItems
            var payments = await _paymentRepo.GetAsync(
                include: q => q.Include(p => p.Order)
                               .Include(p => p.Order.Items)
                );

            // ===== ORDERS =====
            var totalOrderCount = payments
                .Select(x => x.OrderId)
                .Distinct()
                .Count();

            var paidPayments = payments
                .Where(x => x.PaymentStatus == PaymentStatus.Paid.ToString())
                .ToList();

            var refundedPayments = payments
                .Where(x => x.PaymentStatus == PaymentStatus.Refunded.ToString())
                .ToList();

            // ===== REVENUE =====
            var grossRevenue = payments.Sum(x => x.Amount);
            var paidRevenue = paidPayments.Sum(x => x.Amount);
            var refundedAmount = refundedPayments.Sum(x => x.Amount);

            // ===== PRODUCTS SOLD =====
            var totalProductSold = paidPayments
                .Where(x => x.Order != null)
                .SelectMany(x => x.Order.Items)
                .Sum(i => i.Quantity);

            // ===== REVENUE BY PAYMENT METHOD =====
            var revenueByPaymentMethod = paidPayments
                .GroupBy(x => x.PaymentMethod)
                .Select(g => new RevenueByPaymentMethodDto
                {
                    PaymentMethod = g.Key,
                    TotalRevenue = g.Sum(x => x.Amount),
                    OrderCount = g.Select(x => x.OrderId).Distinct().Count()
                })
                .ToList();

            // ===== REVENUE BY DATE (DAY) =====
            var revenueByPeriod = paidPayments
                .GroupBy(x => x.PaidAt)
                .Select(g => new RevenueByPeriodDto
                {
                    Period = (DateTime)g.Key,
                    TotalRevenue = g.Sum(x => x.Amount),
                    OrderCount = g.Select(x => x.OrderId).Distinct().Count()
                })
                .OrderBy(x => x.Period)
                .ToList();

            var report = new RevenueStatisticDto
            {
                // Orders
                TotalOrderCount = totalOrderCount,
                PaidOrderCount = paidPayments
                    .Select(x => x.OrderId)
                    .Distinct()
                    .Count(),
                RefundedOrderCount = refundedPayments
                    .Select(x => x.OrderId)
                    .Distinct()
                    .Count(),

                // Revenue
                GrossRevenue = grossRevenue,
                PaidRevenue = paidRevenue,
                RefundedAmount = refundedAmount,

                // Products
                TotalProductSold = totalProductSold,

                // Analytics
                RevenueByPaymentMethod = revenueByPaymentMethod,
                RevenueByPeriod = revenueByPeriod
            };

            return Response<RevenueStatisticDto>
                .Create(StatusCode.Ok, CommonMessage.GetSuccess, report);
        }
    }
}

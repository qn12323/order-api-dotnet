using Application.Requests.Payments;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Payments
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentRequest, Response<object>>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IPaymentRepo _paymentRepo;
        public CreatePaymentHandler(IOrderRepo orderRepo, IPaymentRepo paymentRepo)
        {
            _orderRepo = orderRepo;
            _paymentRepo = paymentRepo;
        }
        public async Task<Response<object>> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.OrderId);

            if (order == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            var payment = new Payment
            {
                OrderId = request.OrderId,
                PaymentMethod = request.PaymentMethod,
                PaymentStatus = PaymentStatus.Unpaid.ToString(),
                Amount = order.TotalAmount, // free ship
            };

            await _paymentRepo.Add(payment);

            return Response<object>.Create(StatusCode.Created, string.Format(CommonMessage.AddSuccess, ""));
        }
    }
}

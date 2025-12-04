using Application.Requests.Payments;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Payments
{
    public class GetListPaymentHandler : IRequestHandler<GetListPaymentRequest, Response<List<Payment>>>
    {
        private readonly IPaymentRepo _paymentRepo;
        public GetListPaymentHandler(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }
        public async Task<Response<List<Payment>>> Handle(GetListPaymentRequest request, CancellationToken cancellationToken)
        {
            var payments = (List<Payment>)await _paymentRepo.GetAsync(
                include: q => q.Include(o => o.Order)
                               .Include(o => o.Order.User)
                               .Include(o => o.Order.Items)
            );

            if(payments.Count == 0)
            {
                return Response<List<Payment>>.Create(StatusCode.NotFound, CommonMessage.NoDataFound);
            }

            return Response<List<Payment>>.Create(StatusCode.Ok, CommonMessage.GetSuccess, payments);
        }
    }
}

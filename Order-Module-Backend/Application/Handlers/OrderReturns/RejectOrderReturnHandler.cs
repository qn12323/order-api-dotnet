using Application.Requests.OrderReturns;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.OrderReturns
{
    public class RejectOrderReturnHandler : IRequestHandler<RejectOrderReturnRequest, Response<object>>
    {
        private readonly IOrderReturnRepo _orderReturnRepo;
        public RejectOrderReturnHandler(IOrderReturnRepo orderReturnRepo)
        {
            _orderReturnRepo = orderReturnRepo;
        }
        public async Task<Response<object>> Handle(RejectOrderReturnRequest request, CancellationToken cancellationToken)
        {
            var orderReturn = await _orderReturnRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.OrderId == request.OrderId,
                o => o.Status == OrderReturnStatus.Pending.ToString()
            );

            if (orderReturn == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            orderReturn.Status = OrderReturnStatus.Rejected.ToString();
            orderReturn.UpdatedAt = DateTime.UtcNow;
            await _orderReturnRepo.Update(orderReturn);

            return Response<object>.Create(StatusCode.Ok, string.Format(CommonMessage.UpdateSuccess, ""));
        }
    }
}

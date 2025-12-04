using Application.Requests.OrderReturns;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.OrderReturns
{
    public class ApproveOrderReturnHandler : IRequestHandler<ApproveOrderReturnRequest, Response<object>>
    {
        private readonly IOrderReturnRepo _orderReturnRepo;
        public ApproveOrderReturnHandler(IOrderReturnRepo orderReturnRepo)
        {
            _orderReturnRepo = orderReturnRepo;
        }
        public async Task<Response<object>> Handle(ApproveOrderReturnRequest request, CancellationToken cancellationToken)
        {
            var orderReturn = await _orderReturnRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.OrderId == request.OrderId,
                o => o.Status == OrderReturnStatus.Pending.ToString()
            );

            if (orderReturn == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            orderReturn.Status = OrderReturnStatus.Approved.ToString();
            await _orderReturnRepo.Update(orderReturn);

            return Response<object>.Create(StatusCode.Ok, string.Format(CommonMessage.UpdateSuccess, ""));
        }
    }
}

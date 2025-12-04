using Application.Requests.OrderReturns;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.OrderReturns
{
    public class CompleteOrderReturnHandler : IRequestHandler<CompleteOrderReturnRequest, Response<object>>
    {
        private readonly IOrderReturnRepo _orderReturnRepo;
        private readonly IOrderRepo _orderRepo;
        public CompleteOrderReturnHandler(IOrderReturnRepo orderReturnRepo, IOrderRepo orderRepo)
        {
            _orderReturnRepo = orderReturnRepo;
            _orderRepo = orderRepo;
        }
        public async Task<Response<object>> Handle(CompleteOrderReturnRequest request, CancellationToken cancellationToken)
        {
            var orderReturn = await _orderReturnRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.OrderId == request.OrderId,
                o => o.Status == OrderReturnStatus.Approved.ToString(),
                o => o.Order
            );

            if (orderReturn == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            var order = orderReturn.Order;

            orderReturn.Status = OrderReturnStatus.Completed.ToString();

            order.OrderStatus = OrderStatus.Returned.ToString();
            orderReturn.UpdatedAt = DateTime.UtcNow;

            await _orderReturnRepo.Update(orderReturn);
            await _orderRepo.Update(order);

            return Response<object>.Create(StatusCode.Ok, string.Format(CommonMessage.UpdateSuccess, ""));        
        }
    }
}

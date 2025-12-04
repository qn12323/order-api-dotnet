using Application.Requests.Orders;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Orders
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderRequest, Response<object>>
    {
        private readonly IOrderRepo _orderRepo;
        public CancelOrderHandler(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<Response<object>> Handle(CancelOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.Id);

            if (order == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            order.OrderStatus = OrderStatus.Cancelled.ToString();
            order.UpdatedAt = DateTime.UtcNow;
            await _orderRepo.Update(order);

            return Response<object>.Create(StatusCode.Ok, string.Format(CommonMessage.UpdateSuccess, ""));
        }
    }
}

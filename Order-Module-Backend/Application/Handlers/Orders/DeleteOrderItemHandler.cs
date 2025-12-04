using Application.Requests.Orders;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Orders
{
    public class DeleteOrderIteHandler : IRequestHandler<DeleteOrderItemRequest, Response<object>>
    {
        private readonly IOrderItemRepo _orderItemRepo;
        private readonly IOrderRepo _orderRepo;
        public DeleteOrderIteHandler(IOrderItemRepo orderItemRepo, IOrderRepo orderRepo)
        {
            _orderItemRepo = orderItemRepo;
            _orderRepo = orderRepo;
        }

        public async Task<Response<object>> Handle(DeleteOrderItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _orderItemRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.Order
            );

            if (item == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            var order = item.Order;

            await _orderItemRepo.Delete(item);

            var remainItems = await _orderItemRepo.GetAsync(i => i.OrderId == order.Id);
            order.TotalAmount = remainItems.Sum(i => i.TotalPrice);

            await _orderRepo.Update(order);

            return Response<object>.Create(StatusCode.Ok, string.Format(CommonMessage.DeleteSuccess, ""));
        }
    }
}

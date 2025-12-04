using Application.Requests.Orders;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Orders
{
    public class UpdateOrderItemHandler : IRequestHandler<UpdateOrderItemRequest, Response<object>>
    {
        private readonly IOrderItemRepo _orderItemRepo;
        private readonly IOrderRepo _orderRepo;
        public UpdateOrderItemHandler(IOrderItemRepo orderItemRepo, IOrderRepo orderRepo)
        {
            _orderItemRepo = orderItemRepo;
            _orderRepo = orderRepo;
        }

        public async Task<Response<object>> Handle(UpdateOrderItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _orderItemRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.Product,
                o => o.Order,
                o => o.Order.Items
            );

            if (item == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            #region Check Quantity
            if (request.Quantity <= 0 || request.Quantity > item.Product.QuantityStock)
                return Response<object>.Create(StatusCode.BadRequest, string.Format(CommonMessage.InvalidData, ""));
            #endregion

            item.Quantity = request.Quantity;
            item.TotalPrice = item.UnitPrice * request.Quantity;

            item.Order.TotalAmount = item.Order.Items.Sum(i => i.TotalPrice);

            await _orderItemRepo.Update(item);
            await _orderRepo.Update(item.Order);

            return Response<object>.Create(StatusCode.Ok, string.Format(CommonMessage.UpdateSuccess, ""));
        }
    }
}

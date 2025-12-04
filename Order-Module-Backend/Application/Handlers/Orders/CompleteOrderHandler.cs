using Application.Requests.Orders;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Orders
{
    public class CompleteOrderHandler : IRequestHandler<CompleteOrderRequest, Response<object>>
    {
        private readonly IOrderRepo _orderRepo;
        public CompleteOrderHandler(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<Response<object>> Handle(CompleteOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.Id);

            if (order == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            order.OrderStatus = OrderStatus.Completed.ToString();
            await _orderRepo.Update(order);

            return Response<object>.Create(StatusCode.Ok, string.Format(CommonMessage.UpdateSuccess, ""));
        }
    }
}

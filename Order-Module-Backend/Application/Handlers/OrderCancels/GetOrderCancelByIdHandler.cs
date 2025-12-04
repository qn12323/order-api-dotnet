using Application.Requests.OrderCancels;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.OrderCancels
{
    public class GetOrderCancelByIdHandler : IRequestHandler<GetOrderCancelByIdRequest, Response<OrderCancellation>>
    {
        private readonly IOrderCancelRepo _orderCancelRepo;
        public GetOrderCancelByIdHandler(IOrderCancelRepo orderCancelRepo)
        {
            _orderCancelRepo = orderCancelRepo;
        }

        public async Task<Response<OrderCancellation>> Handle(GetOrderCancelByIdRequest request, CancellationToken cancellationToken)
        {
            var orderCancel = await _orderCancelRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.Order,
                o => o.Order.Items
            );

            if (orderCancel == null)
                return Response<OrderCancellation>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            return Response<OrderCancellation>.Create(StatusCode.Ok, CommonMessage.GetSuccess, orderCancel);
        }
    }
}

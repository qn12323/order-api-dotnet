using Application.Requests.OrderCancels;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.OrderCancels
{
    public class CreateOrderCancelHandler : IRequestHandler<CreateOrderCancelRequest, Response<object>>
    { 
        private readonly IOrderCancelRepo _orderCancelRepo;
        private readonly IOrderRepo _orderRepo;
        public CreateOrderCancelHandler(IOrderCancelRepo orderCancelRepo, IOrderRepo orderRepo)
        {
            _orderCancelRepo = orderCancelRepo;
            _orderRepo = orderRepo;
        }
        public async Task<Response<object>> Handle(CreateOrderCancelRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.OrderId);

            if (order == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            if (request.Reason.Length >= 499)
                return Response<object>.Create(StatusCode.BadRequest, string.Format(CommonMessage.InvalidData, ""));

            var orderCancel = new OrderCancellation
            {
                OrderId = request.OrderId,
                CancelledBy = request.CancelledBy,
                Reason = request.Reason,
                CancelledAt = DateTime.UtcNow,
            };

            await _orderCancelRepo.Add(orderCancel);

            return Response<object>.Create(StatusCode.Created, string.Format(CommonMessage.AddSuccess, ""));
        }
    }
}

using Application.Requests.OrderReturns;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.OrderReturns
{
    public class CreateOrderReturnHandler : IRequestHandler<CreateOrderReturnRequest, Response<object>>
    {
        private readonly IOrderReturnRepo _orderReturnRepo;
        private readonly IOrderRepo _orderRepo;
        public CreateOrderReturnHandler(IOrderReturnRepo orderReturnRepo, IOrderRepo orderRepo)
        {
            _orderReturnRepo = orderReturnRepo;
            _orderRepo = orderRepo;
        }

        public async Task<Response<object>> Handle(CreateOrderReturnRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.OrderId);

            if(order == null)
                return Response<object>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            if(request.Reason.Length >= 499)
                return Response<object>.Create(StatusCode.BadRequest, string.Format(CommonMessage.InvalidData, ""));

            var orderReturn = new OrderReturn
            {
                OrderId = request.OrderId,
                Reason = request.Reason,
                Status = OrderReturnStatus.Pending.ToString(),
                CreatedAt = DateTime.UtcNow,
            };

            await _orderReturnRepo.Add(orderReturn);

            return Response<object>.Create(StatusCode.Created, string.Format(CommonMessage.AddSuccess, ""));
        }
    }
}

using Application.Requests.OrderReturns;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.OrderReturns
{
    public class GetOrderReturnByIdHandler : IRequestHandler<GetOrderReturnByIdRequest, Response<OrderReturn>>
    {
        private readonly IOrderReturnRepo _orderReturnRepo;
        public GetOrderReturnByIdHandler(IOrderReturnRepo orderReturn)
        {
            _orderReturnRepo = orderReturn;
        }
        public async Task<Response<OrderReturn>> Handle(GetOrderReturnByIdRequest request, CancellationToken cancellationToken)
        {
            var orderReturn = await _orderReturnRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.Order,
                o => o.Order.Items
            );

            if(orderReturn == null)
                return Response<OrderReturn>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            return Response<OrderReturn>.Create(StatusCode.Ok, CommonMessage.GetSuccess, orderReturn);
        }
    }
}

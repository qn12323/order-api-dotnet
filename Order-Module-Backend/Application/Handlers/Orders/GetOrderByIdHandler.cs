using Application.Requests.Orders;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Orders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, Response<Order>>
    {
        private readonly IOrderRepo _orderRepo;
        public GetOrderByIdHandler(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task<Response<Order>> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetSingleAsync(
                o => o.Id == request.Id,
                o => o.User,
                o => o.Items
            );

            if (order == null)
                return Response<Order>.Create(StatusCode.NotFound, string.Format(CommonMessage.NotFound, ""));

            return Response<Order>.Create(StatusCode.Ok, CommonMessage.GetSuccess, order);
        }
    }
}

using Application.Requests.OrderCancels;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.OrderCancels
{
    public class GetOrderCancelHandler : IRequestHandler<GetOrderCancelRequest, Response<List<OrderCancellation>>>
    {
        private readonly IOrderCancelRepo _orderCancelRepo;
        public GetOrderCancelHandler(IOrderCancelRepo orderCancelRepo)
        {
            _orderCancelRepo = orderCancelRepo;
        }
        public async Task<Response<List<OrderCancellation>>> Handle(GetOrderCancelRequest request, CancellationToken cancellationToken)
        {
            var orderCancels = new List<OrderCancellation>();

            if (request.UserId != null)
            {
                orderCancels = (List<OrderCancellation>)await _orderCancelRepo.GetAsync(
                    predicate: o => o.Order.User.Id == request.UserId,
                    include: q => q.Include(o => o.Order)
                                   .Include(o => o.Order.User)
                                   .Include(o => o.Order.Items)
                );
            }
            else
            {
                orderCancels = (List<OrderCancellation>)await _orderCancelRepo.GetAsync(
                    include: q => q.Include(o => o.Order)
                                   .Include(o => o.Order.User)
                                   .Include(o => o.Order.Items)
                );
            }

            return Response<List<OrderCancellation>>.Create(StatusCode.Ok, string.Format(CommonMessage.GetSuccess, ""), orderCancels);
        }
    }
}

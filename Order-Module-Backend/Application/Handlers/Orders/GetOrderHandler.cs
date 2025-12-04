using Application.Requests.Orders;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Orders
{
    public class GetOrderHandler : IRequestHandler<GetOrderRequest, Response<List<Order>>>
    {
        private readonly IOrderRepo _orderRepo;
        public GetOrderHandler(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<Response<List<Order>>> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var orders = new List<Order>();
            if (request.UserId != null)
            {
                orders = (List<Order>)await _orderRepo.GetAsync(
                    predicate: o => o.UserId == request.UserId,
                    include: q => q.Include(o => o.User)
                                   .Include(o => o.Items)
                );
            }
            else
            {
                orders = (List<Order>)await _orderRepo.GetAsync(
                    include: q => q.Include(o => o.User)
                                   .Include(o => o.Items)
                );
            }

            return Response<List<Order>>.Create(StatusCode.Ok, string.Format(CommonMessage.GetSuccess, ""), orders);
        }
    }
}

using Application.Requests.OrderReturns;
using Domain.Constants.Status;
using Domain.Definitions.Messages;
using Domain.Definitions.Results;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.OrderReturns
{
    public class GetOrderReturnHandler : IRequestHandler<GetOrderReturnRequest, Response<List<OrderReturn>>>
    {
        private readonly IOrderReturnRepo _orderReturnRepo;
        public GetOrderReturnHandler(IOrderReturnRepo orderReturnRepo)
        {
            _orderReturnRepo = orderReturnRepo;
        }
        public async Task<Response<List<OrderReturn>>> Handle(GetOrderReturnRequest request, CancellationToken cancellationToken)
        {
            var orderReturns = new List<OrderReturn>();

            if (request.UserId != null)
            {
                orderReturns = (List<OrderReturn>)await _orderReturnRepo.GetAsync(
                    predicate: o => o.Order.User.Id == request.UserId,
                    include: q => q.Include(o => o.Order)
                                   .Include(o => o.Order.User)
                                   .Include(o => o.Order.Items)
                );
            }
            else
            {
                orderReturns = (List<OrderReturn>)await _orderReturnRepo.GetAsync(
                    include: q => q.Include(o => o.Order)
                                   .Include(o => o.Order.User)
                                   .Include(o => o.Order.Items)
                );
            }

            if (orderReturns.Count == 0)
            {
                return Response<List<OrderReturn>>.Create(StatusCode.NotFound, CommonMessage.NoDataFound);
            }

            return Response<List<OrderReturn>>.Create(StatusCode.Ok, string.Format(CommonMessage.GetSuccess, ""), orderReturns);
        }
    }
}

using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.OrderReturns
{
    public class GetOrderReturnRequest : IRequest<Response<List<OrderReturn>>>
    {
        public Guid? UserId { get; set; }
    }
}

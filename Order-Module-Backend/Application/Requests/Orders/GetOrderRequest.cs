using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Orders
{
    public class GetOrderRequest : IRequest<Response<List<Order>>>
    {
        public Guid? UserId { get; set; }
    }
}

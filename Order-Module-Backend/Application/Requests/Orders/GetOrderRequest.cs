using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Orders
{
    public class GetOrderRequest : IRequest<Response<List<Order>>>
    {
        public int? UserId { get; set; }
    }
}

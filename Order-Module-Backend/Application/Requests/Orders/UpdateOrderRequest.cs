using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.Orders
{
    public class UpdateOrderRequest : IRequest<Response<object>>
    {
        public string Id { get; set; }
        public string OrderStatus { get; set; }
    }
}

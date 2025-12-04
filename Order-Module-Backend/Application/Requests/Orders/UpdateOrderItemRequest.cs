using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.Orders
{
    public class UpdateOrderItemRequest : IRequest<Response<object>>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}

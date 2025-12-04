using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.Orders
{
    public class DeleteOrderItemRequest : IRequest<Response<object>>
    {
        public int Id { get; set; }
    }
}

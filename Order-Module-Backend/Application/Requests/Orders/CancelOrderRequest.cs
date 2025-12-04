using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.Orders
{
    public class CancelOrderRequest : IRequest<Response<object>>
    {
        public string Id { get; set; }
    }
}

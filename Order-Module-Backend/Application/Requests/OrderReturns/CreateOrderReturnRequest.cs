using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.OrderReturns
{
    public class CreateOrderReturnRequest : IRequest<Response<object>>
    {
        public string OrderId { get; set; }
        public string Reason { get; set; } 
    }
}

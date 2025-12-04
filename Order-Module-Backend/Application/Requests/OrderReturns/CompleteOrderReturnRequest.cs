using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.OrderReturns
{
    public class CompleteOrderReturnRequest : IRequest<Response<object>>
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
    }
}

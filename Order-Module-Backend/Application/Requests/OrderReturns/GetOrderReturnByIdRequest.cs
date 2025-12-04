using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.OrderReturns
{
    public class GetOrderReturnByIdRequest : IRequest<Response<OrderReturn>>
    {
        public int Id { get; set; }
    }
}

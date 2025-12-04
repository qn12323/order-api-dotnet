using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.OrderCancels
{
    public class GetOrderCancelByIdRequest : IRequest<Response<OrderCancellation>>
    {
        public int Id { get; set; }
    }
}

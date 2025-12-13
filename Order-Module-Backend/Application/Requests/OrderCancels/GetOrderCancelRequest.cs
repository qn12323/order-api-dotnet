using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.OrderCancels
{
    public class GetOrderCancelRequest : IRequest<Response<List<OrderCancellation>>>
    {
        public int? UserId { get; set; }
    }
}

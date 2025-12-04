using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Orders
{
    public class GetOrderByIdRequest : IRequest<Response<Order>>
    {
        public string Id { get; set; }
    }
}

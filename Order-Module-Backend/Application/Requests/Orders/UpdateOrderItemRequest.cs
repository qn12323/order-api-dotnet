using Domain.Definitions.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Requests.Orders
{
    public class UpdateOrderItemRequest : IRequest<Response<object>>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}

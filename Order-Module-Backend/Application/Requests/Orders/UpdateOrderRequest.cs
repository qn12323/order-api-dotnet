using Domain.Definitions.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Requests.Orders
{
    public class UpdateOrderRequest : IRequest<Response<object>>
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string OrderStatus { get; set; }
    }
}

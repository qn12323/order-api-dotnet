using Domain.Definitions.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Requests.OrderCancels
{
    public class CreateOrderCancelRequest : IRequest<Response<object>>
    {
        public string OrderId { get; set; }
        [JsonIgnore]
        public int CancelledBy { get; set; } = 1;// by user
        public string Reason { get; set; }
    }
}

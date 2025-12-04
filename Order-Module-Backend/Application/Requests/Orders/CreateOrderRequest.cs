using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.Orders
{
    public class CreateOrderRequest : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public List<CreateOrderItemRequest> OrderItems { get; set; }
        public string PaymentStatus { get; set; }
        public string ShippingAddress { get; set; }
    }
}

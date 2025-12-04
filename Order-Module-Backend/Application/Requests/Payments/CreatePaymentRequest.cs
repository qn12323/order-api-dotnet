using method = Domain.Constants.Methods.PaymentMethod;
using Domain.Definitions.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Requests.Payments
{
    public class CreatePaymentRequest : IRequest<Response<object>>
    {
        public string OrderId { get; set; }
        [JsonIgnore]
        public string PaymentMethod { get; set; } = method.COD.ToString(); // default
    }
}

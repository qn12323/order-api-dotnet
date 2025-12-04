using Domain.Definitions.Results;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Payments
{
    public class GetListPaymentRequest : IRequest<Response<List<Payment>>>
    {
    }
}

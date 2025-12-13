using Application.DTOs;
using Domain.Definitions.Results;
using MediatR;

namespace Application.Requests.Payments
{
    public class RevenueStatisticRequest : IRequest<Response<RevenueStatisticDto>>
    {
    }
}

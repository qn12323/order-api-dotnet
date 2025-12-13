using Application.Requests.Payments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/revenue")]
    [ApiController]
    public class RevenueEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        public RevenueEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetAll()
        {
            var request = new RevenueStatisticRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}

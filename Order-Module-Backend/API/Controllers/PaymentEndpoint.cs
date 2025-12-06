using Application.Requests.Payments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Create([FromBody] CreatePaymentRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetAll()
        {
            var request = new GetListPaymentRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

using Application.Requests.OrderCancels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/orders-cancel")]
    [ApiController]
    public class OrderCancelEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderCancelEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Create([FromBody] CreateOrderCancelRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            var request = new GetOrderCancelByIdRequest()
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetAll()
        {
            var request = new GetOrderCancelRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{userId}/users")]
        public async Task<ActionResult<object>> GetByUserId(int userId)
        {
            var request = new GetOrderCancelRequest()
            {
                UserId = userId
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

using Application.Requests.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrderEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }   

        [HttpPost("orders")]
        public async Task<ActionResult<object>> Create([FromBody] CreateOrderRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<object>> GetById(string id)
        {
            var request = new GetOrderByIdRequest()
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("orders")]
        public async Task<ActionResult<object>> GetAll()
        {
            var request = new GetOrderRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("orders/{userId}/users")]
        public async Task<ActionResult<object>> GetByUserId(int userId)
        {
            var request = new GetOrderRequest()
            {
                UserId = userId
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("orders/{id}")]
        public async Task<ActionResult<object>> Update(string id, [FromBody] UpdateOrderRequest request)
        {
            var req = new UpdateOrderRequest()
            {
                Id = id,
                OrderStatus = request.OrderStatus,
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }

        [HttpPatch("orders/{id}/approve")]
        public async Task<ActionResult<object>> Approve(string id)
        {
            var req = new ApproveOrderRequest()
            {
                Id = id,
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }


        [HttpPatch("orders/{id}/cancel")]
        public async Task<ActionResult<object>> Cancel(string id)
        {
            var req = new CancelOrderRequest()
            {
                Id = id,
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }

        [HttpPatch("orders/{id}/complete")]
        public async Task<ActionResult<object>> Complete(string id)
        {
            var req = new CompleteOrderRequest()
            {
                Id = id,
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }

        [HttpDelete("orderitems/{id}")]
        public async Task<ActionResult<object>> RemoveItem(int id)
        {
            var request = new DeleteOrderItemRequest()
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("orderitems/{id}")]
        public async Task<ActionResult<object>> UpdateItem(int id, [FromBody] UpdateOrderItemRequest request)
        {
            var req = new UpdateOrderItemRequest()
            {
                Id = id,
                Quantity = request.Quantity,
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }
    }
}

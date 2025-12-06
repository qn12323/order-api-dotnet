using Application.Requests.OrderReturns;
using Application.Requests.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/orders-return")]
    [ApiController]
    public class OrderReturnEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderReturnEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Create([FromBody] CreateOrderReturnRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            var request = new GetOrderReturnByIdRequest()
            {
                Id = id
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetAll()
        {
            var request = new GetOrderReturnRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{userId}/users")]
        public async Task<ActionResult<object>> GetByUserId(int userId)
        {
            var request = new GetOrderReturnRequest()
            {
                UserId = userId
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("{id}/approve/{orderId}")]
        public async Task<ActionResult<object>> Approve(int id, string orderId)
        {
            var req = new ApproveOrderReturnRequest()
            {
                Id = id,
                OrderId = orderId
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }


        [HttpPatch("{id}/reject/{orderId}")]
        public async Task<ActionResult<object>> Reject(int id, string orderId)
        {
            var req = new RejectOrderReturnRequest()
            {
                Id = id,
                OrderId = orderId
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }

        [HttpPatch("{id}/complete/{orderId}")]
        public async Task<ActionResult<object>> Complete(int id, string orderId)
        {
            var req = new CompleteOrderReturnRequest()
            {
                Id = id,
                OrderId = orderId
            };
            var response = await _mediator.Send(req);
            return Ok(response);
        }
    }
}

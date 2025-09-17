using CleanCQRS.Application.Contributors.Order.Commands;
using CleanCQRS.Application.Contributors.Order.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderId = await _mediator.Send(command, cancellationToken);
                return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, new { Id = orderId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // e.g., customer/product not found
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetOrderByIdQuery(id);
            var order = await _mediator.Send(query, cancellationToken);

            if (order == null)
                return NotFound($"Order with Id {id} not found.");

            return Ok(order);
        }
    }
}

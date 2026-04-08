using Ecommerce.Integration.Application.Orders.CreateOrder;
using Ecommerce.Integration.Application.Orders.GetOrderById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Integration.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly CreateOrderHandler _createOrder;
        private readonly GetOrderByIdHandler _getOrderById;

        public OrdersController(
                CreateOrderHandler createOrder,
                GetOrderByIdHandler getOrderById)
        {
            _createOrder = createOrder;
            _getOrderById = getOrderById;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var result = await _createOrder.HandleAsync(command);
            return CreatedAtAction(nameof(GetById), new { id = result.OrderId }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getOrderById.HandleAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}

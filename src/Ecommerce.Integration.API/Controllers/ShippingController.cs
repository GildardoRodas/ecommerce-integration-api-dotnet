using Ecommerce.Integration.Application.Shipping.CreateShipment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Integration.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/shipping")]

    public class ShippingController : ControllerBase
    {

        private readonly CreateShipmentHandler _handler;

        public ShippingController(CreateShipmentHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShipmentCommand command)
        {
            var result = await _handler.HandleAsync(command);
            return Ok(result);
        }

    }
}

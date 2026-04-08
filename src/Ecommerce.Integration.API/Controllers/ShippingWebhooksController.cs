using Ecommerce.Integration.Application.Shipping.HandleShippingWebhook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Integration.API.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/webhooks/shipping")]

    public class ShippingWebhooksController : ControllerBase
    {

        private readonly ShippingWebhookHandler _handler;

        public ShippingWebhooksController(ShippingWebhookHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Handle([FromBody] ShippingWebhookCommand command)
        {
            await _handler.HandleAsync(command);
            return Ok();
        }

    }
}

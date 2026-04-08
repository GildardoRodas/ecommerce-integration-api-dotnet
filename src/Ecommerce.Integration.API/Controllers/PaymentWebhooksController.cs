using Ecommerce.Integration.Application.Payments.HandlePaymentWebhook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Integration.API.Controllers
{

    [ApiController]
    [Route("api/webhooks/payments")]
    [AllowAnonymous] // IMPORTANTE: los webhooks NO usan JWT

    public class PaymentWebhooksController : ControllerBase
    {

        private readonly PaymentWebhookHandler _handler;

        public PaymentWebhooksController(PaymentWebhookHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Handle([FromBody] PaymentWebhookCommand command)
        {
            await _handler.HandleAsync(command);
            return Ok();
        }

    }
}

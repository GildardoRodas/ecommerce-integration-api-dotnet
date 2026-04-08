using Ecommerce.Integration.Application.Payments.CreatePaymentIntent;
using Ecommerce.Integration.Application.Payments.ProcessPayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Integration.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/payments")]

    public class PaymentsController : ControllerBase
    {

        private readonly CreatePaymentIntentHandler _createPayment;
        private readonly ProcessPaymentHandler _processPayment;

        public PaymentsController(
            CreatePaymentIntentHandler createPayment,
            ProcessPaymentHandler processPayment)
        {
            _createPayment = createPayment;
            _processPayment = processPayment;
        }

        [HttpPost("intents")]
        public async Task<IActionResult> CreateIntent(CreatePaymentIntentCommand command)
        {
            var result = await _createPayment.HandleAsync(command);
            return Ok(result);
        }

        [HttpPost("{paymentId}/process")]
        public async Task<IActionResult> Process(Guid paymentId, [FromQuery] bool success)
        {
            await _processPayment.HandleAsync(
                new ProcessPaymentCommand(paymentId, success));

            return NoContent();
        }

    }
}

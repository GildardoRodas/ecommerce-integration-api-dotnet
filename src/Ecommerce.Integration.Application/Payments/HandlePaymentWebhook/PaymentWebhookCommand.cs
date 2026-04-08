

namespace Ecommerce.Integration.Application.Payments.HandlePaymentWebhook
{

    public record PaymentWebhookCommand(
        string Event,
        Guid PaymentId
    );

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Shipping.HandleShippingWebhook
{

    public record ShippingWebhookCommand(
        string Event,
        Guid ShipmentId
    );

}

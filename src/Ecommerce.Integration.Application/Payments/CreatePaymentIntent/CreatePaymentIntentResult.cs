using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Payments.CreatePaymentIntent
{
    public record CreatePaymentIntentResult(Guid PaymentId, string Status);
}

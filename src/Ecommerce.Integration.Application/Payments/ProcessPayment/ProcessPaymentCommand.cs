using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Payments.ProcessPayment
{
    public record ProcessPaymentCommand(Guid PaymentId, bool IsSuccessful);
}

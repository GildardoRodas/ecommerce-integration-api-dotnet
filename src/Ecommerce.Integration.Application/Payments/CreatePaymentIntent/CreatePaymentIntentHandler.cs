using Ecommerce.Integration.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Payments.CreatePaymentIntent
{
    public class CreatePaymentIntentHandler
    {

        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentIntentHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<CreatePaymentIntentResult> HandleAsync(CreatePaymentIntentCommand command)
        {
            var payment = new Payment(command.OrderId, command.Amount);

            await _paymentRepository.AddAsync(payment);

            return new CreatePaymentIntentResult(payment.Id, payment.Status.ToString());
        }

    }
}

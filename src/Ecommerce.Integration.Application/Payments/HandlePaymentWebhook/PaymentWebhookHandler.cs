using Ecommerce.Integration.Application.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Payments.HandlePaymentWebhook
{
    public class PaymentWebhookHandler
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public PaymentWebhookHandler(
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(PaymentWebhookCommand command)
        {
            var payment = await _paymentRepository.GetByIdAsync(command.PaymentId);
            if (payment == null)
                throw new InvalidOperationException("Payment not found");

            var order = await _orderRepository.GetByIdAsync(payment.OrderId);
            if (order == null)
                throw new InvalidOperationException("Order not found");

            switch (command.Event)
            {
                case "payment.succeeded":
                    payment.MarkAsSucceeded();
                    order.MarkAsPaid();
                    break;

                case "payment.failed":
                    payment.MarkAsFailed();
                    break;

                default:
                    throw new InvalidOperationException("Unknown payment event");
            }

            await _paymentRepository.UpdateAsync(payment);
        }
    }

}

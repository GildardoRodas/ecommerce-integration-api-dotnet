using Ecommerce.Integration.Application.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Payments.ProcessPayment
{
    public class ProcessPaymentHandler
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public ProcessPaymentHandler(
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(ProcessPaymentCommand command)
        {
            var payment = await _paymentRepository.GetByIdAsync(command.PaymentId);
            if (payment == null)
                throw new InvalidOperationException("Payment not found");

            var order = await _orderRepository.GetByIdAsync(payment.OrderId);
            if (order == null)
                throw new InvalidOperationException("Order not found");

            if (command.IsSuccessful)
            {
                payment.MarkAsSucceeded();
                order.MarkAsPaid();
            }
            else
            {
                payment.MarkAsFailed();
            }

            await _paymentRepository.UpdateAsync(payment);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Domain.Payments
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Payment() { }

        public Payment(Guid orderId, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero");

            Id = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Status = PaymentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsSucceeded() => Status = PaymentStatus.Succeeded;
        public void MarkAsFailed() => Status = PaymentStatus.Failed;

    }
}

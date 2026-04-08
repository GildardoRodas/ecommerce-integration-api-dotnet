using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Domain.Orders
{
    public class Order
    {

        public Guid Id { get; private set; }
        public decimal TotalAmount { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Order() { } // EF / Serialization

        public Order(decimal totalAmount)
        {
            if (totalAmount <= 0)
                throw new ArgumentException("Total amount must be greater than zero");

            Id = Guid.NewGuid();
            TotalAmount = totalAmount;
            Status = OrderStatus.Created;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsPaid()
        {
            Status = OrderStatus.Paid;
        }

    }
}

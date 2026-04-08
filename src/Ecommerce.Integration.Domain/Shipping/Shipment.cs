using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Domain.Shipping
{
    public class Shipment
    {

        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public string TrackingNumber { get; private set; }
        public ShipmentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Shipment() { }

        public Shipment(Guid orderId)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            TrackingNumber = $"TRK-{Guid.NewGuid():N}".Substring(0, 12);
            Status = ShipmentStatus.Created;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkInTransit() => Status = ShipmentStatus.InTransit;
        public void MarkDelivered() => Status = ShipmentStatus.Delivered;
        public void MarkFailed() => Status = ShipmentStatus.Failed;

    }
}

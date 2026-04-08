using Ecommerce.Integration.Application.Shipping;
using Ecommerce.Integration.Domain.Shipping;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Infrastructure.Persistence
{
    public class InMemoryShipmentRepository : IShipmentRepository
    {

        private readonly ConcurrentDictionary<Guid, Shipment> _shipments = new();

        public Task AddAsync(Shipment shipment)
        {
            _shipments[shipment.Id] = shipment;
            return Task.CompletedTask;
        }

        public Task<Shipment?> GetByIdAsync(Guid id)
        {
            _shipments.TryGetValue(id, out var shipment);
            return Task.FromResult(shipment);
        }

        public Task UpdateAsync(Shipment shipment)
        {
            _shipments[shipment.Id] = shipment;
            return Task.CompletedTask;
        }

    }
}

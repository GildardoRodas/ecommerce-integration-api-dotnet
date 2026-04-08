using Ecommerce.Integration.Application.Orders;
using Ecommerce.Integration.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Infrastructure.Persistence
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Order> _orders = new();

        public Task AddAsync(Order order)
        {
            _orders[order.Id] = order;
            return Task.CompletedTask;
        }

        public Task<Order?> GetByIdAsync(Guid id)
        {
            _orders.TryGetValue(id, out var order);
            return Task.FromResult(order);
        }

    }

}

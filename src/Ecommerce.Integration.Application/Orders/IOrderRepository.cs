
using Ecommerce.Integration.Domain.Orders;

namespace Ecommerce.Integration.Application.Orders
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);

    }
}

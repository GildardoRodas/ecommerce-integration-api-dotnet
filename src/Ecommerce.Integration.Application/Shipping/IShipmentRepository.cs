using Ecommerce.Integration.Domain.Shipping;

namespace Ecommerce.Integration.Application.Shipping
{
    public interface IShipmentRepository
    {

        Task AddAsync(Shipment shipment);
        Task<Shipment?> GetByIdAsync(Guid id);
        Task UpdateAsync(Shipment shipment);

    }
}



namespace Ecommerce.Integration.Application.Shipping.CreateShipment
{    
    public record CreateShipmentResult(
        Guid ShipmentId,
        string TrackingNumber,
        string Status
    );

}



namespace Ecommerce.Integration.Application.Shipping.HandleShippingWebhook
{
    public class ShippingWebhookHandler
    {

        private readonly IShipmentRepository _shipmentRepository;

        public ShippingWebhookHandler(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task HandleAsync(ShippingWebhookCommand command)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(command.ShipmentId);
            if (shipment == null)
                throw new InvalidOperationException("Shipment not found");

            switch (command.Event)
            {
                case "shipment.in_transit":
                    shipment.MarkInTransit();
                    break;

                case "shipment.delivered":
                    shipment.MarkDelivered();
                    break;

                case "shipment.failed":
                    shipment.MarkFailed();
                    break;

                default:
                    throw new InvalidOperationException("Unknown shipping event");
            }

            await _shipmentRepository.UpdateAsync(shipment);
        }

    }
}

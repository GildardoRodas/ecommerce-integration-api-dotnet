using Ecommerce.Integration.Application.Shipping;
using Ecommerce.Integration.Application.Shipping.CreateShipment;
using Ecommerce.Integration.Domain.Shipping;


namespace Ecommerce.Integration.Application.Shipping.CreateShipment
{
    public class CreateShipmentHandler
    {

        private readonly IShipmentRepository _repository;

        public CreateShipmentHandler(IShipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateShipmentResult> HandleAsync(CreateShipmentCommand command)
        {
            var shipment = new Shipment(command.OrderId);

            await _repository.AddAsync(shipment);

            return new CreateShipmentResult(
                shipment.Id,
                shipment.TrackingNumber,
                shipment.Status.ToString()
            );
        }

    }
}

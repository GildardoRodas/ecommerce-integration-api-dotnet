
using Ecommerce.Integration.Domain.Orders;

namespace Ecommerce.Integration.Application.Orders.CreateOrder
{
    public class CreateOrderHandler
    {

        private readonly IOrderRepository _repository;

        public CreateOrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderResult> HandleAsync(CreateOrderCommand command)
        {
            var order = new Order(command.TotalAmount);

            await _repository.AddAsync(order);

            return new CreateOrderResult(order.Id, order.Status.ToString());
        }

    }
}

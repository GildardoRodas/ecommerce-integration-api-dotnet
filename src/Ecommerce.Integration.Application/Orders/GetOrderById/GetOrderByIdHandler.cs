
namespace Ecommerce.Integration.Application.Orders.GetOrderById
{
    public class GetOrderByIdHandler
    {

        private readonly IOrderRepository _repository;

        public GetOrderByIdHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderByIdResult?> HandleAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order == null)
                return null;

            return new GetOrderByIdResult(
                order.Id,
                order.TotalAmount,
                order.Status.ToString()
            );
        }


    }
}

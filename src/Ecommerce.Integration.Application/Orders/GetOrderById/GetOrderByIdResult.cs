
namespace Ecommerce.Integration.Application.Orders.GetOrderById
{
    public record GetOrderByIdResult(Guid Id, decimal TotalAmount, string Status);
}

using Shared.DTOs.Order;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetOrdersAsync(string userId, bool trackChanges);

    Task<OrderDto> PlaceOrderAsync(string userId);

    Task<OrderDto> GetOrderAsync(Guid orderId, bool trackChanges);
}

using Shared.DTOs;

namespace Service.Contracts;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetOrdersAsync(string userId, bool trackChanges);

    Task<OrderDto> PlaceOrderAsync(string userId);

    Task<OrderDto> GetOrderAsync(Guid orderId, bool trackChanges);
}

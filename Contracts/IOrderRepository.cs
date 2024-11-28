using Entities.Models;

namespace Contracts;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync(string userId, bool trackChanges);
    Task<Order> GetOrderByOrderIdAsync(Guid guide, bool trackChanges);
    void CreateOrder(Order order);
}

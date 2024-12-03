using Domain.Entities.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public void CreateOrder(Order order) => Create(order);
    public async Task<IEnumerable<Order>> GetAllAsync(string userId, bool trackChanges)
    {
        return await FindByCondition(o => o.UserId.Equals(userId), trackChanges)
            .Include(o => o.Items).ThenInclude(o => o.Product).ToListAsync();
    }

    public async Task<Order> GetOrderByOrderIdAsync(Guid orderId, bool trackChanges) =>
        await FindByCondition(o => o.Id.Equals(orderId), trackChanges)
        .Include(o => o.Items).ThenInclude(o => o.Product).SingleOrDefaultAsync();
}

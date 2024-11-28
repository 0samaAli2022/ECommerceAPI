using Domain.Entities.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CartRepository(RepositoryContext repositoryContext) : RepositoryBase<Cart>(repositoryContext),
    ICartRepository
{
    public async Task<Cart> GetCartByUserIdAsync(string userId, bool trackChanges)
    {
        var cart = await FindByCondition(c => c.UserId.Equals(userId), trackChanges)
                .Include(c => c.Items)
                .ThenInclude(c => c.Product)
                .SingleOrDefaultAsync();
        if (cart is null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            CreateCart(cart);
        }
        return cart;
    }

    public async Task<Cart> GetCartByCartIdAsync(Guid cartId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(cartId), trackChanges).SingleOrDefaultAsync();

    public void CreateCart(Cart cart) => Create(cart);

    public void DeleteCart(Cart cart) => Delete(cart);
}

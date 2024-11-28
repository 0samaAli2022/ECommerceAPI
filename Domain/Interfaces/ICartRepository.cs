using Domain.Entities.Models;

namespace Domain.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCartByUserIdAsync(string userId, bool trackChanges);
    Task<Cart> GetCartByCartIdAsync(Guid cartId, bool trackChanges);
    void CreateCart(Cart cart);
    void DeleteCart(Cart cart);

    //// Update an existing cart
    //Task UpdateCartAsync(Cart cart);


    ////// Add an item to a cart
    //Task AddCartItemAsync(Cart cart, CartItem cartItem);

    //// Remove an item from a cart
    //Task RemoveCartItemAsync(int cartId, int cartItemId);

    //// Get total price of the cart
    //Task<decimal> GetCartTotalPriceAsync(int cartId);
}

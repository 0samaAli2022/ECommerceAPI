using Shared.DTOs.Cart;

namespace Application.Interfaces;

public interface ICartService
{
    Task<CartDto> GetCartAsync(string userId, bool trackChanges);
    Task DeleteCartAsync(string userId, bool trackChanges);
    Task AddCartItemAsync(string userId, AddCartItemDto addCartItemDto);
    Task UpdateCartItemAsync(string userId, UpdateCartItemDto updateCartItemDto);
}

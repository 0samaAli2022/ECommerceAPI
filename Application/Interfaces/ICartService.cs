using Shared.DTOs;

namespace Application.Interfaces;

public interface ICartService
{
    Task<CartDto> GetCartAsync(string userId, bool trackChanges);
    Task DeleteCartAsync(string userId, bool trackChanges);
    Task AddOrUpdateCartItemAsync(string userId, UpdateCartItemDto addCartItemDto);
}

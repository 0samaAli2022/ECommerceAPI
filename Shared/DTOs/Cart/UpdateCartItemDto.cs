namespace Shared.DTOs.Cart;

public record UpdateCartItemDto(Guid CartItemId, int Quantity);
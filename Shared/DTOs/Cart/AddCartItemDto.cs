namespace Shared.DTOs.Cart;

public record AddCartItemDto(Guid ProductId, int Quantity);
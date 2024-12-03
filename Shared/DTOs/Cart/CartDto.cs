namespace Shared.DTOs.Cart;

public record CartDto(Guid Id, ICollection<CartItemDto> Items, decimal TotalPrice);

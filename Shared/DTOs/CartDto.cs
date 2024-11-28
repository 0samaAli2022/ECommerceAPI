namespace Shared.DTOs;

public record CartDto(Guid Id, ICollection<CartItemDto> Items, decimal TotalPrice);

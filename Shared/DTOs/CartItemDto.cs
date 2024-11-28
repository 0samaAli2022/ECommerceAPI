namespace Shared.DTOs;

public record CartItemDto(Guid Id, ProductDto Product, int Quantity, decimal TotalPrice);
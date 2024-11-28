namespace Shared.DTOs;

public record OrderItemDto(Guid Id, ProductDto Product, int Quantity, decimal TotalPrice);
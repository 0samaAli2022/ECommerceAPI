using Shared.DTOs.Product;

namespace Shared.DTOs.Order;

public record OrderItemDto(Guid Id, ProductDto Product, int Quantity, decimal TotalPrice);
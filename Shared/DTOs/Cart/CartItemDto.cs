using Shared.DTOs.Product;

namespace Shared.DTOs.Cart;

public record CartItemDto(Guid Id, ProductDto Product, int Quantity, decimal TotalPrice);
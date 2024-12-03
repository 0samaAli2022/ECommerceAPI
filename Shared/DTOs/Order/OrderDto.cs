namespace Shared.DTOs.Order;

public record OrderDto(Guid Id, DateTime OrderDate, ICollection<OrderItemDto> Items, decimal TotalPrice);
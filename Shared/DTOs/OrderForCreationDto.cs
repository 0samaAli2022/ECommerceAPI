using Entities.Models;

namespace Shared.DTOs;

public record OrderForCreationDto(string UserId, ICollection<CartItem> Items, decimal TotalPrice);

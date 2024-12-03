﻿namespace Shared.DTOs.Product;

public record ProductDto(Guid Id, string Name, string Description, decimal Price, int StockQuantity);

﻿namespace Shared.DTOs;

public record ProductDto(Guid Id, string Name, string Description, decimal Price, int StockQuantity);

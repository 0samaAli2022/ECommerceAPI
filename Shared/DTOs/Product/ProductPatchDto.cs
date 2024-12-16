namespace Shared.DTOs.Product;

public record ProductPatchDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal? Price { get; init; }
    public int? StockQuantity { get; init; }
}

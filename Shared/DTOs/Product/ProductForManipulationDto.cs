namespace Shared.DTOs.Product;

public abstract record ProductForManipulationDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
}

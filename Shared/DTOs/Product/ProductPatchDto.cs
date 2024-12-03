using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Product;

public record ProductPatchDto
{
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }
    [MaxLength(300, ErrorMessage = "Maximum length for the Name is 300 characters.")]
    public string? Description { get; init; }
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal? Price { get; init; }
    [Range(1, int.MaxValue, ErrorMessage = "StockQuantity must be greater than 0.")]
    public int? StockQuantity { get; init; }
}

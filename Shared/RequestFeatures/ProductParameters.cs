namespace Shared.RequestFeatures;

public class ProductParameters : RequestParameters
{

    public ProductParameters() => OrderBy = "name";
    public decimal MinPrice { get; set; } = 0;
    public decimal MaxPrice { get; set; } = 999999999999999.99m;
    public bool ValidPriceRange => MaxPrice > MinPrice;

    public string? SearchTerm { get; set; }
}

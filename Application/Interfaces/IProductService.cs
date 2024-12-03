using Shared.DTOs.Product;
using Shared.RequestFeatures;

namespace Application.Interfaces;

public interface IProductService
{
    Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
    Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges);
    Task<ProductDto> CreateProductAsync(ProductForCreationDto product);
    Task UpdateProductAsync(Guid productId, ProductForUpdateDto productForUpdate, bool trackChanges);
    Task PartiallyUpdateProductAsync(Guid productId, ProductPatchDto productForUpdate, bool trackChanges);
    Task DeleteProductAsync(Guid productId, bool trackChanges);

}

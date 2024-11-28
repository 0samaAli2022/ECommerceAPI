using Shared.DTOs;
using Shared.RequestFeatures;

namespace Application.Interfaces;

public interface IProductService
{
    Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges);
    Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges);
    Task<ProductDto> CreateProductAsync(ProductForCreationDto product);
    //void UpdateProduct(ProductDto product);
    Task DeleteProductAsync(Guid productId, bool trackChanges);
    Task UpdateProductAsync(Guid productId, ProductForUpdateDto productForUpdate, bool trackChanges);
}

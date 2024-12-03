using Domain.Entities.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository.Repositories;

public class ProductRepository(RepositoryContext repositoryContext) :
    RepositoryBase<Product>(repositoryContext), IProductRepository
{
    public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
    {
        var products = await FindAll(trackChanges)
            .FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
            .Search(productParameters.SearchTerm!)
            .Sort(productParameters.OrderBy!)
            .ToListAsync();
        var count = await FindAll(trackChanges)
            .FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
            .Search(productParameters.SearchTerm!)
            .CountAsync();

        return PagedList<Product>.ToPagedList(products, count, productParameters.PageNumber, productParameters.PageSize);
    }

    public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) =>
        await FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefaultAsync();

    public void CreateProduct(Product product) => Create(product);

    public void DeleteProduct(Product product) => Delete(product);
}

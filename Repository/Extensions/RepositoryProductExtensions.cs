using Domain.Entities.Models;
using Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions;

public static class RepositoryProductExtensions
{
    public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, decimal minPrice, decimal maxPrice) =>
    products.Where(e => e.Price >= minPrice && e.Price <= maxPrice);
    public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return products;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return products.
            Where(p => p.Name.ToLower().Contains(lowerCaseTerm) || p.Description.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return products.OrderBy(p => p.Id);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return products.OrderBy(p => p.Id);
        return products.OrderBy(orderQuery);
    }
}

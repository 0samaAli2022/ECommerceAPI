using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Description = "High performance laptop",
                Price = 999.99m,
                StockQuantity = 50,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smartphone",
                Description = "Latest model smartphone",
                Price = 699.99m,
                StockQuantity = 100,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Headphones",
                Description = "Noise-cancelling headphones",
                Price = 199.99m,
                StockQuantity = 200,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smartwatch",
                Description = "Feature-rich smartwatch",
                Price = 299.99m,
                StockQuantity = 75,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                Description = "Lightweight and powerful tablet",
                Price = 399.99m,
                StockQuantity = 150,
            }
        );
    }
}

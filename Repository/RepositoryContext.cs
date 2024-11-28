using Domain.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : IdentityDbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
    //public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.Entity<User>()
             .HasOne(u => u.ShoppingCart)
             .WithOne(c => c.User)
             .HasForeignKey<Cart>(c => c.UserId)
             .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CartItem>()
                 .HasOne(c => c.Product)
                 .WithMany(p => p.CartItems)
                 .HasForeignKey(c => c.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CartItem>()
            .HasOne(c => c.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(c => c.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<OrderItem>()
                 .HasOne(o => o.Product)
                 .WithMany(p => p.OrderItems)
                 .HasForeignKey(o => o.ProductId)
                 .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Order>()
                 .HasOne(o => o.User)
                 .WithMany(u => u.Orders)
                 .HasForeignKey(o => o.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<OrderItem>()
                 .HasOne(o => o.Order)
                 .WithMany(u => u.Items)
                 .HasForeignKey(o => o.OrderId)
                 .OnDelete(DeleteBehavior.Cascade);
    }
}

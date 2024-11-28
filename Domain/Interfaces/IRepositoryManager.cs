namespace Domain.Interfaces;

public interface IRepositoryManager
{
    IUserRepository User { get; }
    IProductRepository Product { get; }
    IOrderRepository Order { get; }
    ICartRepository Cart { get; }
    Task SaveAsync();
}
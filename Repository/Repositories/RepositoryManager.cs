using Domain.Interfaces;

namespace Repository.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ICartRepository> _cartRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _userRepository = new Lazy<IUserRepository>(() => new
        UserRepository(repositoryContext));
        _productRepository = new Lazy<IProductRepository>(() => new
        ProductRepository(repositoryContext));
        _cartRepository = new Lazy<ICartRepository>(() => new
        CartRepository(repositoryContext));
        _orderRepository = new Lazy<IOrderRepository>(() => new
        OrderRepository(repositoryContext));
    }
    public IUserRepository User => _userRepository.Value;
    public IProductRepository Product => _productRepository.Value;
    public ICartRepository Cart => _cartRepository.Value;
    public IOrderRepository Order => _orderRepository.Value;
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}

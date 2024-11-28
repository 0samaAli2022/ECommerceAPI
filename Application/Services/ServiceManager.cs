using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<IOrderService> _orderService;
    private readonly Lazy<ICartService> _cartService;
    private readonly Lazy<IAuthenticationService> _authenticationService;
    public ServiceManager(IRepositoryManager repositoryManager,
        ILoggerManager logger,
        IMapper mapper,
        UserManager<User> userManager,
        IConfiguration configuration)
    {
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper));
        _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, logger, mapper));
        _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, logger, mapper));
        _cartService = new Lazy<ICartService>(() => new CartService(repositoryManager, logger, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
    }
    public IUserService UserService => _userService.Value;
    public IProductService ProductService => _productService.Value;
    public IOrderService OrderService => _orderService.Value;
    public ICartService CartService => _cartService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
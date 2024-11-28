namespace Service.Contracts;

public interface IServiceManager
{
    IUserService UserService { get; }
    IProductService ProductService { get; }
    IOrderService OrderService { get; }
    ICartService CartService { get; }
    IAuthenticationService AuthenticationService { get; }
}

using AutoMapper;
using Domain.Entities.Models;
using Shared.DTOs.Auth;
using Shared.DTOs.Cart;
using Shared.DTOs.Order;
using Shared.DTOs.Product;

namespace ECommerceAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<UserForRegistrationDto, User>();

        CreateMap<Product, ProductDto>();
        CreateMap<ProductForCreationDto, Product>();
        CreateMap<ProductForUpdateDto, Product>();
        CreateMap<ProductPatchDto, Product>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Cart, CartDto>();
        CreateMap<CartForCreationDto, Cart>();
        CreateMap<CartItem, CartItemDto>();

        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>();

        CreateMap<Cart, Order>();
        CreateMap<CartItem, OrderItem>();
    }
}


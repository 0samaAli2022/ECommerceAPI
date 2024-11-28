using AutoMapper;
using Domain.Entities.Models;
using Shared.DTOs;

namespace ECommerceAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductForCreationDto, Product>();
        CreateMap<ProductForUpdateDto, Product>();
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<Cart, CartDto>();
        CreateMap<CartForCreationDto, Cart>();
        CreateMap<CartItem, CartItemDto>();
        CreateMap<Cart, OrderForCreationDto>();
        CreateMap<Cart, Order>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<CartItem, OrderItem>();
    }
}


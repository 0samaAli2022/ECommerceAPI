using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Exceptions;
using Domain.Entities.Models;
using Domain.Interfaces;

using Shared.DTOs;

namespace Application.Services;

internal sealed class CartService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : ICartService
{
    private readonly IRepositoryManager _repository = repository;
    private readonly ILoggerManager _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<CartDto> GetCartAsync(string userId, bool trackChanges)
    {
        var cart = await _repository.Cart.GetCartByUserIdAsync(userId, trackChanges);
        await _repository.SaveAsync();
        var cartDto = _mapper.Map<CartDto>(cart);
        return cartDto;
    }

    public async Task AddOrUpdateCartItemAsync(string userId, UpdateCartItemDto addCartItemDto)
    {
        var product = await _repository.Product.GetProductAsync(addCartItemDto.ProductId, trackChanges: false)
            ?? throw new ProductNotFoundException(addCartItemDto.ProductId);
        var cart = await _repository.Cart.GetCartByUserIdAsync(userId, trackChanges: true);
        UpdateOrCreateCartItemAsync(cart, product, addCartItemDto);
        await _repository.SaveAsync();
    }

    public async Task DeleteCartAsync(string userId, bool trackChanges)
    {
        var cart = await _repository.Cart.GetCartByUserIdAsync(userId, trackChanges);
        _repository.Cart.DeleteCart(cart);
        await _repository.SaveAsync();
    }

    private void UpdateOrCreateCartItemAsync(Cart cart, Product product, UpdateCartItemDto updateCartItemDto)
    {
        var cartItem = cart.Items.FirstOrDefault(ci => ci.ProductId == updateCartItemDto.ProductId);
        if (cartItem is null)
        {
            if (product.StockQuantity < updateCartItemDto.Quantity || updateCartItemDto.Quantity < 1)
                throw new UpdateItemQuantityBadRequestException(product.StockQuantity);
            cart.Items.Add(
                new CartItem
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = updateCartItemDto.Quantity,
                }
            );
        }
        else
        {
            var newQuantity = cartItem.Quantity + updateCartItemDto.Quantity;
            if (product.StockQuantity < newQuantity || newQuantity < 1)
                throw new UpdateItemQuantityBadRequestException(product.StockQuantity);
            cartItem.Quantity += updateCartItemDto.Quantity;
        }
    }
}


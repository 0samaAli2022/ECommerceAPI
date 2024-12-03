using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Exceptions;
using Domain.Entities.Models;
using Domain.Interfaces;
using Shared.DTOs.Cart;

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

    public async Task AddCartItemAsync(string userId, AddCartItemDto addCartItemDto)
    {
        var product = await _repository.Product.GetProductAsync(addCartItemDto.ProductId, trackChanges: false)
            ?? throw new ProductNotFoundException(addCartItemDto.ProductId);
        var cart = await _repository.Cart.GetCartByUserIdAsync(userId, trackChanges: true);
        AddCartItem(cart, product, addCartItemDto);
        await _repository.SaveAsync();
    }

    public async Task UpdateCartItemAsync(string userId, UpdateCartItemDto updateCartItemDto)
    {
        var cart = await _repository.Cart.GetCartByUserIdAsync(userId, trackChanges: true);
        UpdateCartItem(cart, updateCartItemDto);
        await _repository.SaveAsync();
    }

    public async Task DeleteCartAsync(string userId, bool trackChanges)
    {
        var cart = await _repository.Cart.GetCartByUserIdAsync(userId, trackChanges);
        _repository.Cart.DeleteCart(cart);
        await _repository.SaveAsync();
    }

    private void CreateCartItem(Cart cart, Product product, AddCartItemDto addCartItemDto)
    {
        if (product.StockQuantity < addCartItemDto.Quantity || addCartItemDto.Quantity < 1)
            throw new UpdateItemQuantityBadRequestException(product.StockQuantity);
        cart.Items.Add(
            new CartItem
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = addCartItemDto.Quantity,
            }
        );
    }
    private void UpdateCartItem(Cart cart, UpdateCartItemDto updateCartItemDto)
    {
        var cartItem = cart.Items.FirstOrDefault(ci => ci.Id == updateCartItemDto.CartItemId)
            ?? throw new CartItemNotFoundException(updateCartItemDto.CartItemId);

        var newQuantity = cartItem.Quantity + updateCartItemDto.Quantity;
        var product = cartItem.Product;

        if (newQuantity > product!.StockQuantity)
            throw new UpdateItemQuantityBadRequestException(product.StockQuantity);

        if (newQuantity < 1)
        {
            cart.Items.Remove(cartItem);
            if (cart.Items.Count == 0)
                _repository.Cart.DeleteCart(cart);
        }
        else
        {
            cartItem.Quantity = newQuantity;
        }
    }

    public void AddCartItem(Cart cart, Product product, AddCartItemDto addCartItemDto)
    {
        var cartItem = cart.Items.FirstOrDefault(ci => ci.ProductId == addCartItemDto.ProductId);
        if (cartItem is null)
        {
            CreateCartItem(cart, product, addCartItemDto);
        }
        else
        {
            var updateDto = new UpdateCartItemDto(cartItem.Id, addCartItemDto.Quantity);

            UpdateCartItem(cart, updateDto);
        }
    }
}


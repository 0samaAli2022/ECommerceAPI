using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Exceptions;
using Domain.Entities.Models;
using Domain.Interfaces;
using Shared.DTOs.Order;

namespace Application.Services;

internal sealed class OrderService : IOrderService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public OrderService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<OrderDto> GetOrderAsync(Guid orderId, bool trackChanges)
    {
        var order = await _repository.Order.GetOrderByOrderIdAsync(orderId, trackChanges);
        var orderDto = _mapper.Map<OrderDto>(order);
        return orderDto;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersAsync(string userId, bool trackChanges)
    {
        var orders = await _repository.Order.GetAllAsync(userId, trackChanges);
        var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
        return ordersDto;
    }

    public async Task<OrderDto> PlaceOrderAsync(string userId)
    {
        var cart = await _repository.Cart.GetCartByUserIdAsync(userId, trackChanges: true);
        if (cart.Items.Count == 0)
            throw new EmptyCartException();

        var orderEntity = _mapper.Map<Order>(cart);
        _repository.Order.CreateOrder(orderEntity);

        ReduceStockQuantity(orderEntity.Items);

        _repository.Cart.DeleteCart(cart);

        await _repository.SaveAsync();
        var orderDto = _mapper.Map<OrderDto>(orderEntity);
        return orderDto;
    }

    private void ReduceStockQuantity(IEnumerable<OrderItem> orderItems)
    {
        foreach (var orderItem in orderItems)
        {
            orderItem.Product!.StockQuantity -= orderItem.Quantity;
            if (orderItem.Product.StockQuantity == 0)
                _repository.Product.DeleteProduct(orderItem.Product);
        }
    }
}


using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _service.OrderService.GetOrdersAsync(userId!, trackChanges: false);
            return Ok(orders);
        }

        [HttpGet("{id:Guid}", Name = "OrderById")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _service.OrderService.GetOrderAsync(id, trackChanges: false);
            return Ok(order);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdOrder = await _service.OrderService.PlaceOrderAsync(userId!);
            return CreatedAtRoute("OrderById", new { id = createdOrder.Id }, createdOrder);
        }
    }
}

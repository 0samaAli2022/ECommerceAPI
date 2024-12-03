using Application.Interfaces;
using ECommerceAPI.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Cart;
using System.Security.Claims;

namespace ECommerceAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _service.CartService.GetCartAsync(userId!, trackChanges: false);
            return Ok(cart);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddOrUpdateCartItem([FromBody] AddCartItemDto addCartItemDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.CartService.AddCartItemAsync(userId!, addCartItemDto);
            return NoContent();
        }

        [HttpPatch]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCartItemQuantity([FromBody] UpdateCartItemDto updateCartItemDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.CartService.UpdateCartItemAsync(userId!, updateCartItemDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.CartService.DeleteCartAsync(userId!, trackChanges: false);
            return NoContent();
        }
    }
}

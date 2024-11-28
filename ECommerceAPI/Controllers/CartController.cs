using Application.Interfaces;
using ECommerceAPI.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System.Security.Claims;

namespace ECommerceAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _service.CartService.GetCartAsync(userId!, trackChanges: false);
            return Ok(cart);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddOrUpdateCartItem([FromBody] UpdateCartItemDto addCartItemDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.CartService.AddOrUpdateCartItemAsync(userId!, addCartItemDto);
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.CartService.DeleteCartAsync(userId!, trackChanges: false);
            return NoContent();
        }
    }
}

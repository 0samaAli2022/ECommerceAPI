using Application.Interfaces;
using ECommerceAPI.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Product;
using Shared.RequestFeatures;
using System.Text.Json;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProductsController(IServiceManager service) => _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var pagedProducts = await _service.ProductService.GetAllProductsAsync(productParameters, trackChanges: false);
            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(pagedProducts.metaData);
            return Ok(pagedProducts.products);
        }

        [HttpGet("{id:Guid}", Name = "ProductById")]
        [Authorize]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _service.ProductService.GetProductAsync(id, trackChanges: false);
            return Ok(product);
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
        {
            var createdProduct = await _service.ProductService.CreateProductAsync(product);
            return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
        }


        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductForUpdateDto product)
        {
            await _service.ProductService.UpdateProductAsync(id, product, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:Guid}")]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PartiallyUpdateProduct(Guid id, [FromBody] ProductPatchDto productPatchDto)
        {
            await _service.ProductService.PartiallyUpdateProductAsync(id, productPatchDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _service.ProductService.DeleteProductAsync(id, trackChanges: false);
            return NoContent();
        }
    }
}

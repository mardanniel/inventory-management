using InventorySystem.API.DTOs;
using InventorySystem.API.Models;
using InventorySystem.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllProducts()
        {
            List<Product> products = await this._productRepository.GetProducts();
            
            return Ok(products);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO newProduct)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            Product product = new Product
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price
            };

            bool result = await this._productRepository.AddProduct(product);

            return result ? Ok("Successfully created product!") : BadRequest("Product creation failed!");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetProductById([FromQuery] Guid? productId)
        {
            if(productId == null) return BadRequest("Please provide product ID.");

            Product product = await this._productRepository.GetProductById((Guid)productId);

            if(product == null) return NotFound("Product not found!");

            return Ok(product);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO newProduct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Product product = new Product
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price
            };

            bool result = await this._productRepository.UpdateProduct(newProduct.Id, newProduct);

            return result ? Ok("Successfully updated product!") : BadRequest("Product update failed!"); ;
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProductByProductId([FromQuery] Guid? productId)
        {
            if(productId == null) return BadRequest();

            bool result = await this._productRepository.DeleteProductById((Guid)productId);

            return result ? Ok("Successfully deleted product!") : NotFound("Product deletion failed!"); ;
        }
    }
}

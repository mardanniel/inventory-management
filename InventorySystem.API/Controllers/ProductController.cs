using InventorySystem.API.DTOs;
using InventorySystem.API.Models;
using InventorySystem.API.Repositories;
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

            return result ? Ok() : BadRequest();
        }

        [HttpGet("Get/{productId:guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid? productId)
        {
            if(productId == null) return BadRequest();

            Product product = await this._productRepository.GetProductById((Guid)productId);

            if(product == null) return NotFound();

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

            return result ? Ok() : BadRequest();
        }

        [HttpDelete("Delete/{productId:guid}")]
        public async Task<IActionResult> DeleteProductByProductId([FromRoute] Guid? productId)
        {
            if(productId == null) return BadRequest();

            bool result = await this._productRepository.DeleteProductById((Guid)productId);

            return result ? Ok() : NotFound();
        }
    }
}

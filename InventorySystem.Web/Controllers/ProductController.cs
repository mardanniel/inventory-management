using InventorySystem.Web.Models;
using InventorySystem.Web.Repositories;
using InventorySystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productApiRepository;

        public ProductController(IProductRepository productApiRepository)
        {
            this._productApiRepository = productApiRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> products = await this._productApiRepository.GetProducts();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid? productId)
        {
            if (productId == null) return NotFound();

            Product product = await this._productApiRepository.GetProductById((Guid)productId);

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel newProduct)
        {
            if (!ModelState.IsValid) return View();

            Product newProductToAdd = new Product
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description
            };

            await this._productApiRepository.AddProduct(newProductToAdd);

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? productId)
        {
            if (productId == null) return NotFound();

            Product product = await this._productApiRepository.GetProductById((Guid)productId);

            UpdateProductViewModel productViewModel = new UpdateProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Status = product.Status
            };

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductViewModel newProduct)
        {
            if (!ModelState.IsValid) return View();

            await this._productApiRepository.UpdateProduct(newProduct.Id, newProduct);

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? productId)
        {
            if (productId == null) return NotFound();

            Product product = await this._productApiRepository.GetProductById((Guid)productId);

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirmed(Guid? Id)
        {
            if (Id == null) return NotFound();

            await this._productApiRepository.DeleteProductById((Guid)Id);

            return RedirectToAction("Index", "Product");
        }
    }
}
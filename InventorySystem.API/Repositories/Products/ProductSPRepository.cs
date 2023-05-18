using InventorySystem.API.Data;
using InventorySystem.API.DTOs;
using InventorySystem.API.Models;

namespace InventorySystem.API.Repositories.Products
{
    public class ProductSPRepository : IProductRepository
    {
        private readonly InventoryDbContext _inventoryDbContext;

        public ProductSPRepository(InventoryDbContext inventoryDbContext)
        {
            this._inventoryDbContext = inventoryDbContext;
        }

        public async Task<bool> AddProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProduct(Guid productId, UpdateProductDTO newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
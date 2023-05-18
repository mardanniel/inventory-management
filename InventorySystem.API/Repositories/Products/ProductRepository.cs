using InventorySystem.API.Data;
using InventorySystem.API.DTOs;
using InventorySystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Repositories.Products
{
    // Simple Product CRUD using DbContext

    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext _inventoryDbContext;

        public ProductRepository(InventoryDbContext inventoryDbContext)
        {
            this._inventoryDbContext = inventoryDbContext;
        }

        public async Task<bool> AddProduct(Product newProduct)
        {
            newProduct.CreatedAt = DateTime.Now;
            newProduct.UpdatedAt = DateTime.Now;

            await this._inventoryDbContext.Products.AddAsync(newProduct);

            return await this._inventoryDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductById(Guid productId)
        {
            Product productToDelete = await this._inventoryDbContext.Products.FindAsync(productId);

            if(productToDelete == null) return false;

            this._inventoryDbContext.Products.Remove(productToDelete);

            return await this._inventoryDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            Product product = await this._inventoryDbContext.Products.FindAsync(productId);

            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await this._inventoryDbContext.Products.ToListAsync();
            
            return products;
        }

        public async Task<bool> UpdateProduct(Guid productId, UpdateProductDTO newProduct)
        {
            Product productToUpdate = await this._inventoryDbContext.Products.FindAsync(productId);

            if (productToUpdate == null) return false;

            productToUpdate.Name = newProduct.Name;
            productToUpdate.Description = newProduct.Description;
            productToUpdate.Price = newProduct.Price;
            
            productToUpdate.UpdatedAt = DateTime.Now;

            this._inventoryDbContext.Products.Update(productToUpdate);

            return await this._inventoryDbContext.SaveChangesAsync() > 0;
        }
    }
}
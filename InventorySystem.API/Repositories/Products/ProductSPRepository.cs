using InventorySystem.API.Data;
using InventorySystem.API.DTOs;
using InventorySystem.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            string name = "@Name = " + $"'{newProduct.Name}'";
            string price = "@Price = " + newProduct.Price.ToString();
            string description = "@Description = " + $"'{newProduct.Description}'";
            string status = "@Status = " + 1;
            string createdAt = "@CreatedAt = " + $"'{DateTime.Now.ToString()}'";
            string updatedAt = "@UpdatedAt = " + $"'{DateTime.Now.ToString()}'";

            string execString = $"{name}, {price}, {description}, {status}, {createdAt}, {updatedAt}";

            return await this._inventoryDbContext.Database
                .ExecuteSqlRawAsync($"Inventory_Product_Create {execString}") > 0;
        }

        public async Task<bool> DeleteProductById(Guid productId)
        {
            return await this._inventoryDbContext.Database
                .ExecuteSqlRawAsync($"Inventory_Product_DeleteById '{productId.ToString()}'") > 0;
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            List<Product> products = await this._inventoryDbContext.Products
                .FromSqlRaw($"Inventory_Product_GetById '{productId.ToString()}'")
                .ToListAsync();

            return products.FirstOrDefault();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await this._inventoryDbContext.Products
                .FromSqlRaw("EXEC Inventory_Product_GetAll")
                .ToListAsync() ?? new List<Product>();
        }

        public async Task<bool> UpdateProduct(Guid productId, UpdateProductDTO newProduct)
        {
            Product? product = await this.GetProductById(productId);

            if (product == null)
            {
                return false;
            }

            string id = "@Id = " + $"'{productId}'";
            string name = "@Name = " + $"'{newProduct.Name}'";
            string price = "@Price = " + newProduct.Price.ToString();
            string description = "@Description = " + $"'{newProduct.Description}'";
            string status = "@Status = " + 1;
            string createdAt = "@CreatedAt = " + $"'{product.CreatedAt.ToString()}'";
            string updatedAt = "@UpdatedAt = " + $"'{DateTime.Now.ToString()}'";

            string execString = $"{id}, {name}, {price}, {description}, {status}, {createdAt}, {updatedAt}";

            return await this._inventoryDbContext.Database
                .ExecuteSqlRawAsync($"Inventory_Product_Update {execString}") > 0;
        }
    }
}
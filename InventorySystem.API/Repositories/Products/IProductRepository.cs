using InventorySystem.API.DTOs;
using InventorySystem.API.Models;

namespace InventorySystem.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(Guid productId);
        Task<bool> AddProduct(Product newProduct);
        Task<bool> UpdateProduct(Guid productId, UpdateProductDTO newProduct);
        Task<bool> DeleteProductById(Guid productId);
    }
}
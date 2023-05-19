using InventorySystem.Web.Models;
using InventorySystem.Web.ViewModels;

namespace InventorySystem.Web.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(Guid productId);
        Task<bool> AddProduct(Product newProduct);
        Task<bool> UpdateProduct(Guid productId, UpdateProductViewModel newProduct);
        Task<bool> DeleteProductById(Guid productId);
    }
}
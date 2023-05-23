using System.Text;
using InventorySystem.Web.Models;
using InventorySystem.Web.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace InventorySystem.Web.Repositories.Products
{
    public class ProductApiRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _appConfig;

        public ProductApiRepository(HttpClient httpClient, IConfiguration appConfig)
        {
            this._appConfig = appConfig;
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri("http://localhost:5257");
            this._httpClient.DefaultRequestHeaders.Add("ApiKey", this._appConfig.GetValue<string>("ApiKey"));
        }

        public async Task<bool> AddProduct(Product newProduct)
        {
            string productData = JsonConvert.SerializeObject(newProduct);
            StringContent content = new StringContent(productData, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PostAsync("api/product/create", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductById(Guid productId)
        {
            var response = await this._httpClient.DeleteAsync($"api/product/delete/{productId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            HttpResponseMessage response = await this._httpClient.GetAsync($"api/product/get/{productId}");

            if (!response.IsSuccessStatusCode) return null;

            string data = await response.Content.ReadAsStringAsync();
            Product product = JsonConvert.DeserializeObject<Product>(data);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            HttpResponseMessage response = await this._httpClient.GetAsync("api/product/all");

            if (!response.IsSuccessStatusCode) return null;

            string data = await response.Content.ReadAsStringAsync();
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(data);
            return products;
        }

        public async Task<bool> UpdateProduct(Guid productId, UpdateProductViewModel newProduct)
        {
            Product product = await this.GetProductById(productId);

            if (product == null) return false;

            string productData = JsonConvert.SerializeObject(newProduct);
            StringContent content = new StringContent(productData, Encoding.UTF8, "application/json");

            var response = await this._httpClient.PutAsync("api/product/update", content);

            return response.IsSuccessStatusCode;
        }
    }
}
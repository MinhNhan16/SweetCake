using SweetCakeFrontend.Models;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class ProductService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }
        public async Task<List<Account>> GetAllAccountsAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Account>>($"{_backendUrl}/account");
                return response ?? new List<Account>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching accounts: {ex.Message}");
                return new List<Account>();
            }
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>($"{_backendUrl}/product");
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"{_backendUrl}/product/{id}");
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/product", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}/product/{id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_backendUrl} /product/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

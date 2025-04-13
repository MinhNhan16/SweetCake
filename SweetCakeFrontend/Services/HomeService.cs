using SweetCakeFrontend.Models;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class HomeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _backendUrl;

        public HomeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }

        public async Task<List<Product>> GetProductsAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<List<Product>>($"{_backendUrl}/products");

            return response ?? new List<Product>();
        }
    }
}

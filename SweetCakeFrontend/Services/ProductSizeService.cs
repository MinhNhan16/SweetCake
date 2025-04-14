using SweetCakeFrontend.Models;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class ProductSizeService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public ProductSizeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }


        public async Task<List<ProductSize>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductSize>>($"{_backendUrl}/productsize") ?? new List<ProductSize>();
        }

        public async Task<ProductSize?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductSize>($"{_backendUrl}/productsize/{id}");
        }

        public async Task<bool> CreateAsync(ProductSize productSize)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/productsize", productSize);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(ProductSize productSize)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_backendUrl} /productsize/{productSize.Id}", productSize);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_backendUrl} /productsize/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

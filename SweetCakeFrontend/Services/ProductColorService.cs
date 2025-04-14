using SweetCakeFrontend.Models;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class ProductColorService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public ProductColorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }

        public async Task<List<ProductColor>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductColor>>($"{_backendUrl}/productcolor");
        }

        public async Task<ProductColor> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductColor>($"{_backendUrl}/productcolor/{id}");
        }

        public async Task CreateAsync(ProductColor productColor)
        {
            await _httpClient.PostAsJsonAsync($"{_backendUrl}/productcolor", productColor);
        }

        public async Task UpdateAsync(ProductColor productColor)
        {
            await _httpClient.PutAsJsonAsync($"{_backendUrl}/productcolor/{productColor.Id}", productColor);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"{_backendUrl}/productcolor/{id}");
        }
    }
}

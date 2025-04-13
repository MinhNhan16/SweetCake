using SweetCakeFrontend.Models;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class CategoryService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>($"{_backendUrl}/category");
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/category", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Category>();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_backendUrl}/category/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<Category?> UpdateCategoryAsync(Category category)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}/category/{category.Id}", category);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Category>();
            }
            return null;
        }

    }
}

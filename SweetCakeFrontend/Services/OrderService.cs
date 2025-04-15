using SweetCakeFrontend.DTO;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class OrderService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDto>>($"{_backendUrl}/order");
        }

        public async Task<OrderDto?> GetByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDto>($"{_backendUrl}/order/{id}");
        }

        public async Task<bool> CreateAsync(OrderDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/order", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(string id, OrderDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}/order/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{_backendUrl}/order/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}

using SweetCakeFrontend.DTO;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class CartService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }

        // Lấy giỏ hàng của người dùng theo AccountId
        public async Task<List<CartDto>?> GetCartsByAccountIdAsync(int accountId)
        {
            return await _httpClient.GetFromJsonAsync<List<CartDto>>($"{_backendUrl}/cart/user/{accountId}");
        }

        // Lấy giỏ hàng theo ID
        public async Task<CartDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CartDto>($"{_backendUrl}/cart/{id}");
        }

        // Tạo giỏ hàng mới
        public async Task<bool> CreateAsync(CartDto cart)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/cart", cart);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to create cart: {response.StatusCode}, {errorContent}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating cart: {ex.Message}");
                return false;
            }
        }

        // Cập nhật giỏ hàng
        public async Task<bool> UpdateAsync(CartDto cart)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}/cart/{cart.Id}", cart);
            return response.IsSuccessStatusCode;
        }

        // Xóa giỏ hàng
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_backendUrl}/cart/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

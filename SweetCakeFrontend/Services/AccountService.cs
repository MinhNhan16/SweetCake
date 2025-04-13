using SweetCakeFrontend.Models;
using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class AccountService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient, IConfiguration configuration)
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

        public async Task<List<Account>> GetDeletedAccountsAsync()
        {
            try
            {
                var accounts = await _httpClient.GetFromJsonAsync<List<Account>>($"{_backendUrl}/account/deleted");
                return accounts ?? new List<Account>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching deleted accounts: {ex.Message}");
                return new List<Account>();
            }
        }

        public async Task CreateAccountAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/account/create", request);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi khi thêm tài khoản: {error}");
            }
        }

        public async Task UpdateAccountAsync(int id, RegisterRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}/account/{id}", request);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi khi cập nhật tài khoản: {error}");
            }
        }

        public async Task DeleteAccountAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_backendUrl}/account/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi khi xóa tài khoản: {error}");
            }
        }

    }
}

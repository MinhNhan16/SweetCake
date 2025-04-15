using System.Net.Http.Json;

namespace SweetCakeFrontend.Services
{
    public class StatisticsService
    {
        private readonly string _backendUrl;
        private readonly HttpClient _httpClient;

        public StatisticsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/statistics/revenue");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<decimal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total revenue: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetTotalCustomersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/statistics/customers");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total customers: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetTotalOrdersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/statistics/orders");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total orders: {ex.Message}");
                throw;
            }
        }

        public async Task<Dictionary<string, decimal>> GetRevenueTrendAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/statistics/revenue-trend");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<Dictionary<string, decimal>>();
                return result ?? new Dictionary<string, decimal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching revenue trend: {ex.Message}");
                throw;
            }
        }

        public async Task<Dictionary<string, int>> GetOrderStatusDistributionAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/statistics/order-status");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();
                return result ?? new Dictionary<string, int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching order status distribution: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TopCustomer>> GetTopCustomersAsync(int topN = 5)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/statistics/top-customers/{topN}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<List<TopCustomer>>();
                return result ?? new List<TopCustomer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching top customers: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TopProduct>> GetTopProductsAsync(int topN = 5)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/statistics/top-products/{topN}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<List<TopProduct>>();
                return result ?? new List<TopProduct>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching top products: {ex.Message}");
                throw;
            }
        }
    }

    public class TopCustomer
    {
        public string Username { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal TotalSpent { get; set; }
    }

    public class TopProduct
    {
        public string ProductName { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
    }
}


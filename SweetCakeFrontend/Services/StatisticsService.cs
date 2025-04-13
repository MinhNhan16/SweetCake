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
                var response = await _httpClient.GetFromJsonAsync<decimal>($"{_backendUrl}/statistics/revenue");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total revenue: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> GetTotalCustomersAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<int>($"{_backendUrl}/statistics/customers");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total customers: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> GetTotalOrdersAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<int>($"{_backendUrl}/statistics/orders");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total orders: {ex.Message}");
                return 0;
            }
        }

        public async Task<Dictionary<string, decimal>> GetRevenueTrendAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Dictionary<string, decimal>>($"{_backendUrl}/statistics/revenue-trend");
                return response ?? new Dictionary<string, decimal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching revenue trend: {ex.Message}");
                return new Dictionary<string, decimal>();
            }
        }

        public async Task<Dictionary<string, int>> GetOrderStatusDistributionAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Dictionary<string, int>>($"{_backendUrl}/statistics/order-status");
                return response ?? new Dictionary<string, int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching order status distribution: {ex.Message}");
                return new Dictionary<string, int>();
            }
        }

        public async Task<List<TopCustomer>> GetTopCustomersAsync(int topN = 5)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<TopCustomer>>($"{_backendUrl}/statistics/top-customers/{topN}");
                return response ?? new List<TopCustomer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching top customers: {ex.Message}");
                return new List<TopCustomer>();
            }
        }

        public async Task<List<TopProduct>> GetTopProductsAsync(int topN = 5)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<TopProduct>>($"{_backendUrl}/statistics/top-products/{topN}");
                return response ?? new List<TopProduct>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching top products: {ex.Message}");
                return new List<TopProduct>();
            }
        }
    }

    // Models for the statistics
    public class TopCustomer
    {
        public string Username { get; set; }
        public string ProductName { get; set; }
        public decimal TotalSpent { get; set; }
    }

    public class TopProduct
    {
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
    }
}


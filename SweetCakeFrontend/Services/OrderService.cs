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
        public async Task<bool> CreateOrderAsync(int accountId, List<CartDto> carts, string paymentMode, int addressId)
        {
            var request = new OrderCreateRequest
            {
                AccountId = accountId,
                AddressId = addressId, // Bạn có thể lấy từ user profile hoặc tạm hardcode
                PaymentMode = paymentMode switch
                {
                    "CreditCard" => "VNPAY",
                    "PayPal" => "M0M0",
                    "CashOnDelivery" => "Thanh toán bằng tiền mặt",
                    _ => ""
                },
                Carts = carts
            };

            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/order/create", request);
            return response.IsSuccessStatusCode;
        }


        public async Task<OrderDto?> GetLatestOrderAsync(int accountId)
        {
            return await _httpClient.GetFromJsonAsync<OrderDto>($"{_backendUrl}/order/latest/{accountId}");
        }
        public async Task<OrderDto> GetOrderByAccountIdAsync(int accountId)
        {
            // Call your API or service to get the order details by AccountId
            // For example, let's assume you make an HTTP request to an API endpoint:
            var response = await _httpClient.GetAsync($"{_backendUrl}/order/account/{accountId}");

            if (response.IsSuccessStatusCode)
            {
                var order = await response.Content.ReadFromJsonAsync<OrderDto>();
                return order;
            }

            // If the request fails, you can handle the error here (e.g., throw an exception or return null)
            return null;
        }

    }
}

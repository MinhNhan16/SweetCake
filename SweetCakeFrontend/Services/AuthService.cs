using Blazored.LocalStorage;
using Newtonsoft.Json;
using SweetCakeFrontend.Models;
using SweetCakeFrontend.Models.Response;
using SweetCakeFrontend.Provider;
using System.Net.Http.Json;
using System.Security.Claims;

namespace SweetCakeFrontend.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _backendUrl;
        private readonly ILocalStorageService _localStorage;
        private readonly JwtAuthenticationStateProvider _jwtAuthenticationStateProvider;

        public AuthService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorageService, JwtAuthenticationStateProvider jwtAuthenticationStateProvider)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["BackendUrl"] ?? throw new ArgumentNullException(nameof(configuration), "BackendUrl is not configured");
            _localStorage = localStorageService;
            _jwtAuthenticationStateProvider = jwtAuthenticationStateProvider;
        }


        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentNullException(nameof(loginModel));
            }

            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/account/login", loginModel);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(json);

            await _localStorage.SetItemAsync("accessToken", loginResponse.Token);
            _jwtAuthenticationStateProvider.NotifyUserAuthentication(loginResponse.Token);
            return true;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("accessToken");
            _jwtAuthenticationStateProvider.NotifyUserLogout();
        }

        public async Task<string> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>("accessToken");
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var authState = await _jwtAuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity?.IsAuthenticated ?? false)
            {
                var idString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int.TryParse(idString, out int userId);

                return new User
                {
                    Id = userId,
                    Username = user.Identity.Name ?? "",
                    Email = user.FindFirst(ClaimTypes.Email)?.Value ?? "",
                    Role = user.FindFirst(ClaimTypes.Role)?.Value ?? ""
                };
            }

            return null;
        }
    }
}

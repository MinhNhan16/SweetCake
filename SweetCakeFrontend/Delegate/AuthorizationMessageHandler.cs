using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace SweetCakeFrontend.Delegate
{

    public class AuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public AuthorizationMessageHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _localStorage.GetItemAsync<string>("accessToken");

                if (!string.IsNullOrWhiteSpace(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"AuthorizationMessageHandler ERROR", ex.Message);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}

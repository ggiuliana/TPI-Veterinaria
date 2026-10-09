using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        protected readonly IAuthService _authService;

        protected BaseApiClient(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        protected async Task<HttpClient> CreateHttpClientAsync()
        {
            var client = new HttpClient();
            await ConfigureHttpClientAsync(client);
            return client;
        }

        protected async Task ConfigureHttpClientAsync(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5124/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            await AddAuthorizationHeaderAsync(client);
        }

        protected async Task AddAuthorizationHeaderAsync(HttpClient client)
        {
            await _authService.CheckTokenExpirationAsync();

            var token = await _authService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        protected async Task EnsureAuthenticatedAsync()
        {
            await _authService.CheckTokenExpirationAsync();

            if (!await _authService.IsAuthenticatedAsync())
            {
                throw new UnauthorizedAccessException("Su sesión ha expirado.");
            }
        }

        protected async Task HandleUnauthorizedResponseAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _authService.LogoutAsync();
                throw new UnauthorizedAccessException("Su sesión ha expirado.");
            }
        }
    }
}
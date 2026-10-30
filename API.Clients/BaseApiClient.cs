using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        protected readonly IAuthService _authService;
        private readonly string _baseUrl;

        protected BaseApiClient(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            var baseUrl = configuration["ApiConfig:BaseUrl"];

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var baseAddress) ||
                (baseAddress.Scheme != Uri.UriSchemeHttp && baseAddress.Scheme != Uri.UriSchemeHttps))
            {
                throw new InvalidOperationException(
                    "Falta una URL HTTP/HTTPS válida en ApiConfig:BaseUrl.");
            }

            _baseUrl = baseAddress.AbsoluteUri.EndsWith('/')
                ? baseAddress.AbsoluteUri
                : $"{baseAddress.AbsoluteUri}/";
        }

        protected async Task<HttpClient> CreateHttpClientAsync()
        {
            var client = new HttpClient();
            await ConfigureHttpClientAsync(client);
            return client;
        }

        protected async Task ConfigureHttpClientAsync(HttpClient client)
        {
            client.BaseAddress = new Uri(_baseUrl);
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
                await _authService.LogoutAsync();
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
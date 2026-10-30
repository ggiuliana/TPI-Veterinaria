using DTOs;
using API.Clients;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private string? _currentToken;
        private DateTime _tokenExpiration;
        private string? _currentUsername;
        private string? _currentRol;
        private int? _currentPersonaId;

        public WindowsFormsAuthService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public event Action<bool>? AuthenticationStateChanged;

        public Task InitializeSessionAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<int?> GetPersonaIdAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentPersonaId : null;
        }
        public Task<bool> IsAuthenticatedAsync()
        {
            return Task.FromResult(!string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow < _tokenExpiration);
        }

        public async Task<string?> GetTokenAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentToken : null;
        }

        public async Task<string?> GetUsernameAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentUsername : null;
        }

        public async Task<string?> GetRolAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentRol : null;
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                NombreUsuario = username,
                Contrasenia = password
            };

            var authClient = new AuthApiClient(this, _configuration);
            var response = await authClient.LoginAsync(request);

            if (response != null)
            {
                _currentToken = response.Token;
                _tokenExpiration = response.ExpiresAt;
                _currentUsername = response.Username;
                _currentRol = response.Rol;
                _currentPersonaId = response.IdPersona;

                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public Task LogoutAsync()
        {
            _currentToken = null;
            _tokenExpiration = default;
            _currentUsername = null;
            _currentPersonaId = null;

            AuthenticationStateChanged?.Invoke(false);
            return Task.CompletedTask;
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow >= _tokenExpiration)
            {
                await LogoutAsync();
            }
        }

        public async Task<bool> HasPermissionAsync(string permission)
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token))
                return false;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                var permissionClaims = jsonToken.Claims
                    .Where(c => c.Type == "permission")
                    .Select(c => c.Value);

                return permissionClaims.Contains(permission);
            }
            catch
            {
                return false;
            }
        }
    }
}
using DTOs;
using API.Clients;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace API.Auth.Blazor.Server
{
    public class BlazorServerAuthService : AuthenticationStateProvider, IAuthService
    {
        private SessionData? _currentSession;

        public event Action<bool>? AuthenticationStateChanged;

        private readonly IServiceProvider _serviceProvider;

        public BlazorServerAuthService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private class SessionData
        {
            public string? Token { get; set; }
            public string? Username { get; set; }
            public DateTime Expiration { get; set; }
            public string? Rol { get; set; }
            public int? PersonaId { get; set; }
        }

        public Task<int?> GetPersonaIdAsync()
        {
            try
            {
                return Task.FromResult(_currentSession?.PersonaId);
            }
            catch
            {
                return Task.FromResult<int?>(null);
            }
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            if (_currentSession != null && !string.IsNullOrEmpty(_currentSession.Token) && _currentSession.Expiration > DateTime.UtcNow)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(_currentSession.Token);

                var claims = jwtToken.Claims.ToList();

                if (!string.IsNullOrEmpty(_currentSession.Rol))
                {
                    claims.Add(new Claim(ClaimTypes.Role, _currentSession.Rol));
                }

                identity = new ClaimsIdentity(claims, "jwtAuth");
            }

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        public void NotificarLoginExitoso()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void NotificarLogout()
        {
            _currentSession = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                if (_currentSession != null)
                {
                    return Task.FromResult(!string.IsNullOrEmpty(_currentSession.Token) && DateTime.UtcNow < _currentSession.Expiration);
                }
                return Task.FromResult(false);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<string?> GetTokenAsync()
        {
            try { return Task.FromResult(_currentSession?.Token); }
            catch { return Task.FromResult<string?>(null); }
        }

        public Task<string?> GetUsernameAsync()
        {
            try { return Task.FromResult(_currentSession?.Username); }
            catch { return Task.FromResult<string?>(null); }
        }

        public Task<string?> GetRolAsync()
        {
            try { return Task.FromResult(_currentSession?.Rol); }
            catch { return Task.FromResult<string?>(null); }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                NombreUsuario = username,
                Contrasenia = password
            };

            var authClient = _serviceProvider.GetRequiredService<AuthApiClient>();
            var response = await authClient.LoginAsync(request);

            if (response != null)
            {
                _currentSession = new SessionData
                {
                    Token = response.Token,
                    Username = response.Username,
                    Expiration = response.ExpiresAt,
                    Rol = response.Rol
                };

                AuthenticationStateChanged?.Invoke(true);
                NotificarLoginExitoso();
                return true;
            }

            return false;
        }

        public Task LogoutAsync()
        {
            _currentSession = null;
            AuthenticationStateChanged?.Invoke(false);
            NotificarLogout();
            return Task.CompletedTask;
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!await IsAuthenticatedAsync())
            {
                await LogoutAsync();
            }
        }

        public Task<bool> HasPermissionAsync(string permission)
        {
            try
            {
                var token = _currentSession?.Token;
                if (string.IsNullOrEmpty(token))
                    return Task.FromResult(false);

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                var permissionClaims = jsonToken.Claims
                    .Where(c => c.Type == "permission")
                    .Select(c => c.Value);

                return Task.FromResult(permissionClaims.Contains(permission));
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
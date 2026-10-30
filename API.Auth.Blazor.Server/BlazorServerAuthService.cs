using API.Clients;
using DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Auth.Blazor.Server
{
    public class BlazorServerAuthService : AuthenticationStateProvider, IAuthService
    {
        private SessionData? _currentSession;

        public new event Action<bool>? AuthenticationStateChanged;

        private readonly IServiceProvider _serviceProvider;

        private readonly ProtectedSessionStorage _sessionStorage;

        public BlazorServerAuthService(IServiceProvider serviceProvider, ProtectedSessionStorage sessionStorage)
        {
            _serviceProvider = serviceProvider;
            _sessionStorage = sessionStorage;
        }

        public class SessionData
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

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            try
            {
                if (_currentSession == null)
                {
                    var result = await _sessionStorage.GetAsync<SessionData>("UserSession");
                    if (result.Success && result.Value != null)
                    {
                        _currentSession = result.Value;
                    }
                }
            }
            catch
            {
            }

            if (_currentSession != null && !string.IsNullOrEmpty(_currentSession.Token) && _currentSession.Expiration > DateTime.UtcNow)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(_currentSession.Token);
                var claims = jwtToken.Claims.ToList();

                if (!string.IsNullOrEmpty(_currentSession.Rol))
                {
                    claims.Add(new Claim(ClaimTypes.Role, _currentSession.Rol.Trim()));
                }
                identity = new ClaimsIdentity(claims, "jwtAuth");
            }
            else
            {
                _currentSession = null;
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task InitializeSessionAsync()
        {
            try
            {
                var result = await _sessionStorage.GetAsync<SessionData>("UserSession");
                if (result.Success && result.Value != null)
                {
                    _currentSession = result.Value;

                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

                    AuthenticationStateChanged?.Invoke(true);
                }
            }
            catch
            {
            }
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

            if (response == null || string.IsNullOrEmpty(response.Token))
            {
                return false;
            }

            var session = new SessionData
            {
                Token = response.Token,
                Username = response.Username,
                Expiration = response.ExpiresAt,
                Rol = response.Rol,
                PersonaId = response.IdPersona
            };

            _currentSession = session;
            await _sessionStorage.SetAsync("UserSession", session);

            AuthenticationStateChanged?.Invoke(true);
            NotificarLoginExitoso();

            return true;
        }

        public async Task LogoutAsync()
        {
            _currentSession = null;
            await _sessionStorage.DeleteAsync("UserSession");
            AuthenticationStateChanged?.Invoke(false);
            NotificarLogout();
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (_currentSession != null && !await IsAuthenticatedAsync())
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
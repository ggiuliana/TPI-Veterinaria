using Data;
using DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModeloDominio;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace ServiciosApp
{
    public class AuthService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IConfiguration configuration;

        public AuthService(IUsuarioRepository usuarioRepo, IConfiguration config)
        {
            usuarioRepository = usuarioRepo;
            configuration = config;
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NombreUsuario) || string.IsNullOrWhiteSpace(request.Contrasenia))
                return null;

            var usuario = await usuarioRepository.GetByUsernameAsync(request.NombreUsuario);

            if (usuario == null || usuario.Contrasenia != HashPassword(request.Contrasenia.Trim()))
                return null;

            var token = GenerateJwtToken(usuario);
            var expiresAt = DateTime.UtcNow.AddMinutes(GetExpirationMinutes());

            return new LoginResponse
            {
                Token = token,
                ExpiresAt = expiresAt,
                Username = usuario.NombreUsuario,
                Rol = usuario?.Grupo?.Nombre,
                IdPersona = usuario?.IdPersona
            };
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new (ClaimTypes.Name, usuario.NombreUsuario),
                new ("jti", Guid.NewGuid().ToString())
            };

            if (usuario.IdPersona != null)
            {
                claims.Add(new Claim("PersonaId", usuario.IdPersona.ToString()!));
            }

            var permisos = usuario.ObtenerTodosLosPermisos();
            foreach (var permiso in permisos)
            {
                claims.Add(new Claim("permission", permiso));
            }

            var grupo = usuario.ObtenerNombreGrupo();
            if (!string.IsNullOrEmpty(grupo))
            {
                claims.Add(new Claim(ClaimTypes.Role, grupo));
                claims.Add(new Claim("group", grupo));
            }

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(GetExpirationMinutes()),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private int GetExpirationMinutes()
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            if (int.TryParse(jwtSettings["ExpirationMinutes"], out int minutes))
                return minutes;
            return 60;
        }
    }
}
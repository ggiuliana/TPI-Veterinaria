using ModeloDominio;

namespace DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public string EstadoUsuario { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
    }
}

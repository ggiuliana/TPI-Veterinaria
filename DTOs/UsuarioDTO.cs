namespace DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string EstadoUsuario { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public int IdPersona { get; set; }
    }

    public class UsuarioCreateDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public int IdPersona { get; set; }
        public int IdGrupo { get; set; }
    }

    public class UsuarioUpdateDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string? Contrasenia { get; set; } = string.Empty;
        public string EstadoUsuario { get; set; } = string.Empty;
    }
}

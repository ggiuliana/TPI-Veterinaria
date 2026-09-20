   namespace ModeloDominio
{
    public class Usuario
    {
        public int IdUsuario { get; private set; }
        public string NombreUsuario { get; private set; } = string.Empty;
        public string Contrasenia { get; private set; } = string.Empty;
        public string EstadoUsuario { get; private set; } = string.Empty;
        public DateTime FechaAlta { get; private set; }
        public int? IdPersona { get; private set; }
        public Persona? Persona { get; private set; }
        public int? GrupoPermisoId { get; private set; }
        public virtual GrupoPermiso? Grupo { get; private set; }

        public Usuario(int idUsuario, string nombreUsuario, string contrasenia, string estadoUsuario) {
            SetIdUsuario(idUsuario);
            SetNombreUsuario(nombreUsuario);
            SetContrasenia(contrasenia);
            SetEstadoUsuario(estadoUsuario);
        }
        public Usuario(int idUsuario, string nombreUsuario, string contrasenia, string estadoUsuario, Persona? persona, GrupoPermiso? grupo)
        {
            SetIdUsuario(idUsuario);
            SetNombreUsuario(nombreUsuario);
            SetContrasenia(contrasenia);
            SetEstadoUsuario(estadoUsuario);
            SetPersona(persona);
            SetGrupo(grupo);
        }
        public void SetIdUsuario(int idUsuario)
        {
            if (idUsuario < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(idUsuario));
            IdUsuario = idUsuario;
        }

        public void SetNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.", nameof(nombreUsuario));
            NombreUsuario = nombreUsuario;
        }
        public void SetContrasenia(string contrasenia)
        {
            if (string.IsNullOrWhiteSpace(contrasenia))
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(contrasenia));
            if (contrasenia.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            Contrasenia = contrasenia;

        }
        public void SetEstadoUsuario(string estadoUsuario)
        {
            if (string.IsNullOrWhiteSpace(estadoUsuario))
                throw new ArgumentException("El estado no puede estar vacío.");
            string estadoLimpio = estadoUsuario.Trim().ToLower();
            if (estadoLimpio != "activo" && estadoLimpio != "inactivo")
                throw new ArgumentException("El estado del usuario debe ser estrictamente 'Activo' o 'Inactivo'.");
            EstadoUsuario = estadoLimpio == "activo" ? "Activo" : "Inactivo";
        }
        public void SetPersona(Persona? persona)
        {
            if (persona == null)
                throw new ArgumentNullException(nameof(persona), "La persona no puede ser nula.");
            Persona = persona;

        }

        public void SetGrupo(GrupoPermiso? grupo)
        { 
            if(grupo == null)
                throw new ArgumentNullException(nameof(grupo), "El grupo no puede ser nulo.");
            Grupo = grupo;
        }

        public bool TienePermiso(string nombrePermiso)
        {
            if (EstadoUsuario == "Inactivo" || Grupo == null || !Grupo.Activo)
                return false;

            return Grupo.TienePermiso(nombrePermiso);
        }

        public IEnumerable<string> ObtenerTodosLosPermisos()
        {
            if (Grupo == null || !Grupo.Activo)
                return new List<string>();

            return Grupo.ObtenerNombresPermisos();
        }

        public string? ObtenerNombreGrupo()
        {
            return Grupo?.Nombre;
        }
    }
}
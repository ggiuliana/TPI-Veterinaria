using Data;
using ModeloDominio;

namespace ServiciosApp
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public static readonly List<Usuario> usuarios = new();
        private static int nextId = 1;
        public Task AddAsync(Usuario usuario)
        {
            usuario.SetIdUsuario(nextId);
            nextId++;
            usuarios.Add(usuario);

            return Task.CompletedTask;
        }
        public Task<bool> DeleteAsync(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
                return Task.FromResult(false);
            usuarios.Remove(usuario);
            return Task.FromResult(true);
        }

        public Task<Usuario?> GetAsync(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
            return Task.FromResult(usuario);
        }
        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return Task.FromResult(usuarios.AsEnumerable());
        }
        public Task<bool> UpdateAsync(Usuario usuario)
        {
            var existingUsuario = usuarios.FirstOrDefault(u => u.IdUsuario == usuario.IdUsuario);
            if (existingUsuario == null)
                return Task.FromResult(false);

            existingUsuario.SetNombreUsuario(usuario.NombreUsuario);
            existingUsuario.SetContrasenia(usuario.Contrasenia);
            existingUsuario.SetEstadoUsuario(usuario.EstadoUsuario);
            existingUsuario.SetFechaAlta(usuario.FechaAlta);
            existingUsuario.SetPersona(usuario.Persona);

            return Task.FromResult(true);
        }
        public Task<bool> NombreUsuarioExistsAsync(string nombreUsuario, int? excludeId = null)
        {
            var exists = usuarios.Where(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());

            if (excludeId.HasValue)
            {
                exists = exists.Where(u => u.IdUsuario != excludeId.Value);
            }

            return Task.FromResult(exists.Any());
        }
        public Task<bool> PersonaHasUsuarioAsync(int idPersona, int? excludeIdUsuario = null)
        {
            var exists = usuarios.Where(u => u.Persona != null && u.Persona.IdPersona == idPersona);

            if (excludeIdUsuario.HasValue)
                exists = exists.Where(u => u.IdUsuario != excludeIdUsuario.Value);

            return Task.FromResult(exists.Any());
        }
    }
}

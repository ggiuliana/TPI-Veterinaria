using Data;
using ModeloDominio;
using Microsoft.EntityFrameworkCore;

namespace ServiciosApp
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VeterinariaContext context;

        public UsuarioRepository(VeterinariaContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Usuario usuario, Persona persona, Rol rol)
        {
            usuario.SetPersona(persona);
            usuario.SetRol(rol);
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Usuario?> GetAsync(int id)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await context.Usuarios.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == usuario.IdUsuario);
            if (existingUsuario != null)
            {
                existingUsuario.SetNombreUsuario(usuario.NombreUsuario);
                existingUsuario.SetContrasenia(usuario.Contrasenia);
                existingUsuario.SetEstadoUsuario(usuario.EstadoUsuario);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> NombreUsuarioExistsAsync(string nombreUsuario, int? excludeId = null)
        {
            var query = context.Usuarios.Where(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(u => u.IdUsuario != excludeId.Value);
            }

            return await query.AnyAsync();
        }
        public async Task<bool> PersonaHasUsuarioAsync(int idPersona, int? excludeIdUsuario = null)
        {
            var query = context.Usuarios.Where(u => u.Persona != null && u.Persona.IdPersona == idPersona);

            if (excludeIdUsuario.HasValue)
            {
                query = query.Where(u => u.IdUsuario != excludeIdUsuario.Value);
            }

            return await query.AnyAsync();
        }
    }
}

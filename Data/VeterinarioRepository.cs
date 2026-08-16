using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly VeterinariaContext context;

        public VeterinarioRepository(VeterinariaContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Veterinario Veterinario)
        {
            context.Veterinarios.Add(Veterinario);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var Veterinario = await context.Veterinarios.FindAsync(id);
            if (Veterinario != null)
            {
                context.Veterinarios.Remove(Veterinario);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Veterinario?> GetAsync(int id)
        {
            return await context.Veterinarios.FirstOrDefaultAsync(v => v.IdPersona == id); ;
        }
        public async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return await context.Veterinarios.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Veterinario Veterinario)
        {
            var existingVeterinario = await context.Veterinarios.FindAsync(Veterinario.IdPersona);
            if (existingVeterinario != null)
            {
                existingVeterinario.SetNombrePersona(Veterinario.NombrePersona);
                existingVeterinario.SetApellido(Veterinario.Apellido);
                existingVeterinario.SetMail(Veterinario.Mail);
                existingVeterinario.SetTelefono(Veterinario.Telefono);
                existingVeterinario.SetDni(Veterinario.Dni);
                existingVeterinario.SetDireccion(Veterinario.Direccion);
                existingVeterinario.SetMatricula(Veterinario.Matricula);
                existingVeterinario.SetEspecialidad(Veterinario.Especialidad);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            var query = context.Veterinarios.Where(v => v.Mail.ToLower() == mail.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdPersona != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<bool> MatriculaExistsAsync(string matricula, int? excludeId = null)
        {
            var query = context.Veterinarios.Where(v => v.Matricula.ToLower() == matricula.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(v => v.IdPersona != excludeId.Value);
            }
            return await query.AnyAsync();
        }
    }
}

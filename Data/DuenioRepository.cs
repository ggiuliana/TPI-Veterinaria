using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class DuenioRepository : IDuenioRepository
    {
        private readonly VeterinariaContext context;

        public DuenioRepository(VeterinariaContext context) {
            this.context = context;
        } 
        public async Task AddAsync(Duenio duenio)
        {
            context.Duenios.Add(duenio);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var duenio = await context.Duenios.FindAsync(id);
            if (duenio != null) {
                context.Duenios.Remove(duenio);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Duenio?> GetAsync(int id)
        {
            return await context.Duenios.FirstOrDefaultAsync(c => c.IdPersona == id); ;
        }
        public async Task<IEnumerable<Duenio>> GetAllAsync()
        {
            return await context.Duenios.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Duenio duenio)
        {
            var existingDuenio = await context.Duenios.FindAsync(duenio.IdPersona);
            if (existingDuenio != null)
            {
                existingDuenio.SetNombrePersona(duenio.NombrePersona);
                existingDuenio.SetApellido(duenio.Apellido);
                existingDuenio.SetMail(duenio.Mail);
                existingDuenio.SetTelefono(duenio.Telefono);
                existingDuenio.SetDni(duenio.Dni);
                existingDuenio.SetDireccion(duenio.Direccion);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            var query = context.Duenios.Where(d => d.Mail.ToLower() == mail.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.IdPersona != excludeId.Value);
            }
            return await query.AnyAsync();
        }
    }
}

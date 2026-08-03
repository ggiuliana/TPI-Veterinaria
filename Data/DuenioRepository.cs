using ModeloDominio;
namespace Data
{
    public class DuenioRepository : IDuenioRepository
    {
        public static readonly List<Duenio> duenios = new();
        private static int nextId = 1;
        public Task AddAsync(Duenio duenio)
        {
            duenio.IdPersona = nextId;
            nextId++;
            duenios.Add(duenio);
            return Task.CompletedTask;
        }
        public Task<bool> DeleteAsync(int id)
        {
            var duenio = duenios.FirstOrDefault(d => d.IdPersona == id);
            if (duenio != null)
            {
                duenios.Remove(duenio);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<Duenio?> GetAsync(int id)
        {
            return Task.FromResult(duenios.FirstOrDefault(d => d.IdPersona == id));
        }
        public Task<IEnumerable<Duenio>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Duenio>>(duenios.ToList());
        }
        public Task<bool> UpdateAsync(Duenio duenio)
        {
            var existing = duenios.FirstOrDefault(d => d.IdPersona == duenio.IdPersona);
            if (existing != null)
            {
                existing.SetNombrePersona(duenio.NombrePersona);
                existing.SetApellido(duenio.Apellido);
                existing.SetMail(duenio.Mail);
                existing.SetDireccion(duenio.Direccion);
                existing.SetDni(duenio.Dni);
                existing.SetDireccion(duenio.Direccion);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            var query = duenios.Where(d => d.Mail.ToLower() == mail.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(d => d.IdPersona != excludeId.Value);
            }
            return Task.FromResult(query.Any());
        }
    }
}

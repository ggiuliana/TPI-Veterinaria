using ModeloDominio;
namespace Data
{
    public class DueñoRepository : IDueñoRepository
    {
        public static readonly List<Dueño> dueños = new();
        private static int nextId = 1;
        public Task AddAsync(Dueño dueño)
        {
            dueño.IdPersona = nextId;
            nextId++;
            dueños.Add(dueño);
            return Task.CompletedTask;
        }
        public Task<bool> DeleteAsync(int id)
        {
            var dueño = dueños.FirstOrDefault(d => d.IdPersona == id);
            if (dueño != null)
            {
                dueños.Remove(dueño);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<Dueño?> GetAsync(int id)
        {
            return Task.FromResult(dueños.FirstOrDefault(d => d.IdPersona == id));
        }
        public Task<IEnumerable<Dueño>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Dueño>>(dueños.ToList());
        }
        public Task<bool> UpdateAsync(Dueño dueño)
        {
            var existing = dueños.FirstOrDefault(d => d.IdPersona == dueño.IdPersona);
            if (existing != null)
            {
                existing.SetNombrePersona(dueño.NombrePersona);
                existing.SetApellido(dueño.Apellido);
                existing.SetMail(dueño.Mail);
                existing.SetDireccion(dueño.Direccion);
                existing.SetDni(dueño.Dni);
                existing.SetDireccion(dueño.Direccion);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            var query = dueños.Where(d => d.Mail.ToLower() == mail.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(d => d.IdPersona != excludeId.Value);
            }
            return Task.FromResult(query.Any());
        }
    }
}

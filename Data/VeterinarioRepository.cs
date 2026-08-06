using ModeloDominio;

namespace Data
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        public static readonly List<Veterinario> veterinarios = new();
        private static int nextId = 1;
        public Task AddAsync(Veterinario veterinario)
        {
            veterinario.SetIdPersona(nextId);
            nextId++;
            veterinarios.Add(veterinario);
            return Task.CompletedTask;
        }
        public Task<bool> DeleteAsync(int id)
        {
            var veterinario = veterinarios.FirstOrDefault(v => v.IdPersona == id);
            if (veterinario != null)
            {
                veterinarios.Remove(veterinario);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<Veterinario?> GetAsync(int id)
        {
            return Task.FromResult(veterinarios.FirstOrDefault(v => v.IdPersona == id));
        }
        public Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Veterinario>>(veterinarios.ToList());
        }
        public Task<bool> UpdateAsync(Veterinario veterinario)
        {
            var existing = veterinarios.FirstOrDefault(v => v.IdPersona == veterinario.IdPersona);
            if (existing != null)
            {
                existing.SetNombrePersona(veterinario.NombrePersona);
                existing.SetApellido(veterinario.Apellido);
                existing.SetMail(veterinario.Mail);
                existing.SetDireccion(veterinario.Direccion);
                existing.SetDni(veterinario.Dni);
                existing.SetDireccion(veterinario.Direccion);
                existing.SetMatricula(veterinario.Matricula);
                existing.SetEspecialidad(veterinario.Especialidad);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            var query = veterinarios.Where(v => v.Mail.ToLower() == mail.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(v => v.IdPersona != excludeId.Value);
            }
            return Task.FromResult(query.Any());
        }
        public Task<bool> MatriculaExistsAsync(string matricula, int? excludeId = null)
        {
            var query = veterinarios.Where(v => v.Matricula.ToLower() == matricula.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(v => v.IdPersona != excludeId.Value);
            }
            return Task.FromResult(query.Any());

        }
    }
}

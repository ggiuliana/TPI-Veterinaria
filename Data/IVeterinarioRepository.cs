using ModeloDominio;

namespace Data
{
    public interface IVeterinarioRepository
    {
        Task AddAsync(Veterinario veterinario);
        Task<bool> DeleteAsync(int id);
        Task<Veterinario?> GetAsync(int id);
        Task<IEnumerable<Veterinario>> GetAllAsync();
        Task<bool> UpdateAsync(Veterinario veterinario);
        Task<bool> MailExistsAsync(string mail, int? excludeId = null);
        Task<bool> MatriculaExistsAsync(string matricula, int? excludeId = null);
    }
}
        
    
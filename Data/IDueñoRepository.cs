using ModeloDominio;

namespace Data
{
    public interface IDueñoRepository
    {
        Task AddAsync(Dueño dueño);
        Task<bool> DeleteAsync(int id);
        Task<Dueño?> GetAsync(int id);
        Task<IEnumerable<Dueño>> GetAllAsync();
        Task<bool> UpdateAsync(Dueño dueño);
        Task<bool> MailExistsAsync(string mail, int? excludeId = null);
    }
}
using ModeloDominio;

namespace Data
{
    public interface IDuenioRepository
    {
        Task AddAsync(Duenio duenio);
        Task<bool> DeleteAsync(int id);
        Task<Duenio?> GetAsync(int id);
        Task<IEnumerable<Duenio>> GetAllAsync();
        Task<bool> UpdateAsync(Duenio duenio);
        Task<bool> MailExistsAsync(string mail, int? excludeId = null);
    }
}
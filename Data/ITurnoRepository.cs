using ModeloDominio;

namespace Data
{
    public interface ITurnoRepository
    {
        Task AddAsync(Turno turno);
        Task<Turno?> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Turno>> GetAllAsync();
        Task<bool> UpdateAsync(Turno turno);
    }
}

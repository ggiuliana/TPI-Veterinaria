using ModeloDominio;

namespace Data
{
    public interface ITipoVacunaRepository
    {
        Task AddAsync(TipoVacuna tipovacuna);
        Task<bool> DeleteAsync(int id);
        Task<TipoVacuna?> GetAsync(int id);
        Task<IEnumerable<TipoVacuna>> GetAllAsync();
        Task<bool> UpdateAsync(TipoVacuna tipoVacuna);
        Task<ICollection<TipoVacuna>> GetByIdListAsync(List<int> ids);
    }
}

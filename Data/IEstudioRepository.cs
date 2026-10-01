using ModeloDominio;

namespace Data
{
    public interface IEstudioRepository
    {
        Task AddAsync(Estudio estudio);
        Task<bool> DeleteAsync(int id);
        Task<Estudio?> GetAsync(int id);
        Task<IEnumerable<Estudio>> GetAllAsync();
        Task<bool> UpdateAsync(Estudio estudio);
        Task<ICollection<Estudio>> GetByIdListAsync(ICollection<int> ids);
    }
}

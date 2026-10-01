using ModeloDominio;

namespace Data
{
    public interface IMedicamentoRepository
    {
        Task AddAsync(Medicamento medicamento);
        Task<bool> DeleteAsync(int id);
        Task<Medicamento?> GetAsync(int id);
        Task<IEnumerable<Medicamento>> GetAllAsync();
        Task<bool> UpdateAsync(Medicamento medicamento);
        Task<ICollection<Medicamento>> GetByIdsAsync(IEnumerable<int> ids);
    }
}

using DTOs;

namespace ServiciosApp
{
    public interface ITipoVacunaService
    {
        Task<TipoVacunaDTO> AddAsync(TipoVacunaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<TipoVacunaDTO?> GetAsync(int id);
        Task<IEnumerable<TipoVacunaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(TipoVacunaDTO dto);
    }
}

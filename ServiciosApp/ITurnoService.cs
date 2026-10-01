using DTOs;

namespace ServiciosApp
{
    public interface ITurnoService
    {
        Task<TurnoDTO> AddAsync(TurnoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<TurnoDTO?> GetAsync(int id);
        Task<IEnumerable<TurnoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(TurnoDTO dto);
    }
}

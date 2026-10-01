using DTOs;

namespace ServiciosApp
{
    public interface IEstudioService
    {
        Task<EstudioDTO> AddAsync(EstudioDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<EstudioDTO?> GetAsync(int id);
        Task<IEnumerable<EstudioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(EstudioDTO dto);
    }
}

using DTOs;
using Data;
namespace ServiciosApp
{
    public interface IDueñoService
    {
        Task<DueñoDTO> AddAsync(DueñoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<DueñoDTO?> GetAsync(int id);
        Task<IEnumerable<DueñoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(DueñoDTO dto);
        Task<bool> MailExistsAsync(string mail, int? excludeId = null);
    }
}


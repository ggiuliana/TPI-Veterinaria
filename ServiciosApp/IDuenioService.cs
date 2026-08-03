using DTOs;
using Data;
namespace ServiciosApp
{
    public interface IDuenioService
    {
        Task<DuenioDTO> AddAsync(DuenioDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<DuenioDTO?> GetAsync(int id);
        Task<IEnumerable<DuenioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(DuenioDTO dto);
        Task<bool> MailExistsAsync(string mail, int? excludeId = null);
    }
}


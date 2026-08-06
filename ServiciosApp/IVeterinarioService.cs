using DTOs;
using Data;

namespace ServiciosApp
{
    public interface IVeterinarioService
    {
        Task<VeterinarioDTO> AddAsync(VeterinarioDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<VeterinarioDTO?> GetAsync(int id);
        Task<IEnumerable<VeterinarioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(VeterinarioDTO dto);
        Task<bool> MailExistsAsync(string mail, int? excludeId = null);
        Task<bool> MatriculaExistsAsync(string matricula, int? excludeId = null);
    }
}

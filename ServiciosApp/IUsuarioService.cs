using DTOs;
using Data;

namespace ServiciosApp
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> AddAsync(UsuarioDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<UsuarioDTO?> GetAsync(int id);
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(UsuarioDTO dto);
    }
}

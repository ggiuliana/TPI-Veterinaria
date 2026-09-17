using DTOs;
using Data;

namespace ServiciosApp
{
    public interface IUsuarioService
    {
        Task<UsuarioCreateDTO> AddAsync(UsuarioCreateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<UsuarioResponseDTO?> GetAsync(int id);
        Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync();
        Task<bool> UpdateAsync(UsuarioCreateDTO dto);
        Task<UsuarioResponseDTO?> Login(LoginDTO dto);
        Task<bool> RegisterVetAsync(VeterinarioRegisterDTO dto);
        Task<bool> RegisterDuenioAsync(DuenioRegisterDTO dto);
    }
}

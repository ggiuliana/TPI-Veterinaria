using DTOs;

namespace ServiciosApp
{
    public interface IUsuarioService
    {
        Task<UsuarioCreateDTO> AddAsync(UsuarioCreateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<UsuarioDTO?> GetAsync(int id);
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(UsuarioCreateDTO dto);
        Task<bool> RegisterVetAsync(VeterinarioRegisterDTO dto);
        Task<bool> RegisterDuenioAsync(DuenioRegisterDTO dto);
    }
}

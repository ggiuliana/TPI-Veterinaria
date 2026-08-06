using ModeloDominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
        Task<Usuario?> GetAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<bool> UpdateAsync(Usuario usuario);
        Task<bool> NombreUsuarioExistsAsync(string nombreUsuario, int? excludeId = null);
        Task<bool> PersonaHasUsuarioAsync(int idPersona, int? excludeIdUsuario = null);
    }
}
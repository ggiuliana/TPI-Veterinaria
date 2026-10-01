using ModeloDominio;

namespace Data
{
    public interface IGrupoPermisoRepository
    {
        Task<GrupoPermiso?> GetAsync(int id);
    }
}

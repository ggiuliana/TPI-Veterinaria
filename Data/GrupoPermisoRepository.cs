using ModeloDominio;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class GrupoPermisoRepository : IGrupoPermisoRepository
    {
        private readonly VeterinariaContext context;
        public GrupoPermisoRepository(VeterinariaContext context) => this.context = context;
        public async Task<GrupoPermiso?> GetAsync(int id)
        {
            return await context.GruposPermisos.FirstOrDefaultAsync(gp => gp.Id == id);
        }
    }
}

using ModeloDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RolRepository : IRolRepository
    {

        private readonly VeterinariaContext context;

        public RolRepository(VeterinariaContext context)
        {
            this.context = context;
        }

        public async Task<Rol?> GetAsync(int id)
        {
            return await context.Roles.FirstOrDefaultAsync(r => r.IdRol == id);
        }
    }
}

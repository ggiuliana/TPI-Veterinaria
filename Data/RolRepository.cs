using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RolRepository
    {
        public static readonly List<Rol> roles = new();
        private static int nextId = 1;

        public Task<Rol?> GetAsync(int id)
        {
            return Task.FromResult(roles.FirstOrDefault(d => d.IdRol == id));
        }
    }
}

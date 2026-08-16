using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly VeterinariaContext context;

        public EstudioRepository(VeterinariaContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Estudio estudio) {
            context.Estudios.Add(estudio);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id) {
            var estudio = await context.Estudios.FirstOrDefaultAsync(e => e.IdEstudio == id);
            if (estudio != null) {
                context.Estudios.Remove(estudio);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Estudio?> GetAsync(int id) {
            return await context.Estudios.FirstOrDefaultAsync(e => e.IdEstudio == id);
        }
        public async Task<IEnumerable<Estudio>> GetAllAsync() {
            return await context.Estudios.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Estudio estudio) {
            var existingEstudio = await context.Estudios.FindAsync(estudio.IdEstudio);
            if (existingEstudio != null) {
                existingEstudio.SetNombre(estudio.NombreEstudio);
                existingEstudio.SetDescripcion(estudio.DescripcionEstudio);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}

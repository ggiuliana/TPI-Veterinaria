using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class TipoVacunaRepository(VeterinariaContext context) : ITipoVacunaRepository
    {
        public async Task AddAsync(TipoVacuna tipovacuna)
        {
            context.TipoVacunas.Add(tipovacuna);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var tipovacuna = await context.TipoVacunas.FindAsync(id);
            if (tipovacuna != null)
            {
                context.TipoVacunas.Remove(tipovacuna);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<TipoVacuna?> GetAsync(int id)
        {
            return await context.TipoVacunas.FirstOrDefaultAsync(t => t.IdTipoVacuna == id);
        }
        public async Task<IEnumerable<TipoVacuna>> GetAllAsync()
        {
            return await context.TipoVacunas.ToListAsync();
        }
        public async Task<bool> UpdateAsync(TipoVacuna tipovacuna)
        {
            var existingTipoVacuna = await context.TipoVacunas.FirstOrDefaultAsync(t => t.IdTipoVacuna == tipovacuna.IdTipoVacuna);
            if (existingTipoVacuna != null)
            {
                existingTipoVacuna.SetNombreTipoVacuna(tipovacuna.NombreTipoVacuna);
                existingTipoVacuna.SetDescripcionTipoVacuna(tipovacuna.DescripcionTipoVacuna);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly VeterinariaContext context;

        public TurnoRepository(VeterinariaContext context) => this.context = context;

        public async Task AddAsync(Turno turno)
        {
            context.Turnos.Add(turno);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var turno = await context.Turnos.FindAsync(id);
            if (turno != null)
            {
                context.Turnos.Remove(turno);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Turno?> GetAsync(int id)
        {           
            return await context.Turnos
                .Include(t => t.Veterinario) 
                .Include(t => t.Mascota)    
                .FirstOrDefaultAsync(t => t.IdTurno == id);
        }
        public async Task<IEnumerable<Turno>> GetAllAsync()
        {
            return await context.Turnos
               .Include(t => t.Veterinario)
               .Include(t => t.Mascota)
               .ToListAsync();
        }
        public async Task<bool> UpdateAsync(Turno turno)
        {
            var existingTurno = await context.Turnos.FirstOrDefaultAsync(t => t.IdTurno == turno.IdTurno);
            if (existingTurno != null)
            {
                existingTurno.SetFechaTurno(turno.FechaTurno);
                existingTurno.SetHoraTurno(turno.HoraTurno);
                existingTurno.SetEstadoTurno(turno.EstadoTurno);
                existingTurno.SetVeterinario(turno.Veterinario);


                if (turno.Mascota != null)
                {
                    existingTurno.SetMascota(turno.Mascota);
                }
                if (turno.Observaciones != null)
                {
                    existingTurno.SetObservaciones(turno.Observaciones);
                }
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

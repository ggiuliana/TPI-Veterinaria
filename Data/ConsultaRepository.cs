using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly VeterinariaContext context;

        public ConsultaRepository(VeterinariaContext context) => this.context = context;

        public async Task AddAsync(Consulta consulta)
        {
            context.Consultas.Add(consulta);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = await context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                context.Consultas.Remove(consulta);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Consulta?> GetAsync(int id)
        {
            return await context.Consultas
                .Include(c => c.Turno)
                    .ThenInclude(t => t.Veterinario)
                .Include(c => c.Turno)
                    .ThenInclude(t => t.Mascota)
                        .ThenInclude(m => m.Duenio)
                .Include(c => c.Estudios)
                .Include(c => c.MedicamentosConsulta)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);
        }
        public async Task<IEnumerable<Consulta>> GetAllAsync()
        {
            return await context.Consultas
                .Include(c => c.Turno)
                    .ThenInclude(t => t.Veterinario)
                .Include(c => c.Turno)
                    .ThenInclude(t => t.Mascota)
                        .ThenInclude(m => m.Duenio)
                .Include(c => c.Estudios)
                .Include(c => c.MedicamentosConsulta)
                .ToListAsync();
        }
        public async Task<bool> UpdateAsync(Consulta consulta)
        {
            var existingConsulta = await context.Consultas
                .Include(c => c.MedicamentosConsulta)
                .Include(c => c.Estudios)   
                .FirstOrDefaultAsync(t => t.IdConsulta == consulta.IdConsulta);

            if (existingConsulta == null)
            {
                return false;
            }

            existingConsulta.SetDiagnostico(consulta.Diagnostico);
            existingConsulta.SetTratamiento(consulta.Tratamiento);
            existingConsulta.SetPeso(consulta.Peso);
            existingConsulta.SetTurno(consulta.Turno);

            if (consulta.Estudios != null)
            {
                existingConsulta.SetEstudios(consulta.Estudios);
            }

            if (consulta.Observaciones != null)
            {
                existingConsulta.SetObservaciones(consulta.Observaciones);
            }

            if (consulta.MedicamentosConsulta != null)
            {
                var medicamentosAEliminar = existingConsulta.MedicamentosConsulta
                    .Where(dbItem => !consulta.MedicamentosConsulta.Any(mc => mc.IdMedicamento == dbItem.IdMedicamento))
                    .ToList();

                foreach (var item in medicamentosAEliminar)
                {
                    existingConsulta.MedicamentosConsulta.Remove(item);
                }

                var medicamentosAAgregar = consulta.MedicamentosConsulta
                    .Where(mc => !existingConsulta.MedicamentosConsulta.Any(dbItem => dbItem.IdMedicamento == mc.IdMedicamento))
                    .ToList();

                foreach (var item in medicamentosAAgregar)
                {
                    existingConsulta.MedicamentosConsulta.Add(item);
                }
            }

            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Consulta?> GetByIdTurnoAsync(int idTurno)
        {
            return await context.Consultas
                .Include(c => c.Turno)
                    .ThenInclude(t => t.Veterinario)
                .Include(c => c.Turno)
                    .ThenInclude(t => t.Mascota)
                        .ThenInclude(m => m.Duenio)
                .Include(c => c.Estudios)
                .Include(c => c.MedicamentosConsulta)
                .FirstOrDefaultAsync(c => c.IdTurno == idTurno);
        }
    }
}

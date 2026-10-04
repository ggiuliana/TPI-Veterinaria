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
                .Include(c => c.MedicamentosConsulta)
                .FirstOrDefaultAsync(t => t.IdConsulta == id);
        }
        public async Task<IEnumerable<Consulta>> GetAllAsync()
        {
            return await context.Consultas.ToListAsync();
        }
        /*public async Task<bool> UpdateAsync(Consulta consulta)
        {
            var existingConsulta = await context.Consultas.FirstOrDefaultAsync(t => t.IdConsulta == consulta.IdConsulta);
            if (existingConsulta != null)
            {
                existingConsulta.SetDiagnostico(consulta.Diagnostico);
                existingConsulta.SetTratamiento(consulta.Tratamiento);
                existingConsulta.SetPeso(consulta.Peso);
                existingConsulta.SetTurno(consulta.Turno);
                if (consulta.Estudios != null)
                {
                    existingConsulta.SetEstudios(consulta.Estudios);
                }
                if (consulta.MedicamentosConsulta != null)
                {
                    existingConsulta.SetMedicamentoConsulta(consulta.MedicamentosConsulta);
                }
                if (consulta.Observaciones != null)
                {
                    existingConsulta.SetObservaciones(consulta.Observaciones);
                }
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }*/
        public async Task<bool> UpdateAsync(Consulta consulta)
        {
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Consulta?> GetByIdTurnoAsync(int idTurno)
        {
            return await context.Consultas
                .Include(c => c.MedicamentosConsulta) 
                .Include(c => c.Estudios)           
                .FirstOrDefaultAsync(t => t.IdTurno == idTurno);
        }
    }
}

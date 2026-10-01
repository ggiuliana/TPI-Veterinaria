using Microsoft.EntityFrameworkCore;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await context.Consultas.FirstOrDefaultAsync(t => t.IdConsulta == id);
        }
        public async Task<IEnumerable<Consulta>> GetAllAsync()
        {
            return await context.Consultas.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Consulta consulta)
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
                if (consulta.MedicamentoConsulta != null)
                {
                    existingConsulta.SetMedicamentoConsulta(consulta.MedicamentoConsulta);
                }
                if (consulta.Observaciones != null)
                {
                    existingConsulta.SetObservaciones(consulta.Observaciones);
                }
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

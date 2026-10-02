using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class MedicamentoConsultaRepository : IMedicamentoConsultaRepository
    {
        private readonly VeterinariaContext context;

        public MedicamentoConsultaRepository(VeterinariaContext context) => this.context = context;
        public async Task<List<MedicamentoConsulta>> GetByConsultaIdAsync(int idConsulta)
        {
            return await context.MedicamentoConsulta
                .Include(mc => mc.Medicamento)
                .Where(mc => mc.IdConsulta == idConsulta)
                .ToListAsync();
        }

        public async Task AddAsync(MedicamentoConsulta detalle)
        {
            await context.MedicamentoConsulta.AddAsync(detalle);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idConsulta, int idMedicamento)
        {
            var detalle = await context.MedicamentoConsulta
                .FirstOrDefaultAsync(mc => mc.IdConsulta == idConsulta && mc.IdMedicamento == idMedicamento);

            if (detalle != null)
            {
                context.MedicamentoConsulta.Remove(detalle);
                await context.SaveChangesAsync();
            }
        }
    }
}

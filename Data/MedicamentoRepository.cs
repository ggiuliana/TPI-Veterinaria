using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly VeterinariaContext context;

        public MedicamentoRepository(VeterinariaContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Medicamento medicamento)
        {
            context.Medicamentos.Add(medicamento);
            await context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var medicamento = await context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                context.Medicamentos.Remove(medicamento);
                context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Medicamento?> GetAsync(int id)
        {
            return await context.Medicamentos.FirstOrDefaultAsync(t => t.IdMedicamento == id);
        }
        public async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            return await context.Medicamentos.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Medicamento medicamento)
        {
            var existingMedicamento = await context.Medicamentos.FirstOrDefaultAsync(t => t.IdMedicamento == medicamento.IdMedicamento);
            if (existingMedicamento != null)
            {
                existingMedicamento.SetNombreMedicamento(medicamento.NombreMedicamento);
                existingMedicamento.SetCantidadRestante(medicamento.CantidadRestante);
                context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

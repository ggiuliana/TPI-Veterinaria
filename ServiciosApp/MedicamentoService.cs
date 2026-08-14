using Data;
using DTOs;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosApp
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository repo;

        public MedicamentoService(IMedicamentoRepository repo)
        {
            this.repo = repo;
        }

        public async Task<MedicamentoDTO> AddAsync(MedicamentoDTO dto)
        {
            Medicamento medicamento = new Medicamento(0, dto.NombreMedicamento, dto.CantidadRestante);
            await repo.AddAsync(medicamento);
            dto.IdMedicamento = medicamento.IdMedicamento;
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
        public async Task<MedicamentoDTO> GetAsync(int id)
        {
            Medicamento? med = await repo.GetAsync(id);
            if (med == null)
            {
                return null;
            }
            return new MedicamentoDTO
            {
                IdMedicamento = med.IdMedicamento,
                NombreMedicamento = med.NombreMedicamento,
                CantidadRestante = med.CantidadRestante
            };
        }
        public async Task<IEnumerable<MedicamentoDTO>> GetAllAsync()
        {
            IEnumerable<Medicamento> tipovacs = await repo.GetAllAsync();
            return tipovacs.Select(t => new MedicamentoDTO
            {
                IdMedicamento = t.IdMedicamento,
                NombreMedicamento = t.NombreMedicamento,
                CantidadRestante = t.CantidadRestante
            }).ToList();
        }
        public async Task<bool> UpdateAsync(MedicamentoDTO dto)
        {
            var medactual = await repo.GetAsync(dto.IdMedicamento);
            if (medactual == null)
            {
                return false;
            }
            Medicamento med = new Medicamento(dto.IdMedicamento, dto.NombreMedicamento, dto.CantidadRestante);
            await repo.UpdateAsync(med);
            return true;
        }
    }
}

using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository repo;
        private readonly IMedicamentoConsultaRepository detalleRepo;

        public MedicamentoService(IMedicamentoRepository repo, IMedicamentoConsultaRepository detalleRepo)
        {
            this.repo = repo;
            this.detalleRepo = detalleRepo;
        }

        public async Task<MedicamentoDTO> AddAsync(MedicamentoDTO dto)
        {
            Medicamento medicamento = new(0, dto.NombreMedicamento, dto.CantidadRestante);
            await repo.AddAsync(medicamento);
            dto.IdMedicamento = medicamento.IdMedicamento;
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool estaEnUso = await repo.EstaEnUsoAsync(id);

            if (estaEnUso)
            {
                throw new ArgumentException("No se puede eliminar este medicamento porque ya forma parte del historial clínico de una o más consultas.");
            }
            return await repo.DeleteAsync(id);
        }
        public async Task<MedicamentoDTO?> GetAsync(int id)
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
            return [.. tipovacs.Select(t => new MedicamentoDTO
            {
                IdMedicamento = t.IdMedicamento,
                NombreMedicamento = t.NombreMedicamento,
                CantidadRestante = t.CantidadRestante
            })];
        }
        public async Task<bool> UpdateAsync(MedicamentoDTO dto)
        {
            var medactual = await repo.GetAsync(dto.IdMedicamento);
            if (medactual == null)
            {
                return false;
            }
            Medicamento med = new(dto.IdMedicamento, dto.NombreMedicamento, dto.CantidadRestante);
            await repo.UpdateAsync(med);
            return true;
        }
    }
}

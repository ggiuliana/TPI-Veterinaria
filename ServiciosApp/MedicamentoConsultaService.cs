using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class MedicamentoConsultaService : IMedicamentoConsultaService
    {
        private readonly IMedicamentoConsultaRepository repo;
        private readonly IMedicamentoRepository medicamentoRepo;

        public MedicamentoConsultaService(IMedicamentoConsultaRepository repo, IMedicamentoRepository medicamentoRepo)
        {
            this.repo = repo;
            this.medicamentoRepo = medicamentoRepo;
        }

        public async Task<List<MedicamentoConsultaDTO>> GetByConsultaIdAsync(int idConsulta)
        {
            var detalles = await repo.GetByConsultaIdAsync(idConsulta);

            return detalles.Select(d => new MedicamentoConsultaDTO
            {
                IdConsulta = d.IdConsulta,
                IdMedicamento = d.IdMedicamento,
                NombreMedicamento = d.Medicamento?.NombreMedicamento!,
                CantidadUsada = d.CantidadUsada
            }).ToList();
        }

        public async Task AddAsync(MedicamentoConsultaDTO dto)
        {
            if (dto.CantidadUsada <= 0)
                throw new ArgumentException("La cantidad usada debe ser mayor a cero.");

            var medicamentoDb = await medicamentoRepo.GetAsync(dto.IdMedicamento);
            if (medicamentoDb == null)
                throw new Exception("El medicamento seleccionado no existe.");

            if (medicamentoDb.CantidadRestante < dto.CantidadUsada)
                throw new Exception($"Stock insuficiente. Stock actual: {medicamentoDb.CantidadRestante}");

            var nuevoDetalle = new MedicamentoConsulta
            (
                dto.IdConsulta,
                dto.IdMedicamento,
                dto.CantidadUsada
             );

            await repo.AddAsync(nuevoDetalle);

            medicamentoDb.DescontarStock(dto.CantidadUsada);
            await medicamentoRepo.UpdateAsync(medicamentoDb);
        }

        public async Task DeleteAsync(int idConsulta, int idMedicamento)
        {
            var detalles = await repo.GetByConsultaIdAsync(idConsulta);
            var detalleABorrar = detalles.FirstOrDefault(d => d.IdMedicamento == idMedicamento);

            if (detalleABorrar != null)
            {
                var medicamentoDb = await medicamentoRepo.GetAsync(idMedicamento);
                if (medicamentoDb != null)
                {
                    medicamentoDb.AgregarStock(detalleABorrar.CantidadUsada);
                    await medicamentoRepo.UpdateAsync(medicamentoDb);
                }

                await repo.DeleteAsync(idConsulta, idMedicamento);
            }
        }
    }
}


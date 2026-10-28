using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class MedicamentoConsultaService : IMedicamentoConsultaService
    {
        private readonly IMedicamentoConsultaRepository repo;
        private readonly IMedicamentoRepository medicamentoRepo;
        private readonly IUserContextService userContext;
        private readonly IConsultaRepository consultaRepo;

        public MedicamentoConsultaService(IMedicamentoConsultaRepository repo, IMedicamentoRepository medicamentoRepo, IUserContextService userContext, IConsultaRepository consultaRepo)
        {
            this.repo = repo;
            this.medicamentoRepo = medicamentoRepo;
            this.userContext = userContext;
            this.consultaRepo = consultaRepo;
        }

        public async Task<List<MedicamentoConsultaDTO>> GetByConsultaIdAsync(int idConsulta)
        {
            string rol = userContext.GetCurrentRole();

            var detalles = await repo.GetByConsultaIdAsync(idConsulta);

            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                var primerDetalle = detalles.First();
                if (primerDetalle.Consulta?.Turno?.Veterinario?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No tiene permiso para ver los medicamentos de una consulta que no atendió.");
                }
            }

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
            string rol = userContext.GetCurrentRole();

            var consulta = await consultaRepo.GetAsync(dto.IdConsulta);
            if (consulta == null)
            {
                throw new KeyNotFoundException($"No se encontró la consulta con ID {dto.IdConsulta}");
            }

            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (consulta.Turno?.Veterinario?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No tiene permiso para agregar medicamentos a una consulta que no atendió.");
                }
            }

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
            string rol = userContext.GetCurrentRole();

            var consulta = await consultaRepo.GetAsync(idConsulta);
            if (consulta == null)
            {
                throw new KeyNotFoundException($"No se encontró la consulta con ID {idConsulta}");
            }

            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (consulta.Turno?.Veterinario?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No tiene permiso para eliminar medicamentos a una consulta que no atendió.");
                }
            }

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


using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository repo;
        private readonly IMedicamentoConsultaRepository detalleRepo;
        private readonly IUserContextService userContext;

        public MedicamentoService(IMedicamentoRepository repo, IMedicamentoConsultaRepository detalleRepo, IUserContextService userContext )
        {
            this.repo = repo;
            this.detalleRepo = detalleRepo;
            this.userContext = userContext;
        }

        public async Task<MedicamentoDTO> AddAsync(MedicamentoDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NombreMedicamento))
            {
                throw new ArgumentException("El nombre del medicamento es obligatorio.");
            }
            if (dto.CantidadRestante < 0)
            {
                throw new ArgumentException("La cantidad de stock inicial no puede ser negativa.");
            }

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
        public async Task<(IEnumerable<MedicamentoDTO> Agotados, IEnumerable<MedicamentoDTO> StockBajo, IEnumerable<MedicamentoDTO> StockSuficiente)> GetMedicamentosClasificadosPorStockAsync()
        {
            string rol = userContext.GetCurrentRole();

            if (!string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Solo el usuario con rol Administrador tiene permiso para consultar este reporte de stock.");
            }

            var (agotados, stockBajo, stockSuficiente) = await repo.GetMedicamentosClasificadosPorStockAdoAsync();

            return (
                [.. agotados.Select(t => new MedicamentoDTO
            {
                IdMedicamento = t.IdMedicamento,
                NombreMedicamento = t.NombreMedicamento,
                CantidadRestante = t.CantidadRestante
            })],
                [.. stockBajo.Select(t => new MedicamentoDTO
            {
                IdMedicamento = t.IdMedicamento,
                NombreMedicamento = t.NombreMedicamento,
                CantidadRestante = t.CantidadRestante
            })],
                [.. stockSuficiente.Select(t => new MedicamentoDTO
            {
                IdMedicamento = t.IdMedicamento,
                NombreMedicamento = t.NombreMedicamento,
                CantidadRestante = t.CantidadRestante
            })]
            );
        }
        public async Task<bool> UpdateAsync(MedicamentoDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NombreMedicamento))
            {
                throw new ArgumentException("El nombre del medicamento es obligatorio.");
            }
            if (dto.CantidadRestante < 0)
            {
                throw new ArgumentException("La cantidad de stock no puede ser negativa.");
            }

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

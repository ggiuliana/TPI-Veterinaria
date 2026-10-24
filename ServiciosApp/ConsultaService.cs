using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository repo;
        private readonly ITurnoRepository repoTurno;
        private readonly IEstudioRepository repoEstudio;
        private readonly IMedicamentoRepository repoMedicamento;
        private readonly IMedicamentoConsultaRepository repoMedicamentoConsulta;

        public ConsultaService(IConsultaRepository repo, ITurnoRepository repoTurno, IEstudioRepository repoEstudio, IMedicamentoRepository repoMedicamento, IMedicamentoConsultaRepository repoMedicamentoConsulta)
        {
            this.repo = repo;
            this.repoTurno = repoTurno;
            this.repoEstudio = repoEstudio;
            this.repoMedicamento = repoMedicamento;
            this.repoMedicamentoConsulta = repoMedicamentoConsulta;
        }

        public async Task<ConsultaDTO> AddAsync(ConsultaDTO dto)
        {
            var turno = await repoTurno.GetAsync(dto.IdTurno) ?? throw new ArgumentException($"No se encontró el turno con ID {dto.IdTurno}");

            Consulta consulta = new Consulta(0, dto.Diagnostico, dto.Tratamiento, dto.Peso, turno);

            if (dto.Observaciones != null)
            {
                consulta.SetObservaciones(dto.Observaciones);
            }

            if (dto.IdEstudios != null && dto.IdEstudios.Any())
            {
                ICollection<Estudio> estudios = await repoEstudio.GetByIdListAsync(dto.IdEstudios);
                consulta.SetEstudios(estudios);
            }

            if (dto.MedicamentoConsulta != null && dto.MedicamentoConsulta.Any())
            {
                var idsMedicamentos = dto.MedicamentoConsulta.Select(m => m.IdMedicamento).ToList();
                var medicamentosDb = await repoMedicamento.GetByIdsAsync(idsMedicamentos);

                foreach (var itemDto in dto.MedicamentoConsulta)
                {
                    var medicamento = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == itemDto.IdMedicamento)
                        ?? throw new ArgumentException($"No se encontró el medicamento con ID {itemDto.IdMedicamento}");

                    if (medicamento.CantidadRestante < itemDto.CantidadUsada)
                    {
                        throw new ArgumentException($"Stock insuficiente para el medicamento ID {medicamento.IdMedicamento}");
                    }
                }

                foreach (var itemDto in dto.MedicamentoConsulta)
                {
                    var medicamento = medicamentosDb.First(m => m.IdMedicamento == itemDto.IdMedicamento);
                    medicamento.DescontarStock(itemDto.CantidadUsada);
                }

                ICollection<MedicamentoConsulta> medicamentoConsulta = dto.MedicamentoConsulta.Select(itemDto => new MedicamentoConsulta
                (
                    itemDto.IdConsulta,
                    itemDto.IdMedicamento,
                    itemDto.CantidadUsada
                )).ToList();

                consulta.SetMedicamentoConsulta(medicamentoConsulta);
            }

            await repo.AddAsync(consulta);

            dto.IdConsulta = consulta.IdConsulta;
            return dto;
        }

        public async Task<ConsultaDTO?> GetAsync(int id)
        {
            Consulta? consulta = await repo.GetAsync(id);
            if (consulta == null)
            {
                return null;
            }
            return new ConsultaDTO
            {
                IdConsulta = consulta.IdConsulta,
                Diagnostico = consulta.Diagnostico,
                Tratamiento = consulta.Tratamiento,
                Peso = consulta.Peso,
                Observaciones = consulta.Observaciones,
                IdTurno = consulta.IdTurno,
                IdEstudios = consulta.Estudios?.Select(e => e.IdEstudio).ToList()??null,
                MedicamentoConsulta = consulta.MedicamentosConsulta?.Select(mu => new MedicamentoConsultaDTO
                {
                    IdConsulta = mu.IdConsulta,
                    IdMedicamento = mu.IdMedicamento,
                    CantidadUsada = mu.CantidadUsada
                }).ToList()?? null
            };
        }
        public async Task<IEnumerable<ConsultaDTO>> GetAllAsync()
        {
            IEnumerable<Consulta> consultas = await repo.GetAllAsync();
            return [.. consultas.Select(consulta => new ConsultaDTO
            {
                IdConsulta = consulta.IdConsulta,
                Diagnostico = consulta.Diagnostico,
                Tratamiento = consulta.Tratamiento,
                Peso = consulta.Peso,
                Observaciones = consulta.Observaciones,
                IdTurno = consulta.IdTurno,
                IdEstudios = consulta.Estudios?.Select(e => e.IdEstudio).ToList()??null,
                MedicamentoConsulta = consulta.MedicamentosConsulta?.Select(mu => new MedicamentoConsultaDTO
                {
                    IdConsulta = mu.IdConsulta,
                    IdMedicamento = mu.IdMedicamento,
                    CantidadUsada = mu.CantidadUsada
                }).ToList()?? null
            })];
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = await repo.GetAsync(id);
            if (consulta == null)
            {
                return false;
            }
            if (consulta.MedicamentosConsulta != null && consulta.MedicamentosConsulta.Any())
            {
                var idsMedicamentos = consulta.MedicamentosConsulta.Select(m => m.IdMedicamento).ToList();
                var medicamentosDb = await repoMedicamento.GetByIdsAsync(idsMedicamentos);

                foreach (var relacion in consulta.MedicamentosConsulta)
                {
                    var medDb = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == relacion.IdMedicamento);
                    if (medDb != null)
                    {
                        medDb.SetCantidadRestante(medDb.CantidadRestante + relacion.CantidadUsada);
                    }
                }

                consulta.MedicamentosConsulta.Clear();

            }
            return await repo.DeleteAsync(id);
        }
        public async Task<bool> UpdateAsync(ConsultaDTO dto)
        {
            var consulta = await repo.GetAsync(dto.IdConsulta) ?? throw new Exception("Consulta no encontrada");
            var turno = await repoTurno.GetAsync(dto.IdTurno) ?? throw new ArgumentException("No se encontró el turno");

            consulta.SetTurno(turno);
            consulta.SetDiagnostico(dto.Diagnostico);
            consulta.SetTratamiento(dto.Tratamiento);
            consulta.SetPeso(dto.Peso);
            if (dto.Observaciones != null) consulta.SetObservaciones(dto.Observaciones);

            var medicamentosDb = consulta.MedicamentosConsulta ?? new List<MedicamentoConsulta>();
            var medicamentosDto = dto.MedicamentoConsulta ?? new List<MedicamentoConsultaDTO>();

            var idsDb = medicamentosDb.Select(m => m.IdMedicamento);
            var idsDto = medicamentosDto.Select(m => m.IdMedicamento);
            var todosLosIds = idsDb.Union(idsDto).Distinct().ToList();

            var medicamentosTrackeados = await repoMedicamento.GetByIdsAsync(todosLosIds);

            foreach (var itemDto in medicamentosDto)
            {
                var medDb = medicamentosTrackeados.FirstOrDefault(m => m.IdMedicamento == itemDto.IdMedicamento)
                            ?? throw new Exception($"No se encontró el medicamento con ID {itemDto.IdMedicamento}");

                var relacionExistente = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == itemDto.IdMedicamento);

                if (relacionExistente != null)
                {
                    int diferencia = itemDto.CantidadUsada - relacionExistente.CantidadUsada;
                    if (diferencia > 0 && medDb.CantidadRestante < diferencia)
                    {
                        throw new Exception($"Stock insuficiente para el medicamento ID {medDb.IdMedicamento}.");
                    }
                }
                else
                {
                    if (medDb.CantidadRestante < itemDto.CantidadUsada)
                    {
                        throw new Exception($"Stock insuficiente para el medicamento ID {medDb.IdMedicamento}.");
                    }
                }
            }

            var aEliminar = medicamentosDb.Where(m => !idsDto.Contains(m.IdMedicamento)).ToList();
            foreach (var itemEliminar in aEliminar)
            {
                var medDb = medicamentosTrackeados.FirstOrDefault(m => m.IdMedicamento == itemEliminar.IdMedicamento);
                if (medDb != null)
                {
                    medDb.SetCantidadRestante(medDb.CantidadRestante + itemEliminar.CantidadUsada);
                }
                consulta.MedicamentosConsulta.Remove(itemEliminar);
                repoMedicamentoConsulta.Remove(itemEliminar);
            }

            foreach (var itemDto in medicamentosDto)
            {
                var medDb = medicamentosTrackeados.First(m => m.IdMedicamento == itemDto.IdMedicamento);
                var relacionExistente = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == itemDto.IdMedicamento);

                if (relacionExistente != null)
                {
                    int diferencia = itemDto.CantidadUsada - relacionExistente.CantidadUsada;

                    medDb.SetCantidadRestante(medDb.CantidadRestante - diferencia);
                    relacionExistente.SetCantidadUsada(itemDto.CantidadUsada);
                }
                else
                {
                    medDb.SetCantidadRestante(medDb.CantidadRestante - itemDto.CantidadUsada);
                    var nuevaRelacion = new MedicamentoConsulta(consulta.IdConsulta, itemDto.IdMedicamento, itemDto.CantidadUsada);
                    consulta.MedicamentosConsulta.Add(nuevaRelacion);
                }
            }
            return await repo.UpdateAsync(consulta);
        }
        public async Task<ConsultaDTO?> GetByIdTurnoAsync(int idTurno)
        {
            Consulta? consulta = await repo.GetByIdTurnoAsync(idTurno);

            if (consulta == null)
            {
                return null;
            }

            return new ConsultaDTO
            {
                IdConsulta = consulta.IdConsulta,
                Diagnostico = consulta.Diagnostico,
                Tratamiento = consulta.Tratamiento,
                Peso = consulta.Peso,
                Observaciones = consulta.Observaciones,
                IdTurno = consulta.IdTurno,
                IdEstudios = consulta.Estudios?.Select(e => e.IdEstudio).ToList() ?? null,
                MedicamentoConsulta = consulta.MedicamentosConsulta?.Select(mu => new MedicamentoConsultaDTO
                {
                    IdConsulta = mu.IdConsulta,
                    IdMedicamento = mu.IdMedicamento,
                    CantidadUsada = mu.CantidadUsada
                }).ToList() ?? null
            };
        }
    }
}

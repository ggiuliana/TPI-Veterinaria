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

        public ConsultaService(IConsultaRepository repo, ITurnoRepository repoTurno, IEstudioRepository repoEstudio, IMedicamentoRepository repoMedicamento)
        {
            this.repo = repo;
            this.repoTurno = repoTurno;
            this.repoEstudio = repoEstudio;
            this.repoMedicamento = repoMedicamento;
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

                ICollection<MedicamentoConsulta> medicamentoConsulta = dto.MedicamentoConsulta.Select(itemDto => new MedicamentoConsulta
                (
                itemDto.IdConsulta,
                itemDto.IdMedicamento,
                itemDto.CantidadUsada
                )).ToList();

                consulta.SetMedicamentoConsulta(medicamentoConsulta);

                foreach (var itemDto in dto.MedicamentoConsulta)
                {
                    var medicamento = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == itemDto.IdMedicamento);

                    if (medicamento != null)
                    {
                        if (medicamento.CantidadRestante < itemDto.CantidadUsada)
                        {
                            throw new ArgumentException($"Stock insuficiente para el medicamento ID {medicamento.IdMedicamento}");
                        }
                        var cantidad = medicamento.CantidadRestante;
                        medicamento.SetCantidadRestante(cantidad -= itemDto.CantidadUsada);
                        await repoMedicamento.UpdateAsync(medicamento);
                    }
                }
            }
            await repo.AddAsync(consulta);
            dto.IdConsulta = consulta.IdConsulta;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
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
                MedicamentoConsulta = consulta.MedicamentoConsulta?.Select(mu => new MedicamentoConsultaDTO
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
                MedicamentoConsulta = consulta.MedicamentoConsulta?.Select(mu => new MedicamentoConsultaDTO
                {
                    IdConsulta = mu.IdConsulta,
                    IdMedicamento = mu.IdMedicamento,
                    CantidadUsada = mu.CantidadUsada
                }).ToList()?? null
            })];
        }
        public async Task<bool> UpdateAsync(ConsultaDTO dto)
        {
            var consulta = await repo.GetAsync(dto.IdConsulta);
            if (consulta == null) throw new Exception("Consulta no encontrada");

            var turno = await repoTurno.GetAsync(dto.IdTurno) ?? throw new ArgumentException($"No se encontró el turno con ID {dto.IdTurno}");
            consulta.SetTurno(turno);
            consulta.SetDiagnostico(dto.Diagnostico);
            consulta.SetTratamiento(dto.Tratamiento);
            consulta.SetPeso(dto.Peso);
            if (dto.Observaciones != null)
            {
                consulta.SetObservaciones(dto.Observaciones);
            }
            if (dto.IdEstudios != null && dto.IdEstudios.Any())
            {
                ICollection<Estudio> estudios = await repoEstudio.GetByIdListAsync(dto.IdEstudios);
                consulta.SetEstudios(estudios);
            }

            var idsViejos = consulta.MedicamentoConsulta.Select(m => m.IdMedicamento);
            var idsNuevos = dto.MedicamentoConsulta?.Select(m => m.IdMedicamento) ?? new List<int>();
            var todosLosIds = idsViejos.Union(idsNuevos).Distinct().ToList();

            var medicamentosDb = await repoMedicamento.GetByIdsAsync(todosLosIds);

            foreach (var medicamenteViejo in consulta.MedicamentoConsulta)
            {
                var medicamento = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == medicamenteViejo.IdMedicamento);
                if (medicamento != null)
                {
                    var cantidad = medicamento.CantidadRestante;
                    medicamento.SetCantidadRestante(cantidad += medicamenteViejo.CantidadUsada);
                }
            }

            consulta.MedicamentoConsulta.Clear();

            if (dto.MedicamentoConsulta != null && dto.MedicamentoConsulta.Any())
            {
                foreach (var itemDto in dto.MedicamentoConsulta)
                {
                    var medicamento = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == itemDto.IdMedicamento);
                    if (medicamento != null)
                    {
                        if (medicamento.CantidadRestante < itemDto.CantidadUsada)
                        {
                            throw new Exception($"Stock insuficiente para el medicamento ID {medicamento.IdMedicamento}");
                        }

                        var cantidad = medicamento.CantidadRestante;
                        medicamento.SetCantidadRestante(cantidad -= itemDto.CantidadUsada);

                        var nuevaRelacion = new MedicamentoConsulta(
                            consulta.IdConsulta,
                            itemDto.IdMedicamento,
                            itemDto.CantidadUsada
                        );

                        consulta.MedicamentoConsulta.Add(nuevaRelacion);
                    }
                }
            }
            return await repo.UpdateAsync(consulta);
        }
    }
}

using Data;
using DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (dto.MedicamentosUsados != null && dto.MedicamentosUsados.Any())
            {
                var idsMedicamentos = dto.MedicamentosUsados.Select(m => m.IdMedicamento).ToList();
                var medicamentosDb = await repoMedicamento.GetByIdsAsync(idsMedicamentos);

                ICollection<MedicamentosUsados> medicamentosUsados = dto.MedicamentosUsados.Select(itemDto => new MedicamentosUsados
                (
                itemDto.IdConsulta,
                itemDto.IdMedicamento,
                itemDto.CantidadUsada
                )).ToList();

                consulta.SetMedicamentosUsados(medicamentosUsados);

                foreach (var itemDto in dto.MedicamentosUsados)
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
                MedicamentosUsados = consulta.MedicamentosUsados?.Select(mu => new MedicamentosUsadosDTO
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
                MedicamentosUsados = consulta.MedicamentosUsados?.Select(mu => new MedicamentosUsadosDTO
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

            var idsViejos = consulta.MedicamentosUsados.Select(m => m.IdMedicamento);
            var idsNuevos = dto.MedicamentosUsados?.Select(m => m.IdMedicamento) ?? new List<int>();
            var todosLosIds = idsViejos.Union(idsNuevos).Distinct().ToList();

            var medicamentosDb = await repoMedicamento.GetByIdsAsync(todosLosIds);

            foreach (var medicamenteViejo in consulta.MedicamentosUsados)
            {
                var medicamento = medicamentosDb.FirstOrDefault(m => m.IdMedicamento == medicamenteViejo.IdMedicamento);
                if (medicamento != null)
                {
                    var cantidad = medicamento.CantidadRestante;
                    medicamento.SetCantidadRestante(cantidad += medicamenteViejo.CantidadUsada);
                }
            }

            consulta.MedicamentosUsados.Clear();

            if (dto.MedicamentosUsados != null && dto.MedicamentosUsados.Any())
            {
                foreach (var itemDto in dto.MedicamentosUsados)
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

                        var nuevaRelacion = new MedicamentosUsados(
                            consulta.IdConsulta,
                            itemDto.IdMedicamento,
                            itemDto.CantidadUsada
                        );

                        consulta.MedicamentosUsados.Add(nuevaRelacion);
                    }
                }
            }
            return await repo.UpdateAsync(consulta);
        }
    }
}

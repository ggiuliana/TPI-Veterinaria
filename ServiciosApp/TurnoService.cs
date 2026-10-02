using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository repo;
        private readonly IVeterinarioRepository repoVeterinario;
        private readonly IMascotaRepository repoMascota;

        public TurnoService(ITurnoRepository repo, IVeterinarioRepository repoVeterinario, IMascotaRepository repoMascota)
        {
            this.repo = repo;
            this.repoVeterinario = repoVeterinario;
            this.repoMascota = repoMascota;
        }

        public async Task<TurnoDTO> AddAsync(TurnoDTO dto)
        {
            var vet = await repoVeterinario.GetAsync(dto.IdVeterinario)?? throw new ArgumentException($"No se encontró el veterinario con ID {dto.IdVeterinario}");
            Turno turno = new Turno(0, dto.FechaTurno, dto.HoraTurno, dto.EstadoTurno, vet);
            if (dto.Observaciones != null)
            {
                turno.SetObservaciones(dto.Observaciones);
            }
            await repo.AddAsync(turno);
            dto.IdTurno = turno.IdTurno;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
        public async Task<TurnoDTO?> GetAsync(int id)
        {
            Turno? turno = await repo.GetAsync(id);
            if (turno == null)
            {
                return null;
            }

            return new TurnoDTO
            {
                IdTurno = turno.IdTurno,
                FechaTurno = turno.FechaTurno,
                HoraTurno = turno.HoraTurno,
                EstadoTurno = turno.EstadoTurno,
                Observaciones = turno.Observaciones,
                IdVeterinario = turno.Veterinario?.IdPersona ?? 0,
                IdMascota = turno.Mascota?.IdMascota
            };
        }
        public async Task<IEnumerable<TurnoDTO>> GetAllAsync()
        {
            IEnumerable<Turno> turnos = await repo.GetAllAsync();
            return [.. turnos.Select(turno => new TurnoDTO
            {
                IdTurno = turno.IdTurno,
                FechaTurno = turno.FechaTurno,
                HoraTurno = turno.HoraTurno,
                EstadoTurno = turno.EstadoTurno,
                Observaciones = turno.Observaciones,
                IdVeterinario = turno.Veterinario?.IdPersona ?? 0,
                IdMascota = turno.Mascota?.IdMascota
            })];
        }
        public async Task<bool> UpdateAsync(TurnoDTO dto)
        {
            var vet = await repoVeterinario.GetAsync(dto.IdVeterinario) ?? throw new ArgumentException($"No se encontró el veterinario con ID {dto.IdVeterinario}");
            var mascota = dto.IdMascota.HasValue ? await repoMascota.GetAsync(dto.IdMascota.Value) : null;
            Turno turno = new Turno(0, dto.FechaTurno, dto.HoraTurno, dto.EstadoTurno, vet);
            if (dto.Observaciones != null)
            {
                turno.SetObservaciones(dto.Observaciones);
            }
            if (mascota != null)
            {
                turno.SetMascota(mascota);
            }
            return await repo.UpdateAsync(turno);
        }
    }
}

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
        private readonly IUserContextService userContext;

        public TurnoService(
            ITurnoRepository repo,
            IVeterinarioRepository repoVeterinario,
            IMascotaRepository repoMascota,
            IUserContextService userContext)
        {
            this.repo = repo;
            this.repoVeterinario = repoVeterinario;
            this.repoMascota = repoMascota;
            this.userContext = userContext;
        }

        public async Task<TurnoDTO> AddAsync(TurnoDTO dto)
        {
            string rol = userContext.GetCurrentRole();

            var vet = await repoVeterinario.GetAsync(dto.IdVeterinario) ?? throw new ArgumentException($"No se encontró el veterinario con ID {dto.IdVeterinario}");
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
            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                throw new UnauthorizedAccessException("Los dueños no tienen permiso.");
            }
            Turno? turno = await repo.GetAsync(id);
            if (turno == null)
            {
                return null;
            }

            return MapToDTO(turno);
        }

        public async Task<IEnumerable<TurnoDTO>?> GetByVeterinarioIdAsync(int idVeterinario)
        {
            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                throw new UnauthorizedAccessException("Los dueños no tienen permiso.");
            }
            IEnumerable<Turno> turnos = await repo.GetByVeterinarioIdAsync(idVeterinario);
            return [.. turnos.Select(MapToDTO)];
        }

        public async Task<IEnumerable<TurnoDTO>?> GetDisponiblesAsync()
        {
            IEnumerable<Turno> turnos = await repo.GetDisponiblesAsync();
            return [.. turnos.Select(MapToDTO)];
        }

        public async Task<IEnumerable<TurnoDTO>> GetAllAsync()
        {
            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                return await GetDisponiblesAsync() ?? Enumerable.Empty<TurnoDTO>();
            }
            IEnumerable<Turno> turnos = await repo.GetAllAsync();
            return [.. turnos.Select(MapToDTO)];
        }

        public async Task<bool> UpdateAsync(TurnoDTO dto)
        {
            string rol = userContext.GetCurrentRole();
            int currentUserId = userContext.GetCurrentUserId();

            var turnoDb = await repo.GetAsync(dto.IdTurno) ?? throw new KeyNotFoundException("Turno no encontrado.");

            if (rol == "Duenio")
            {
                if (turnoDb.EstadoTurno == "Disponible")
                {

                    if (!dto.IdMascota.HasValue)
                    {
                        throw new ArgumentException("Debe seleccionar una mascota para reservar el turno.");
                    }

                    var mascotaDb = await repoMascota.GetAsync(dto.IdMascota.Value)
                        ?? throw new KeyNotFoundException("Mascota no encontrada.");

                    if (mascotaDb.Duenio?.IdPersona != currentUserId)
                    {
                        throw new UnauthorizedAccessException("No puede asignar el turno a una mascota que no le pertenece.");
                    }

                    turnoDb.SetEstadoTurno("Otorgado");
                    turnoDb.SetMascota(mascotaDb);

                    return await repo.UpdateAsync(turnoDb);
                }
                else
                {
                    throw new UnauthorizedAccessException("No tiene permiso para modificar este turno.");
                }
            }

            var vet = await repoVeterinario.GetAsync(dto.IdVeterinario) ?? throw new ArgumentException($"No se encontró el veterinario con ID {dto.IdVeterinario}");
            var mascota = dto.IdMascota.HasValue ? await repoMascota.GetAsync(dto.IdMascota.Value) : null;

            turnoDb.SetFechaTurno(dto.FechaTurno);
            turnoDb.SetHoraTurno(dto.HoraTurno);
            turnoDb.SetEstadoTurno(dto.EstadoTurno);
            turnoDb.SetVeterinario(vet);

            if (dto.Observaciones != null) turnoDb.SetObservaciones(dto.Observaciones);
            if (mascota != null) turnoDb.SetMascota(mascota);

            return await repo.UpdateAsync(turnoDb);
        }

        private TurnoDTO MapToDTO(Turno turno)
        {
            return new TurnoDTO
            {
                IdTurno = turno.IdTurno,
                FechaTurno = turno.FechaTurno,
                HoraTurno = turno.HoraTurno,
                EstadoTurno = turno.EstadoTurno,
                Observaciones = turno.Observaciones,

                IdVeterinario = turno.Veterinario?.IdPersona ?? 0,
                NombreVeterinario = turno.Veterinario?.NombrePersona ?? "Sin asignar",
                ApellidoVeterinario = turno.Veterinario?.Apellido ?? "",
                EspecialidadVeterinario = turno.Veterinario?.Especialidad ?? "",
                NombreCompletoVeterinario = turno.Veterinario != null ? $"{turno.Veterinario.NombrePersona} {turno.Veterinario.Apellido}" : "Sin asignar",

                IdMascota = turno.Mascota?.IdMascota,
                NombreMascota = turno.Mascota != null ? turno.Mascota.NombreMascota : "Sin mascota"
            };
        }
    }
}
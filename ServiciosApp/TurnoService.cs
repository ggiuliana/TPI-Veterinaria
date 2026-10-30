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

            if (!Turno.EsEstadoPermitido(dto.EstadoTurno))
            {
                throw new ArgumentException("Estado de turno inválido. Los estados permitidos son: Disponible, Otorgado y Resuelto.");
            }

            if (!string.Equals(dto.EstadoTurno, "Disponible", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Los turnos nuevos deben crearse con estado 'Disponible'.");
            }

            var fechaHoy = DateOnly.FromDateTime(DateTime.Now);
            if (dto.FechaTurno < fechaHoy)
            {
                throw new ArgumentException("No se pueden registrar nuevos turnos con fechas pasadas.");
            }

            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                dto.IdVeterinario = currentUserId;
            }

            var vet = await repoVeterinario.GetAsync(dto.IdVeterinario) ?? throw new ArgumentException($"No se encontró el veterinario con ID {dto.IdVeterinario}");

            Turno turno = new Turno(0, dto.FechaTurno, dto.HoraTurno, "Disponible", vet);

            if (dto.Observaciones != null)
            {
                turno.SetObservaciones(dto.Observaciones);
            }

            await repo.AddAsync(turno);

            dto.IdTurno = turno.IdTurno;
            dto.IdVeterinario = vet.IdPersona;
            dto.EstadoTurno = turno.EstadoTurno;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string rol = userContext.GetCurrentRole();

            var turno = await repo.GetAsync(id);
            if (turno == null)
            {
                return false;
            }

            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (turno.Veterinario?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No puede eliminar un turno asignado a otro veterinario.");
                }
            }

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
            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (turno.Veterinario?.IdPersona != currentUserId)
                {
                   throw new UnauthorizedAccessException("No puede ver un turno asignado a otro veterinario.");
                }
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
            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (idVeterinario != currentUserId)
                {
                    throw new UnauthorizedAccessException("No puede ver los turnos de otro veterinario.");
                }
            }
            IEnumerable<Turno> turnos = await repo.GetByVeterinarioIdAsync(idVeterinario);
            return [.. turnos.Select(MapToDTO)];
        }

        public async Task<IEnumerable<TurnoDTO>?> GetDisponiblesAsync()
        {
            IEnumerable<Turno> turnos = await repo.GetDisponiblesAsync();
            return [.. turnos.Select(MapToDTO)];
        }

        public async Task<IEnumerable<TurnoDTO>> GetTurnosFiltradosAsync(int? idVeterinario, string? estado, DateOnly? fechaDesde, DateOnly? fechaHasta)
        {
            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                throw new UnauthorizedAccessException("Los dueños no tienen permiso para usar este filtro.");
            }

            if (rol == "Veterinario")
            {
                idVeterinario = userContext.GetCurrentUserId();
            }

            if (fechaDesde.HasValue && fechaHasta.HasValue)
            {
                if (fechaDesde.Value > fechaHasta.Value)
                {
                    throw new ArgumentException("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.");
                }
            }

            if (estado != null && string.IsNullOrWhiteSpace(estado))
            {
                throw new ArgumentException("El estado proporcionado no es válido.");
            }

            IEnumerable<Turno> turnosFiltrados = await repo.GetTurnosFiltradosAsync(idVeterinario, estado, fechaDesde, fechaHasta);

            return [.. turnosFiltrados.Select(MapToDTO)];
        }

        public async Task<IEnumerable<TurnoDTO>> GetAllAsync()
        {
            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                return await GetDisponiblesAsync() ?? Enumerable.Empty<TurnoDTO>();
            }
            if (rol == "Veterinario")
            { 
                return await GetByVeterinarioIdAsync(userContext.GetCurrentUserId()) ?? Enumerable.Empty<TurnoDTO>();
            }
            IEnumerable<Turno> turnos = await repo.GetAllAsync();
            return [.. turnos.Select(MapToDTO)];
        }

        public async Task<bool> UpdateAsync(TurnoDTO dto)
        {
            string rol = userContext.GetCurrentRole();

            var turnoDb = await repo.GetAsync(dto.IdTurno) ?? throw new KeyNotFoundException("Turno no encontrado.");

            if (!Turno.EsEstadoPermitido(dto.EstadoTurno))
            {
                throw new ArgumentException("Estado de turno inválido.");
            }

            if (dto.IdMascota.HasValue && dto.IdMascota.Value <= 0)
            {
                dto.IdMascota = null;
            }

            if (rol == "Duenio")
            {
                int currentUserId = userContext.GetCurrentUserId();

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

            if (rol == "Veterinario")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (turnoDb.Veterinario?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No puede modificar los turnos de otro veterinario.");
                }
            }

            if (dto.IdMascota.HasValue && dto.EstadoTurno == "Disponible")
            {
                throw new ArgumentException("Un turno no puede estar 'Disponible' si ya tiene una mascota asignada. Cambie el estado a 'Otorgado' o 'Resuelto'.");
            }

            var vet = await repoVeterinario.GetAsync(dto.IdVeterinario) ?? throw new ArgumentException($"No se encontró el veterinario con ID {dto.IdVeterinario}");

            var mascota = dto.IdMascota.HasValue ? await repoMascota.GetAsync(dto.IdMascota.Value) : null;

            turnoDb.SetFechaTurno(dto.FechaTurno);
            turnoDb.SetHoraTurno(dto.HoraTurno);
            turnoDb.SetEstadoTurno(dto.EstadoTurno);
            turnoDb.SetVeterinario(vet);

            if (dto.Observaciones != null)
            {
                turnoDb.SetObservaciones(dto.Observaciones);
            }

            turnoDb.SetMascota(mascota!);

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
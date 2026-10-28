using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository repo;
        private readonly IDuenioRepository repoDuenio;
        private readonly ITipoVacunaRepository repoTipoVacuna;
        private readonly IUserContextService userContext;

        public MascotaService(
            IMascotaRepository repo,
            IDuenioRepository repoDuenio,
            ITipoVacunaRepository repoTipoVacuna,
            IUserContextService userContext)
        {
            this.repo = repo;
            this.repoDuenio = repoDuenio;
            this.repoTipoVacuna = repoTipoVacuna;
            this.userContext = userContext;
        }

        public async Task<MascotaDTO> AddAsync(MascotaDTO dto)
        {
            int currentUserId = userContext.GetCurrentUserId();
            string rol = userContext.GetCurrentRole();

            int idDuenioAsignado = (rol == "Duenio") ? currentUserId : dto.IdDuenio;

            var duenio = await repoDuenio.GetAsync(idDuenioAsignado) ?? throw new ArgumentException("Dueño no encontrado");

            Mascota mascota = new(
                0,
                dto.NombreMascota,
                dto.Especie,
                dto.Raza,
                dto.Castrado,
                dto.Sexo,
                dto.FechaNac,
                duenio);

            if (dto.Vacunas != null && dto.Vacunas.Any())
            {
                var vacunasParaGuardar = new List<Vacuna>();

                var idsTipos = dto.Vacunas.Select(v => v.IdTipoVacuna).Distinct().ToList();
                var tiposVacunaDb = await repoTipoVacuna.GetByIdListAsync(idsTipos);

                foreach (var vacuna in dto.Vacunas)
                {
                    var tipoVacuna = tiposVacunaDb.FirstOrDefault(t => t.IdTipoVacuna == vacuna.IdTipoVacuna);
                    if (tipoVacuna == null)
                    {
                        throw new ArgumentException($"Tipo de vacuna con ID {vacuna.IdTipoVacuna} no encontrado");
                    }
                    var vacunaNueva = new Vacuna(vacuna.FechaColocacion, tipoVacuna, mascota);

                    vacunasParaGuardar.Add(vacunaNueva);
                }

                mascota.SetVacunas(vacunasParaGuardar);
            }

            await repo.AddAsync(mascota);

            dto.IdMascota = mascota.IdMascota;
            dto.IdDuenio = idDuenioAsignado;
            return dto;
        }

        public async Task<MascotaDTO?> GetAsync(int id)
        {
            var mascota = await repo.GetAsync(id);
            if (mascota == null)
            {
                return null;
            }

            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio" )
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (mascota.Duenio?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No tiene permiso para acceder a esta mascota.");
                }
            }

            return new MascotaDTO
            {
                IdMascota = mascota.IdMascota,
                NombreMascota = mascota.NombreMascota,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                Castrado = mascota.Castrado,
                Sexo = mascota.Sexo,
                FechaNac = mascota.FechaNac,
                IdDuenio = mascota.Duenio?.IdPersona ?? 0,
                Vacunas = mascota.Vacunas?.Select(v => new VacunaDTO
                {
                    IdMascota = v.IdMascota,
                    IdTipoVacuna = v.IdTipoVacuna,
                    FechaColocacion = v.FechaColocacion
                }).ToList() ?? new List<VacunaDTO>()
            };
        }

        public async Task<IEnumerable<MascotaDTO>> GetAllAsync()
        {
            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                int currentUserId = userContext.GetCurrentUserId();
                return await GetAllByDuenioAsync(currentUserId);
            }

            IEnumerable<Mascota> mascotas = await repo.GetAllAsync();
            return [.. mascotas.Select(mascota => new MascotaDTO
            {
                IdMascota = mascota.IdMascota,
                NombreMascota = mascota.NombreMascota,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                Castrado = mascota.Castrado,
                Sexo = mascota.Sexo,
                FechaNac = mascota.FechaNac,
                IdDuenio = mascota.Duenio?.IdPersona ?? 0,
                Vacunas = mascota.Vacunas?.Select(v => new VacunaDTO
                {
                    IdMascota = v.IdMascota,
                    IdTipoVacuna = v.IdTipoVacuna,
                    FechaColocacion = v.FechaColocacion
                }).ToList() ?? new List<VacunaDTO>()
            })];
        }

        public async Task<IEnumerable<MascotaDTO>> GetAllByDuenioAsync(int idDuenio)
        {
            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (idDuenio != currentUserId)
                {
                    throw new UnauthorizedAccessException("No tiene permiso para acceder a esta mascota.");
                }
            }

            var duenio = await repoDuenio.GetAsync(idDuenio) ?? throw new ArgumentException("Dueño no encontrado");
            IEnumerable<Mascota> mascotas = await repo.GetAllByDuenioAsync(duenio);

            return [.. mascotas.Select(mascota => new MascotaDTO
            {
                IdMascota = mascota.IdMascota,
                NombreMascota = mascota.NombreMascota,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                Castrado = mascota.Castrado,
                Sexo = mascota.Sexo,
                FechaNac = mascota.FechaNac,
                IdDuenio = idDuenio,
                Vacunas = mascota.Vacunas?.Select(v => new VacunaDTO
                {
                    IdMascota = v.IdMascota,
                    IdTipoVacuna = v.IdTipoVacuna,
                    FechaColocacion = v.FechaColocacion
                }).ToList() ?? new List<VacunaDTO>()
            })];
        }

        public async Task<bool> UpdateAsync(MascotaDTO dto)
        {
            var mascota = await repo.GetAsync(dto.IdMascota);
            if (mascota == null) throw new KeyNotFoundException("Mascota no encontrada");

            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (mascota.Duenio?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No tiene permiso para acceder a esta mascota.");
                }
            }

            mascota.SetNombreMascota(dto.NombreMascota);
            mascota.SetEspecie(dto.Especie);
            mascota.SetRaza(dto.Raza);
            mascota.SetCastrado(dto.Castrado);
            mascota.SetSexo(dto.Sexo);
            mascota.SetFechaNac(dto.FechaNac);

            mascota?.Vacunas?.Clear();

            if (dto.Vacunas != null && dto.Vacunas.Any())
            {
                var idsTiposVacunas = dto.Vacunas.Select(v => v.IdTipoVacuna).Distinct().ToList();
                var tiposVacunaDb = await repoTipoVacuna.GetByIdListAsync(idsTiposVacunas);

                var vacunasParaGuardar = new List<Vacuna>();

                foreach (var vacunaDto in dto.Vacunas)
                {
                    var tipoVacuna = tiposVacunaDb.FirstOrDefault(t => t.IdTipoVacuna == vacunaDto.IdTipoVacuna);
                    if (tipoVacuna == null)
                    {
                        throw new ArgumentException($"Tipo de vacuna con ID {vacunaDto.IdTipoVacuna} no encontrado");
                    }

                    var vacunaNueva = new Vacuna(vacunaDto.FechaColocacion, tipoVacuna, mascota!);
                    vacunasParaGuardar.Add(vacunaNueva);
                }

                mascota?.SetVacunas(vacunasParaGuardar);
            }

            return await repo.UpdateAsync(mascota!);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var mascota = await repo.GetAsync(id);
            if (mascota == null)
            {
                return false;
            }

            string rol = userContext.GetCurrentRole();

            if (rol == "Duenio")
            {
                int currentUserId = userContext.GetCurrentUserId();
                if (mascota.Duenio?.IdPersona != currentUserId)
                {
                    throw new UnauthorizedAccessException("No tiene permiso para acceder a esta mascota.");
                }
            }

            return await repo.DeleteAsync(id);
        }
    }
}
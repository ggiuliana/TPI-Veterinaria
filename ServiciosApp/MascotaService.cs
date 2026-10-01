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

        public MascotaService(IMascotaRepository repo, IDuenioRepository repoDuenio, ITipoVacunaRepository repoTipoVacuna)
        {
            this.repo = repo;
            this.repoDuenio = repoDuenio;
            this.repoTipoVacuna = repoTipoVacuna;
        }

        public async Task<MascotaDTO> AddAsync(MascotaDTO dto)
        {
            var duenio = await repoDuenio.GetAsync(dto.IdDuenio) ?? throw new ArgumentException("Dueño no encontrado");
            Mascota mascota = new Mascota(
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
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }

        public async Task<MascotaDTO?> GetAsync(int id)
        {
            var mascota = await repo.GetAsync(id);
            if (mascota == null)
            {
                return null;
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
                IdDuenio = mascota.Duenio?.IdPersona ?? 0
            };
        }

        public async Task<IEnumerable<MascotaDTO>> GetAllAsync()
        {
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
                IdDuenio = mascota.Duenio?.IdPersona ?? 0
            })];
        }

        public async Task<IEnumerable<MascotaDTO>> GetAllByDuenioAsync(int idDuenio)
        {
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
                IdDuenio = mascota.Duenio?.IdPersona ?? 0   
            })];
        }

        public async Task<bool> UpdateAsync(MascotaDTO dto)
        {

            var duenio = await repoDuenio.GetAsync(dto.IdDuenio) ?? throw new ArgumentException("Dueño no encontrado");
            Mascota mascota = new Mascota(
                dto.IdMascota,
                dto.NombreMascota,
                dto.Especie,
                dto.Raza,
                dto.Castrado,
                dto.Sexo,
                dto.FechaNac,
                duenio);

            mascota.Vacunas.Clear();

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
                        throw new Exception($"Tipo de vacuna con ID {vacunaDto.IdTipoVacuna} no encontrado");
                    }

                    var vacunaNueva = new Vacuna(vacunaDto.FechaColocacion, tipoVacuna, mascota);

                    vacunasParaGuardar.Add(vacunaNueva);
                }
                mascota.SetVacunas(vacunasParaGuardar);
            }
            return await repo.UpdateAsync(mascota);
        }
    }
}

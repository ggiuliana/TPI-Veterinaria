using Data;
using DTOs;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosApp
{
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository repo;
        private readonly IDueñoRepository repoDueño;

        public MascotaService(IMascotaRepository repo, IDueñoRepository repoDueño)
        {
            this.repo = repo;
            this.repoDueño = repoDueño;
        }

        public async Task<MascotaDTO> AddAsync(MascotaDTO dto)
        {
            var dueño = await repoDueño.GetAsync(dto.IdDueño);
            if (dueño == null)
            {
                throw new Exception("Dueño no encontrado");
            }
            Mascota mascota = new Mascota(
                0,
                dto.NombreMascota,
                dto.Especie,
                dto.Raza,
                dto.Castrado,
                dto.Sexo,
                dto.FechaNac,
                dueño);
            await repo.AddAsync(mascota, dueño);
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
                IdDueño = mascota._dueño.IdPersona
            };
        }

        public async Task<IEnumerable<MascotaDTO>> GetAllAsync()
        {
            IEnumerable<Mascota> mascotas = await repo.GetAllAsync();
            return mascotas.Select(mascota => new MascotaDTO
            {
                IdMascota = mascota.IdMascota,
                NombreMascota = mascota.NombreMascota,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                Castrado = mascota.Castrado,
                Sexo = mascota.Sexo,
                FechaNac = mascota.FechaNac,
                IdDueño = mascota._dueño.IdPersona
            }).ToList();
        }

        public async Task<IEnumerable<MascotaDTO>> GetAllByDueñoAsync(int idDueño)
        {
            var dueño = await repoDueño.GetAsync(idDueño);
            if (dueño == null)
            {
                throw new Exception("Dueño no encontrado");
            }
            IEnumerable<Mascota> mascotas = await repo.GetAllByDueñoAsync(dueño);
            return mascotas.Select(mascota => new MascotaDTO
            {
                IdMascota = mascota.IdMascota,
                NombreMascota = mascota.NombreMascota,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                Castrado = mascota.Castrado,
                Sexo = mascota.Sexo,
                FechaNac = mascota.FechaNac,
                IdDueño = mascota._dueño.IdPersona
            }).ToList();
        }

        public async Task<bool> UpdateAsync(MascotaDTO dto)
        {

            Console.WriteLine(dto.IdDueño);
            var dueño = await repoDueño.GetAsync(dto.IdDueño);

            if (dueño == null)
            {
                throw new Exception("Dueño no encontrado");
            }
            Mascota mascota = new Mascota(
                dto.IdMascota,
                dto.NombreMascota,
                dto.Especie,
                dto.Raza,
                dto.Castrado,
                dto.Sexo,
                dto.FechaNac,
                dueño);
            return await repo.UpdateAsync(mascota, dueño);
        }
    }
}

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
        private readonly IDuenioRepository repoDuenio;

        public MascotaService(IMascotaRepository repo, IDuenioRepository repoDuenio)
        {
            this.repo = repo;
            this.repoDuenio = repoDuenio;
        }

        public async Task<MascotaDTO> AddAsync(MascotaDTO dto)
        {
            var duenio = await repoDuenio.GetAsync(dto.IdDuenio);
            if (duenio == null)
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
                duenio);
            await repo.AddAsync(mascota, duenio);
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
                IdDuenio = mascota._duenio.IdPersona
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
                IdDuenio = mascota._duenio.IdPersona
            }).ToList();
        }

        public async Task<IEnumerable<MascotaDTO>> GetAllByDuenioAsync(int idDuenio)
        {
            var duenio = await repoDuenio.GetAsync(idDuenio);
            if (duenio == null)
            {
                throw new Exception("Dueño no encontrado");
            }
            IEnumerable<Mascota> mascotas = await repo.GetAllByDuenioAsync(duenio);
            return mascotas.Select(mascota => new MascotaDTO
            {
                IdMascota = mascota.IdMascota,
                NombreMascota = mascota.NombreMascota,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                Castrado = mascota.Castrado,
                Sexo = mascota.Sexo,
                FechaNac = mascota.FechaNac,
                IdDuenio = mascota._duenio.IdPersona
            }).ToList();
        }

        public async Task<bool> UpdateAsync(MascotaDTO dto)
        {

            Console.WriteLine(dto.IdDuenio);
            var duenio = await repoDuenio.GetAsync(dto.IdDuenio);

            if (duenio == null)
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
                duenio);
            return await repo.UpdateAsync(mascota, duenio);
        }
    }
}

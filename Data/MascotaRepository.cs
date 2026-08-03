using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MascotaRepository : IMascotaRepository
    {
        public static readonly List<Mascota> mascotas = new();
        private static int nextId = 1;
        private readonly DuenioRepository _duenioRepository = new DuenioRepository();

        public async Task AddAsync(Mascota mascota, Duenio duenio)
        {
            mascota.IdMascota = nextId;
            nextId++;
            mascota.SetDuenio(duenio);
            mascotas.Add(mascota);
            return;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var mascota = mascotas.FirstOrDefault(m => m.IdMascota == id);
            if (mascota != null)
            {
                mascotas.Remove(mascota);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Mascota?> GetAsync(int id)
        {
            return Task.FromResult(mascotas.FirstOrDefault(m => m.IdMascota == id));
        }

        public Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Mascota>>(mascotas.ToList());
        }

        public Task<IEnumerable<Mascota>> GetAllByDuenioAsync(Duenio duenio)
        {
            var mascotasDelDuenio = mascotas.Where(m => m._duenio == duenio).ToList();
            return Task.FromResult<IEnumerable<Mascota>>(mascotasDelDuenio);
        }

        public Task<bool> UpdateAsync(Mascota mascota, Duenio duenio)
        {
            var existing = mascotas.FirstOrDefault(m => m.IdMascota == mascota.IdMascota);
            if (existing != null)
            {
                existing.SetNombreMascota(mascota.NombreMascota);
                existing.SetEspecie(mascota.Especie);
                existing.SetRaza(mascota.Raza);
                existing.Castrado = mascota.Castrado;
                existing.SetSexo(mascota.Sexo);
                existing.SetFechaNac(mascota.FechaNac);
                existing.SetDuenio(duenio);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}

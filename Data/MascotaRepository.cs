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
        private readonly DueñoRepository _dueñoRepository = new DueñoRepository();

        public async Task AddAsync(Mascota mascota, Dueño dueño)
        {
            mascota.IdMascota = nextId;
            nextId++;
            mascota.SetDueño(dueño);
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

        public Task<IEnumerable<Mascota>> GetAllByDueñoAsync(Dueño dueño)
        {
            var mascotasDelDueño = mascotas.Where(m => m._dueño == dueño).ToList();
            return Task.FromResult<IEnumerable<Mascota>>(mascotasDelDueño);
        }

        public Task<bool> UpdateAsync(Mascota mascota, Dueño dueño)
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
                existing.SetDueño(dueño);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}

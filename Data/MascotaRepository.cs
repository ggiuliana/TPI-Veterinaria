using ModeloDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly VeterinariaContext context;

        public MascotaRepository(VeterinariaContext context) {
            this.context = context;
        }

        public async Task AddAsync(Mascota mascota, Duenio duenio)
        {
            mascota.SetDuenio(duenio);
            context.Mascotas.Add(mascota);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Mascota = await context.Mascotas.FindAsync(id);
            if (Mascota != null)
            {
                context.Mascotas.Remove(Mascota);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Mascota?> GetAsync(int id)
        {
            return await context.Mascotas.FirstOrDefaultAsync(m => m.IdMascota == id);
        }

        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await context.Mascotas.ToListAsync();
        }

        public async Task<IEnumerable<Mascota>> GetAllByDuenioAsync(Duenio duenio)
        {
            return await context.Mascotas.Where(m => m.Duenio == duenio).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Mascota mascota)
        {
            var existingMascota = await context.Mascotas.FindAsync(mascota); ;
            if (existingMascota != null)
            {
                existingMascota.SetNombreMascota(mascota.NombreMascota);
                existingMascota.SetEspecie(mascota.Especie);
                existingMascota.SetRaza(mascota.Raza);
                existingMascota.SetCastrado(mascota.Castrado);
                existingMascota.SetSexo(mascota.Sexo);
                existingMascota.SetFechaNac(mascota.FechaNac);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

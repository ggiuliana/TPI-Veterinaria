using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IMascotaRepository
    {
        Task AddAsync(Mascota mascota, Dueño dueño);
        Task<bool> DeleteAsync(int id);
        Task<Mascota?> GetAsync(int id);
        Task<IEnumerable<Mascota>> GetAllAsync();
        Task<IEnumerable<Mascota>> GetAllByDueñoAsync(Dueño dueño);
        Task<bool> UpdateAsync(Mascota mascota, Dueño dueño);
    }
}

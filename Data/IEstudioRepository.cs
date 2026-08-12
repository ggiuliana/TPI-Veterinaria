using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IEstudioRepository
    {
        Task AddAsync(Estudio estudio);
        Task<bool> DeleteAsync(int id);
        Task<Estudio?> GetAsync(int id);
        Task<IEnumerable<Estudio>> GetAllAsync();
        Task<bool> UpdateAsync(Estudio estudio);
    }
}

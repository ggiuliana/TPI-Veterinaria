using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Data
{
    public interface ITipoVacunaRepository
    {
        Task AddAsync(TipoVacuna tipovacuna);
        Task<bool> DeleteAsync(int id);
        Task<TipoVacuna?> GetAsync(int id);
        Task<IEnumerable<TipoVacuna>> GetAllAsync();
        Task<bool> UpdateAsync(TipoVacuna tipoVacuna);
    }
}

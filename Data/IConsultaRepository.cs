using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IConsultaRepository
    {
        Task AddAsync(Consulta consulta);
        Task<Consulta?> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Consulta>> GetAllAsync();
        Task<bool> UpdateAsync(Consulta consulta);
    }
}

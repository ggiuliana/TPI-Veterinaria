using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModeloDominio;

namespace Data
{
    public interface IMedicamentoRepository
    {
        Task AddAsync(Medicamento medicamento);
        Task<bool> DeleteAsync(int id);
        Task<Medicamento?> GetAsync(int id);
        Task<IEnumerable<Medicamento>> GetAllAsync();
        Task<bool> UpdateAsync(Medicamento medicamento);
    }
}

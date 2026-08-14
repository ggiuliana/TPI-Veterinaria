using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public interface IMedicamentoService
    {
        Task<MedicamentoDTO> AddAsync(MedicamentoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<MedicamentoDTO?> GetAsync(int id);
        Task<IEnumerable<MedicamentoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(MedicamentoDTO dto);
    }
}

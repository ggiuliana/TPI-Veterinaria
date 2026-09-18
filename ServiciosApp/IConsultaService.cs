using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosApp
{
    public interface IConsultaService
    {
        Task<ConsultaDTO> AddAsync(ConsultaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<ConsultaDTO?> GetAsync(int id);
        Task<IEnumerable<ConsultaDTO>> GetAllAsync();
        Task<bool> UpdateAsync(ConsultaDTO dto);
    }
}

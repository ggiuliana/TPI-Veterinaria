using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosApp
{
    public interface ITurnoService
    {
        Task<TurnoDTO> AddAsync(TurnoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<TurnoDTO?> GetAsync(int id);
        Task<IEnumerable<TurnoDTO>> GetAllAsync();
        Task<bool> UpdateAsync(TurnoDTO dto);
    }
}

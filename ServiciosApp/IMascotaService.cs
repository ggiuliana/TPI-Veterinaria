using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosApp
{
    public interface IMascotaService
    {
        Task<MascotaDTO> AddAsync(MascotaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<MascotaDTO?> GetAsync(int id);
        Task<IEnumerable<MascotaDTO>> GetAllAsync();
        Task<IEnumerable<MascotaDTO>> GetAllByDuenioAsync(int idDuenio);
        Task<bool> UpdateAsync(MascotaDTO dto);
    }
}

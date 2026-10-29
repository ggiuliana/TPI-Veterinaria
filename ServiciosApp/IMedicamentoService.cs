using DTOs;

namespace ServiciosApp
{
    public interface IMedicamentoService
    {
        Task<MedicamentoDTO> AddAsync(MedicamentoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<MedicamentoDTO?> GetAsync(int id);
        Task<IEnumerable<MedicamentoDTO>> GetAllAsync();
        Task<(IEnumerable<MedicamentoDTO> Agotados, IEnumerable<MedicamentoDTO> StockBajo, IEnumerable<MedicamentoDTO> StockSuficiente)> GetMedicamentosClasificadosPorStockAsync();
        Task<bool> UpdateAsync(MedicamentoDTO dto);
    }
}

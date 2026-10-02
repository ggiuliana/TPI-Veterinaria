using DTOs; 


namespace ServiciosApp
{
    public interface IMedicamentoConsultaService
    {
        Task<List<MedicamentoConsultaDTO>> GetByConsultaIdAsync(int idConsulta);
        Task AddAsync(MedicamentoConsultaDTO dto);
        Task DeleteAsync(int idConsulta, int idMedicamento);
    }
}

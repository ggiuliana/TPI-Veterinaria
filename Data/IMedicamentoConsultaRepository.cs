using ModeloDominio;

namespace Data
{
    public interface IMedicamentoConsultaRepository
    {
        Task<List<MedicamentoConsulta>> GetByConsultaIdAsync(int idConsulta);
        Task AddAsync(MedicamentoConsulta detalle);
        Task DeleteAsync(int idConsulta, int idMedicamento);
    }
}

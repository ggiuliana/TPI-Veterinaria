using ModeloDominio;

namespace Data
{
    public interface IConsultaRepository
    {
        Task AddAsync(Consulta consulta);
        Task<Consulta?> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Consulta>> GetAllAsync();
        Task<bool> UpdateAsync(Consulta consulta);
        Task<Consulta?> GetByIdTurnoAsync(int idTurno);
    }
}

using ModeloDominio;

namespace Data
{
    public interface ITurnoRepository
    {
        Task AddAsync(Turno turno);
        Task<Turno?> GetAsync(int id);
        Task<IEnumerable<Turno>> GetByVeterinarioIdAsync(int idVeterinario);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Turno>> GetAllAsync();
        Task<IEnumerable<Turno>> GetDisponiblesAsync();
        Task<IEnumerable<Turno>> GetTurnosFiltradosAsync(int? idVeterinario, string? estado, DateOnly? fechaDesde, DateOnly? fechaHasta);
        Task<bool> UpdateAsync(Turno turno);
    }
}

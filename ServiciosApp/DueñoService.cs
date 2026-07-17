using DTOs;
using Data;
using ModeloDominio;
namespace ServiciosApp
{
    public class DueñoService : IDueñoService
    {
        private readonly IDueñoRepository repo;

        public DueñoService(IDueñoRepository repo)
        {
            this.repo = repo;
        }
        public async Task<DueñoDTO> AddAsync(DueñoDTO dto)
        {
            if (await repo.MailExistsAsync(dto.Mail))
            {
                throw new ArgumentException($"Ya existe un dueño con el Email '{dto.Mail}'.");
            }
            Dueño dueño = new Dueño(0, dto.NombreDueño, dto.Apellido, dto.Telefono, dto.Mail, dto.Dni, dto.Direccion);
            await repo.AddAsync(dueño);
            dto.IdDueño = dueño.IdPersona;
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
        public async Task<DueñoDTO?> GetAsync(int id)
        {
            Dueño? dueño = await repo.GetAsync(id);
            if (dueño == null)
            {
                return null;
            }
            return new DueñoDTO
            {
                IdDueño = dueño.IdPersona,
                NombreDueño = dueño.NombrePersona,
                Apellido = dueño.Apellido,
                Telefono = dueño.Telefono,
                Mail = dueño.Mail,
                Dni = dueño.Dni,
                Direccion = dueño.Direccion
            };

        }

        public async Task<IEnumerable<DueñoDTO>> GetAllAsync()
        {
            IEnumerable<Dueño> dueños = await repo.GetAllAsync();
            return dueños.Select(dueño => new DueñoDTO
            {
                IdDueño = dueño.IdPersona,
                NombreDueño = dueño.NombrePersona,
                Apellido = dueño.Apellido,
                Telefono = dueño.Telefono,
                Mail = dueño.Mail,
                Dni = dueño.Dni,
                Direccion = dueño.Direccion
            }).ToList();
        }
        public async Task<bool> UpdateAsync(DueñoDTO dto)
        {
            if (await repo.MailExistsAsync(dto.Mail))
            {
                throw new ArgumentException($"Ya existe un dueño con el Email '{dto.Mail}'.");
            }
            Dueño dueño = new Dueño(dto.IdDueño, dto.NombreDueño, dto.Apellido, dto.Telefono, dto.Mail, dto.Dni, dto.Direccion);
            return await repo.UpdateAsync(dueño);
        }
        public async Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            return await repo.MailExistsAsync(mail, excludeId);
        }
    }
}

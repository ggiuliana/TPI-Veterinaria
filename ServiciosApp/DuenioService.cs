using DTOs;
using Data;
using ModeloDominio;

namespace ServiciosApp
{
    public class DuenioService : IDuenioService
    {
        private readonly IDuenioRepository repo;

        public DuenioService(IDuenioRepository repo)
        {
            this.repo = repo;
        }
        public async Task<DuenioDTO> AddAsync(DuenioDTO dto)
        {
            if (await repo.MailExistsAsync(dto.Mail))
            {
                throw new ArgumentException($"Ya existe un dueño con el Email '{dto.Mail}'.");
            }
            Duenio duenio = new Duenio(0, dto.NombreDuenio, dto.Apellido, dto.Telefono, dto.Mail, dto.Dni, dto.Direccion);
            await repo.AddAsync(duenio);
            dto.IdDuenio = duenio.IdPersona;
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
        public async Task<DuenioDTO?> GetAsync(int id)
        {
            Duenio? duenio = await repo.GetAsync(id);
            if (duenio == null)
            {
                return null;
            }
            return new DuenioDTO
            {
                IdDuenio = duenio.IdPersona,
                NombreDuenio = duenio.NombrePersona,
                Apellido = duenio.Apellido,
                Telefono = duenio.Telefono,
                Mail = duenio.Mail,
                Dni = duenio.Dni,
                Direccion = duenio.Direccion
            };

        }

        public async Task<IEnumerable<DuenioDTO>> GetAllAsync()
        {
            IEnumerable<Duenio> duenios = await repo.GetAllAsync();
            return duenios.Select(duenio => new DuenioDTO
            {
                IdDuenio = duenio.IdPersona,
                NombreDuenio = duenio.NombrePersona,
                Apellido = duenio.Apellido,
                Telefono = duenio.Telefono,
                Mail = duenio.Mail,
                Dni = duenio.Dni,
                Direccion = duenio.Direccion
            }).ToList();
        }
        public async Task<bool> UpdateAsync(DuenioDTO dto)
        {
            if (await repo.MailExistsAsync(dto.Mail))
            {
                throw new ArgumentException($"Ya existe un dueño con el Email '{dto.Mail}'.");
            }
            Duenio duenio = new Duenio(dto.IdDuenio, dto.NombreDuenio, dto.Apellido, dto.Telefono, dto.Mail, dto.Dni, dto.Direccion);
            return await repo.UpdateAsync(duenio);
        }
        public async Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            return await repo.MailExistsAsync(mail, excludeId);
        }
    }
}

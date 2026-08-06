using DTOs;
using Data;
using ModeloDominio;

namespace ServiciosApp
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IVeterinarioRepository repo;

        public VeterinarioService(IVeterinarioRepository repo)
        {
            this.repo = repo;
        }
        public async Task<VeterinarioDTO> AddAsync(VeterinarioDTO dto)
        {
            if (await repo.MailExistsAsync(dto.Mail))
            {
                throw new ArgumentException($"Ya existe un veterinario con el Email '{dto.Mail}'.");
            }
            Veterinario veterinario = new Veterinario(0, dto.NombreVeterinario, dto.Apellido, dto.Telefono, dto.Mail, dto.Dni, dto.Direccion, dto.Matricula, dto.Especialidad);
            await repo.AddAsync(veterinario);
            dto.IdVeterinario= veterinario.IdPersona;
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
        public async Task<VeterinarioDTO?> GetAsync(int id)
        {
            Veterinario? veterinario = await repo.GetAsync(id);
            if (veterinario == null)
            {
                return null;
            }
            return new VeterinarioDTO
            {
                IdVeterinario = veterinario.IdPersona,
                NombreVeterinario= veterinario.NombrePersona,
                Apellido = veterinario.Apellido,
                Telefono = veterinario.Telefono,
                Mail = veterinario.Mail,
                Dni = veterinario.Dni,
                Direccion = veterinario.Direccion
            };

        }
        public async Task<IEnumerable<VeterinarioDTO>> GetAllAsync()
        {
            IEnumerable<Veterinario> veterinarios = await repo.GetAllAsync();
            return veterinarios.Select(veterinario => new VeterinarioDTO
            {
                IdVeterinario = veterinario.IdPersona,
                NombreVeterinario = veterinario.NombrePersona,
                Apellido = veterinario.Apellido,
                Telefono = veterinario.Telefono,
                Mail = veterinario.Mail,
                Dni = veterinario.Dni,
                Direccion = veterinario.Direccion,
                Matricula = veterinario.Matricula,
                Especialidad = veterinario.Especialidad
            }).ToList();
        }
        public async Task<bool> UpdateAsync(VeterinarioDTO dto)
        {
            if (await repo.MailExistsAsync(dto.Mail))
            {
                throw new ArgumentException($"Ya existe un veterinario con el Email '{dto.Mail}'.");
            }
            Veterinario veterinario = new Veterinario(dto.IdVeterinario, dto.NombreVeterinario, dto.Apellido, dto.Telefono, dto.Mail, dto.Dni, dto.Direccion, dto.Matricula, dto.Especialidad);
            return await repo.UpdateAsync(veterinario);
        }
        public async Task<bool> MailExistsAsync(string mail, int? excludeId = null)
        {
            return await repo.MailExistsAsync(mail, excludeId);
        }
        public async Task<bool> MatriculaExistsAsync(string matricula, int? excludeId = null)
        {
            return await repo.MatriculaExistsAsync(matricula, excludeId);
        }
    }
}


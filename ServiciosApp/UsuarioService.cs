using DTOs;
using Data;
using ModeloDominio;

namespace ServiciosApp
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repo;
        private readonly IDuenioRepository repoDuenio;
        private readonly IVeterinarioRepository repoVeterinario;

        public UsuarioService(IUsuarioRepository repo, IDuenioRepository repoDuenio, IVeterinarioRepository repoVeterinario)
        {
            this.repo = repo;
            this.repoDuenio = repoDuenio;
            this.repoVeterinario = repoVeterinario;
        }
        private async Task<Persona> BuscarPersonaPorIdAsync(int idPersona)
        {
            Persona? personaEncontrada = await repoDuenio.GetAsync(idPersona);

            if (personaEncontrada == null)
                personaEncontrada = await repoVeterinario.GetAsync(idPersona);

            if (personaEncontrada == null)
                throw new ArgumentException($"No se encontró ningún Dueño ni Veterinario con el ID {idPersona}.");

            return personaEncontrada;
        }
        public async Task<UsuarioDTO> AddAsync(UsuarioDTO dto)
        {
            if (await repo.NombreUsuarioExistsAsync(dto.NombreUsuario))
                throw new ArgumentException($"El nombre de usuario '{dto.NombreUsuario}' ya está en uso. Por favor, elija otro.");

            Persona persona = await BuscarPersonaPorIdAsync(dto.IdPersona);

            if (await repo.PersonaHasUsuarioAsync(dto.IdPersona))
                throw new ArgumentException($"La persona ya tiene una cuenta de usuario asignada.");

            DateTime fechaAltaReal = DateTime.Now;
            Usuario usuario = new Usuario(0, dto.NombreUsuario, dto.Contrasenia, dto.EstadoUsuario, fechaAltaReal, persona);
            await repo.AddAsync(usuario);

            dto.IdUsuario = usuario.IdUsuario;
            dto.FechaAlta = fechaAltaReal;

            return dto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
        public async Task<UsuarioDTO?> GetAsync(int id)
        {
            Usuario? usuario= await repo.GetAsync(id);
            if (usuario == null)
            {
                return null;
            }
            return new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsuario = usuario.NombreUsuario,
                Contrasenia = usuario.Contrasenia,
                EstadoUsuario = usuario.EstadoUsuario,
                FechaAlta = usuario.FechaAlta,
                IdPersona = usuario.Persona?.IdPersona ?? 0
            };
        }
        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            IEnumerable<Usuario> usuarios = await repo.GetAllAsync();
            return usuarios.Select(usuario => new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsuario = usuario.NombreUsuario,
                Contrasenia = usuario.Contrasenia,
                EstadoUsuario = usuario.EstadoUsuario,
                FechaAlta = usuario.FechaAlta,
                IdPersona = usuario.Persona?.IdPersona ?? 0
            }).ToList();
        }
        public async Task<bool> UpdateAsync(UsuarioDTO dto)
        {
            if (await repo.NombreUsuarioExistsAsync(dto.NombreUsuario))
                throw new ArgumentException($"Ya existe un usuario con el nombre de usuario '{dto.NombreUsuario}'.");
            
            Persona persona = await BuscarPersonaPorIdAsync(dto.IdPersona);
            
            if (await repo.PersonaHasUsuarioAsync(dto.IdPersona))
                throw new ArgumentException($"La persona ya tiene una cuenta de usuario asignada.");
            
            Usuario usuario = new Usuario(dto.IdUsuario, dto.NombreUsuario, dto.Contrasenia, dto.EstadoUsuario, dto.FechaAlta, persona);
            return await repo.UpdateAsync(usuario);
        }
    }
}


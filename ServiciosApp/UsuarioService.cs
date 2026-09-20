using DTOs;
using Data;
using ModeloDominio;

namespace ServiciosApp
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repo;
        private readonly IGrupoPermisoRepository repoGrupo;
        private readonly IDuenioRepository repoDuenio;
        private readonly IVeterinarioRepository repoVeterinario;

        public UsuarioService(
            IUsuarioRepository repo, IDuenioRepository repoDuenio, IVeterinarioRepository repoVeterinario, IGrupoPermisoRepository repoGrupo)
        {
            this.repo = repo;
            this.repoDuenio = repoDuenio;
            this.repoVeterinario = repoVeterinario;
            this.repoGrupo = repoGrupo;
        }
        private async Task<Persona> BuscarPersonaPorIdAsync(int idPersona)
        {
            Persona? personaEncontrada = await repoDuenio.GetAsync(idPersona);

            personaEncontrada ??= await repoVeterinario.GetAsync(idPersona);

            if (personaEncontrada == null)
                throw new ArgumentException($"No se encontró ningún Dueño ni Veterinario con el ID {idPersona}.");

            return personaEncontrada;
        }
        public async Task<UsuarioCreateDTO> AddAsync(UsuarioCreateDTO dto)
        {
            if (await repo.NombreUsuarioExistsAsync(dto.NombreUsuario))
                throw new ArgumentException($"El nombre de usuario '{dto.NombreUsuario}' ya está en uso. Por favor, elija otro.");

            Persona persona = await BuscarPersonaPorIdAsync(dto.IdPersona);

            if (await repo.PersonaHasUsuarioAsync(dto.IdPersona))
                throw new ArgumentException($"La persona ya tiene una cuenta de usuario asignada.");

            GrupoPermiso? grupo = await repoGrupo.GetAsync(dto.IdGrupo) ?? throw new ArgumentException($"No existe el grupo asignado.");
            Usuario usuario = new(0, dto.NombreUsuario, dto.Contrasenia, "Activo", persona, grupo);
            await repo.AddAsync(usuario);

            dto.IdUsuario = usuario.IdUsuario;

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
                EstadoUsuario = usuario.EstadoUsuario,
                FechaAlta = usuario.FechaAlta,
                IdPersona = usuario.Persona?.IdPersona ?? 0
            });
        }
        public async Task<bool> UpdateAsync(UsuarioCreateDTO dto)
        {
            if (await repo.NombreUsuarioExistsAsync(dto.NombreUsuario))
                throw new ArgumentException($"Ya existe un usuario con el nombre de usuario '{dto.NombreUsuario}'.");
            
            Usuario usuario = new(dto.IdUsuario, dto.NombreUsuario, dto.Contrasenia, "Activo");
            return await repo.UpdateAsync(usuario);
        }

        public async Task<bool> RegisterVetAsync(VeterinarioRegisterDTO dto)
        {
            var vet = dto.veterinario;
            var usu = dto.usuario;

            if (await repoVeterinario.MailExistsAsync(vet.Mail))
            {
                throw new ArgumentException($"Ya existe una persona con el Email '{vet.Mail}'.");
            }

            if (await repoVeterinario.MatriculaExistsAsync(vet.Matricula))
            {
                throw new ArgumentException($"Ya existe un veterinario con la Matrícula '{vet.Matricula}'.");
            }

            Veterinario veterinario = new Veterinario
                (
                0,
                vet.NombreVeterinario,
                vet.Apellido,
                vet.Telefono,
                vet.Mail,
                vet.Dni,
                vet.Direccion,
                vet.Matricula,
                vet.Especialidad
                );
            Usuario usuario = new Usuario
                (
                0,
                usu.NombreUsuario,
                usu.Contrasenia,
                "Activo",
                veterinario,
                await repoGrupo.GetAsync(2)
                );

            return await repo.RegisterAsync(veterinario, usuario);
        }

        public async Task<bool> RegisterDuenioAsync(DuenioRegisterDTO dto)
        {
            var duenio = dto.duenio;
            var usu = dto.usuario;

            if (await repoDuenio.MailExistsAsync(duenio.Mail))
            {
                throw new ArgumentException($"Ya existe una persona con el Email '{duenio.Mail}'.");
            }

            Duenio duenioNuevo = new Duenio
                (
                0,
                duenio.NombreDuenio,
                duenio.Apellido,
                duenio.Telefono,
                duenio.Mail,
                duenio.Dni,
                duenio.Direccion
                );
            Usuario usuario = new Usuario
                (
                0,
                usu.NombreUsuario,
                usu.Contrasenia,
                "Activo"
                );

            return await repo.RegisterAsync(duenioNuevo, usuario);
        }

    }
}


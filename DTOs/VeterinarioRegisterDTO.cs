namespace DTOs
{
    public class VeterinarioRegisterDTO
    {
        public VeterinarioDTO veterinario { get; set; } = new VeterinarioDTO();
        public UsuarioCreateDTO usuario { get; set; } = new UsuarioCreateDTO();
    }
}

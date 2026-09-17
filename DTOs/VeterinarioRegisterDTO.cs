using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class VeterinarioRegisterDTO
    {
        public VeterinarioDTO veterinario { get; set; } = new VeterinarioDTO();
        public UsuarioCreateDTO usuario { get; set; } = new UsuarioCreateDTO();
    }
}

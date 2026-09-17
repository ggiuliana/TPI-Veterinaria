using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DuenioRegisterDTO
    {
        public DuenioDTO duenio { get; set; } = new DuenioDTO();
        public UsuarioCreateDTO usuario { get; set; } = new UsuarioCreateDTO();
    }
}

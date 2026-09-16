using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UsuarioResponseDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string EstadoUsuario { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
    }
}

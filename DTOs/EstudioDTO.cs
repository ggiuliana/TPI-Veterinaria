using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EstudioDTO
    {
        public int IdEstudio { get; set; }
        public string NombreEstudio { get; set; } = string.Empty;
        public string DescripcionEstudio { get; set; } = string.Empty;
    }
}

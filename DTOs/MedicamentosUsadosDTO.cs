using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MedicamentosUsadosDTO
    {
        public int IdConsulta { get; set; }
        public int IdMedicamento { get; set; }
        public int CantidadUsada { get; set; }
    }
}

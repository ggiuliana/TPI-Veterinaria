using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MedicamentoDTO
    {
        public int IdMedicamento { get; set; }
        public string NombreMedicamento { get; set; }
        public int CantidadRestante { get; set; }
    }
}

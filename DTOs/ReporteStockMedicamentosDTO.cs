using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReporteStockMedicamentosDTO
    {
        public List<MedicamentoDTO> Agotados { get; set; } = new ();
        public List<MedicamentoDTO> StockBajo { get; set; } = new ();
        public List<MedicamentoDTO> StockSuficiente { get; set; } = new ();
    }
}

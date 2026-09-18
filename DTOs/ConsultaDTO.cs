using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ConsultaDTO
    {
        public int IdConsulta { get; set; }
        public string Diagnostico { get; set; } = null!;
        public string Tratamiento { get; set; } = null!;
        public float Peso { get; set; }
        public string? Observaciones { get; set; }
        public int IdTurno { get; set; }
        public ICollection<int>? IdEstudios { get; set; } = null!;
        public ICollection<MedicamentosUsadosDTO>? MedicamentosUsados { get; set; } = null!;
    }
}


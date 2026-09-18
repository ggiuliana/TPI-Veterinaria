using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TurnoDTO
    {
        public int IdTurno { get; set; }
        public DateOnly FechaTurno { get; set; }
        public TimeOnly HoraTurno { get; set; }
        public string EstadoTurno { get; set; } = null!;
        public string? Observaciones { get; set; }
        public int IdVeterinario { get; set; }
        public int? IdMascota { get; set; }

    }
}

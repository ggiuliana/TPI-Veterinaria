using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MascotaDTO
    {
        public int IdMascota { get; set; }
        public string NombreMascota { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public bool Castrado { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNac { get; set; }
        public int IdDuenio { get; set; }
    }
}

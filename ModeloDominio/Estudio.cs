using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Estudio
    {
        public int IdEstudio { get; private set; }
        public string NombreEstudio { get; private set; }
        public string DescripcionEstudio { get; private set; }

        public Estudio() { }
        public Estudio(int idEstudio, string nombreEstudio, string descripcionEstudio) {
            SetIdEstudio(idEstudio);
            SetNombre(nombreEstudio);
            SetDescripcion(descripcionEstudio);
        }

        public void SetIdEstudio(int idEstudio) {
            IdEstudio = idEstudio;
        }

        public void SetNombre(string nombreEstudio) {
            NombreEstudio = nombreEstudio;
        }

        public void SetDescripcion(string descripcionEstudio) { 
            DescripcionEstudio = descripcionEstudio;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Vacuna
    {
        public DateOnly FechaColocacion { get; private set; }
        public int IdTipoVacuna { get; private set; }
        public TipoVacuna TipoVacuna { get; private set; } = null!;
        public int IdMascota { get; private set; }
        public Mascota Mascota { get; private set; } = null!;

        public Vacuna() { }

        public Vacuna(DateOnly fechaColocacion, TipoVacuna tipoVacuna, Mascota mascota)
        {
            SetFechaColocacion(fechaColocacion);
            SetTipoVacuna(tipoVacuna);
            SetMascota(mascota);
        }

        public void SetFechaColocacion(DateOnly fechaColocacion)
        {
            FechaColocacion = fechaColocacion;
        }

        public void SetTipoVacuna(TipoVacuna tipoVacuna)
        {
            TipoVacuna = tipoVacuna;
        }

        public void SetMascota(Mascota mascota)
        {
            Mascota = mascota;
        }


    }
}

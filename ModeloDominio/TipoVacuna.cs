using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class TipoVacuna
    {
        public int IdTipoVacuna { get; private set; }
        public string NombreTipoVacuna { get; private set; }
        public string DescripcionTipoVacuna { get; private set; }
        public TipoVacuna() { }
        public TipoVacuna(int idTipoVacuna, string nombreTipoVacuna, string descripcionTipoVacuna) {
            SetIdTipoVacuna(idTipoVacuna);
            SetNombreTipoVacuna(nombreTipoVacuna);
            SetDescripcionTipoVacuna(descripcionTipoVacuna);
        }
        public void SetIdTipoVacuna(int idTipoVacuna) {
            this.IdTipoVacuna = idTipoVacuna;
        }
        public void SetNombreTipoVacuna(string nombreTipoVacuna) {
            this.NombreTipoVacuna = nombreTipoVacuna;
        }
        public void SetDescripcionTipoVacuna(string descripcionTipoVacuna) {
            this.DescripcionTipoVacuna = descripcionTipoVacuna;
        }
    }
}

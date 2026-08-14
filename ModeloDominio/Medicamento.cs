using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Medicamento
    {
        public int IdMedicamento { get; private set; }
        public string NombreMedicamento { get; private set; }
        public int CantidadRestante { get; private set; }
        public Medicamento() { }
        public Medicamento(int idMedicamento, string nombreMedicamento, int cantidadRestante) {
            SetIdMedicamento(idMedicamento);
            SetNombreMedicamento(nombreMedicamento);
            SetCantidadRestante(cantidadRestante);
        }
        public void SetIdMedicamento(int idMedicamento) 
        {
            this.IdMedicamento = idMedicamento;
        }
        public void SetNombreMedicamento(string nombreMedicamento)
        {
            this.NombreMedicamento = nombreMedicamento;
        }
        public void SetCantidadRestante(int cantidadRestante)
        {
            this.CantidadRestante = cantidadRestante;    
        }
    }
}

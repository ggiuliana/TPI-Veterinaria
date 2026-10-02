namespace ModeloDominio
{
    public class Medicamento
    {
        public int IdMedicamento { get; private set; }
        public string NombreMedicamento { get; private set; } = string.Empty;
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
        public void DescontarStock(int cantidadAUsar)
        {
            if (cantidadAUsar <= 0)
                throw new ArgumentException("La cantidad a descontar debe ser mayor a 0.");

            if (CantidadRestante < cantidadAUsar)
                throw new InvalidOperationException("No hay stock suficiente para recetar esta cantidad.");

            CantidadRestante -= cantidadAUsar;
        }
        public void AgregarStock(int cantidadADevolver)
        {
            if (cantidadADevolver <= 0)
                throw new ArgumentException("La cantidad a devolver debe ser mayor a 0.");

            CantidadRestante += cantidadADevolver;
        }
    }
}

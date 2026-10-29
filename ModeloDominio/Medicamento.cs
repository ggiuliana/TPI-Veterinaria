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
            if (string.IsNullOrWhiteSpace(nombreMedicamento))
                throw new ArgumentException("El nombre del medicamento no puede estar vacío.");

            this.NombreMedicamento = nombreMedicamento;
        }
        public void SetCantidadRestante(int cantidadRestante)
        {
            if (cantidadRestante < 0)
                throw new ArgumentException("El stock del medicamento no puede ser negativo.");

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

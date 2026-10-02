namespace ModeloDominio
{
    public class MedicamentoConsulta
    {
        public int IdConsulta { get; private set; }
        public Consulta? Consulta { get; private set; }
        public int IdMedicamento { get; private set; }
        public Medicamento? Medicamento { get; private set; }
        public int CantidadUsada { get; private set; }

        public MedicamentoConsulta() { }

        public MedicamentoConsulta(int idConsulta, int idMedicamento, int cantidadUsada)
        {
            SetIdConsulta(idConsulta);
            SetIdMedicamento(idMedicamento);
            SetCantidadUsada(cantidadUsada);
        }
        public void SetIdConsulta(int idConsulta)
        {
            IdConsulta = idConsulta;
        }

        public void SetIdMedicamento(int idMedicamento)
        {
            IdMedicamento = idMedicamento;
        }

        public void SetCantidadUsada(int cantidadUsada)
        {
            if (cantidadUsada < 0)
                throw new ArgumentException("La cantidad usada debe ser mayor o igual a 0.", nameof(cantidadUsada));
            CantidadUsada = cantidadUsada;
        }
    }
}

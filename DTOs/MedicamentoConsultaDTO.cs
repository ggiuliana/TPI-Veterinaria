namespace DTOs
{
    public class MedicamentoConsultaDTO
    {
        public int IdConsulta { get; set; }
        public int IdMedicamento { get; set; }
        public int CantidadUsada { get; set; }
        public string NombreMedicamento { get; set; } = string.Empty;
    }
}

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
        public string NombreVeterinario { get; set; } = string.Empty;
        public string ApellidoVeterinario { get; set; } = string.Empty;
        public string EspecialidadVeterinario { get; set; } = string.Empty;
        public int? IdMascota { get; set; }
        public string NombreMascota { get; set; } = string.Empty;

    }
}

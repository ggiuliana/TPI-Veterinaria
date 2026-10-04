namespace DTOs
{
    public class MascotaDTO
    {
        public int IdMascota { get; set; }
        public string NombreMascota { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public bool Castrado { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNac { get; set; }
        public int IdDuenio { get; set; }
        public ICollection<VacunaDTO>? Vacunas { get; set; }
    }
}

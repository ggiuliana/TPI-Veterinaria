namespace ModeloDominio
{
    public class Turno
    {
        private static readonly string[] EstadosPermitidos = { "Disponible", "Otorgado", "Resuelto" };
        public int IdTurno { get; private set; }
        public DateOnly FechaTurno { get; private set; }
        public TimeOnly HoraTurno { get; private set; }
        public string EstadoTurno { get; private set; } = string.Empty;
        public string? Observaciones { get; private set; } = string.Empty;
        public int IdVeterinario { get; private set; }
        public Veterinario Veterinario { get; private set; } = null!;
        public int? IdMascota { get; private set; }
        public Mascota? Mascota { get; private set; }

        public Turno() { }

        public Turno(int idTurno, DateOnly fechaTurno, TimeOnly horaTurno, string estadoTurno, Veterinario veterinario)
        {
            SetIdTurno(idTurno);
            SetFechaTurno(fechaTurno);
            SetHoraTurno(horaTurno);
            SetEstadoTurno(estadoTurno);
            SetVeterinario(veterinario);
        }

        public void SetIdTurno(int idTurno)
        {
            if (idTurno < 0)
                throw new ArgumentException("El Id del turno debe ser mayor que 0.", nameof(idTurno));
            IdTurno = idTurno;
        }

        public void SetEstadoTurno(string estadoTurno)
        {
            if (string.IsNullOrWhiteSpace(estadoTurno))
                throw new ArgumentException("El estado del turno no puede ser nulo o vacío.", nameof(estadoTurno));

            if (!EstadosPermitidos.Contains(estadoTurno, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    $"El estado '{estadoTurno}' no es válido. Los estados permitidos son: {string.Join(", ", EstadosPermitidos)}.",
                    nameof(estadoTurno)
                );
            }

            EstadoTurno = EstadosPermitidos.First(e => e.Equals(estadoTurno, StringComparison.OrdinalIgnoreCase));
        }

        public void SetFechaTurno(DateOnly fechaTurno)
        {
            FechaTurno = fechaTurno;
        }

        public void SetHoraTurno(TimeOnly horaTurno)
        {
            HoraTurno = horaTurno;
        }

        public void SetObservaciones(string observaciones)
        {
            Observaciones = observaciones;
        }

        public void SetVeterinario(Veterinario veterinario)
        {
            Veterinario = veterinario;
        }

        public void SetMascota(Mascota mascota)
        {
            Mascota = mascota;
        }
    }
}

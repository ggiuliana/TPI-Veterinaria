namespace ModeloDominio
{
    public class Veterinario : Persona
    {
        public string Matricula { get; private set; } = string.Empty;
        public string Especialidad { get; private set; } = string.Empty;
        protected Veterinario() : base() { }
        public Veterinario(int idPersona, string nombrePersona, string apellido, string telefono, string mail, string dni, string direccion, string matricula, string especialidad)
            : base(idPersona, nombrePersona, apellido, telefono, mail, dni, direccion)
        {
            SetMatricula(matricula);
            SetEspecialidad(especialidad);
        }
        public void SetMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))
                throw new ArgumentException("La matrícula no puede ser nula o vacía.", nameof(matricula));
            Matricula = matricula;
        }
        public void SetEspecialidad(string especialidad)
        {
            if (string.IsNullOrWhiteSpace(especialidad))
                throw new ArgumentException("La especialidad no puede ser nula o vacía.", nameof(especialidad));
            Especialidad = especialidad;
        }
    }
}
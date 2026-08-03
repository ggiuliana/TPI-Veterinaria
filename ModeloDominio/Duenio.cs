namespace ModeloDominio
{
    public class Duenio : Persona
    {
        protected Duenio() : base() { }
        public Duenio(int idPersona, string nombrePersona, string apellido, string telefono, string mail, string dni, string direccion)
            : base(idPersona, nombrePersona, apellido, telefono, mail, dni, direccion)
        {
        }
    }
}

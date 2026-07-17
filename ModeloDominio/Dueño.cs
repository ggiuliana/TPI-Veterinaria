namespace ModeloDominio
{
    public class Dueño : Persona
    {
        protected Dueño() : base() { }
        public Dueño(int idPersona, string nombrePersona, string apellido, string telefono, string mail, string dni, string direccion)
            : base(idPersona, nombrePersona, apellido, telefono, mail, dni, direccion)
        {
        }
    }
}

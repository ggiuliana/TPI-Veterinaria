using System.Text.RegularExpressions;

namespace ModeloDominio
{
    public abstract class Persona
    {
        public int IdPersona { get; private set; }
        public string NombrePersona { get; private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string Telefono { get; private set; } = string.Empty;
        public string Mail { get; private set; } = string.Empty;
        public string Dni { get; private set; } = string.Empty;
        public string Direccion { get; private set; } = string.Empty;
        public Usuario? Usuario { get; set; }

        public Persona() { }
        public Persona(int idPersona, string nombrePersona, string apellido, string telefono, string mail, string dni, string direccion)
        {
            SetIdPersona(idPersona);
            SetNombrePersona(nombrePersona);
            SetApellido(apellido);
            SetTelefono(telefono);
            SetMail(mail);
            SetDni(dni);
            SetDireccion(direccion);
        }
        public void SetIdPersona(int idPersona)
        {
            if (idPersona < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(idPersona));
            IdPersona = idPersona;
        }
        public void SetNombrePersona(string nombrePersona)
        {
            if (string.IsNullOrWhiteSpace(nombrePersona))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombrePersona));
            NombrePersona = nombrePersona;
        }
        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }
        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El telefono no puede ser nulo o vacío.", nameof(telefono));
            Telefono = telefono;
        }
        public void SetMail(string mail)
        {
            if (!EsMailValido(mail))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(mail));
            Mail = mail;
        }
        private static bool EsMailValido(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
                return false;
            return Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public void SetDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI no puede ser nulo o vacío.", nameof(dni));
            Dni = dni;
        }
        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("El direccion no puede ser nulo o vacío.", nameof(direccion));
            Direccion = direccion;
        }
    }

}

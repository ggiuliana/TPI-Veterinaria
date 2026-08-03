using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Mascota
    {
        public int IdMascota { get; set; }
        public string NombreMascota { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public bool Castrado { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNac { get; set; }
        public Duenio? _duenio { get; set; }

        public Mascota() { }
        public Mascota(int idMascota, string nombreMascota, string especie, string raza, bool castrado, char sexo, DateTime fechaNac, Duenio duenio)
        {
            SetIdMascota(idMascota);
            SetNombreMascota(nombreMascota);
            SetEspecie(especie);
            SetRaza(raza);
            Castrado = castrado;
            SetSexo(sexo);
            SetFechaNac(fechaNac);
            SetDuenio(duenio);
        }
        public void SetIdMascota(int idMascota)
        {
            if (idMascota < 0)
                throw new ArgumentException("El Id de la mascota debe ser mayor o igual a 0.", nameof(idMascota));
            IdMascota = idMascota;
        }

        public void SetNombreMascota(string nombreMascota)
        {
            if (string.IsNullOrWhiteSpace(nombreMascota))
                throw new ArgumentException("El nombre de la mascota no puede ser nulo o vacío.", nameof(nombreMascota));
            NombreMascota = nombreMascota;
        }

        public void SetEspecie(string especie)
        {
            if (string.IsNullOrWhiteSpace(especie))
                throw new ArgumentException("La especie no puede ser nula o vacía.", nameof(especie));
            Especie = especie;
        }

        public void SetRaza(string raza)
        {
            if (string.IsNullOrWhiteSpace(raza))
                throw new ArgumentException("La raza no puede ser nula o vacía.", nameof(raza));
            Raza = raza;
        }
        public void SetSexo(char sexo)
        {
            if (char.ToUpper(sexo) != 'M' && char.ToUpper(sexo) != 'H')
                throw new ArgumentException("El sexo debe ser 'M' (Macho) o 'H' (Hembra).", nameof(sexo));

            Sexo = char.ToUpper(sexo);
        }
        public void SetFechaNac(DateTime fechaNac)
        {
            if (fechaNac > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede estar en el futuro.", nameof(fechaNac));
            FechaNac = fechaNac;
        }

        public void SetDuenio(Duenio duenio)
        {
            if (duenio == null)
                throw new ArgumentNullException(nameof(duenio), "El dueño no puede ser nulo.");
            _duenio = duenio;
        }
    }
}

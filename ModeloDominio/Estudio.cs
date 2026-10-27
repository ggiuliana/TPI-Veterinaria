namespace ModeloDominio
{
    public class Estudio
    {
        public int IdEstudio { get; private set; }
        public string NombreEstudio { get; private set; } = string.Empty;
        public string DescripcionEstudio { get; private set; } = string.Empty;

        public Estudio() { }
        public Estudio(int idEstudio, string nombreEstudio, string descripcionEstudio) {
            SetIdEstudio(idEstudio);
            SetNombre(nombreEstudio);
            SetDescripcion(descripcionEstudio);
        }

        public void SetIdEstudio(int idEstudio) {
            IdEstudio = idEstudio;
        }

        public void SetNombre(string nombreEstudio) {
            if (string.IsNullOrWhiteSpace(nombreEstudio)) {
                throw new ArgumentException("El nombre del estudio no puede estar vacío.");
            }
            NombreEstudio = nombreEstudio;
        }

        public void SetDescripcion(string descripcionEstudio) { 
            if (string.IsNullOrWhiteSpace(descripcionEstudio)) {
                throw new ArgumentException("La descripción del estudio no puede estar vacía.");
            }
            DescripcionEstudio = descripcionEstudio;
        }
    }
}

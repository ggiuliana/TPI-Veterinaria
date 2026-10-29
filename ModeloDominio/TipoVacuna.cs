namespace ModeloDominio
{
    public class TipoVacuna
    {
        public int IdTipoVacuna { get; private set; }
        public string NombreTipoVacuna { get; private set; } = string.Empty;
        public string DescripcionTipoVacuna { get; private set; } = string.Empty;
        public TipoVacuna() { }
        public TipoVacuna(int idTipoVacuna, string nombreTipoVacuna, string descripcionTipoVacuna) {
            SetIdTipoVacuna(idTipoVacuna);
            SetNombreTipoVacuna(nombreTipoVacuna);
            SetDescripcionTipoVacuna(descripcionTipoVacuna);
        }
        public void SetIdTipoVacuna(int idTipoVacuna) {
            this.IdTipoVacuna = idTipoVacuna;
        }
        public void SetNombreTipoVacuna(string nombreTipoVacuna) 
        {
            if (string.IsNullOrWhiteSpace(nombreTipoVacuna))
                throw new ArgumentException("El nombre de la vacuna no puede estar vacío.");

            this.NombreTipoVacuna = nombreTipoVacuna;
        }
        public void SetDescripcionTipoVacuna(string descripcionTipoVacuna) 
        {
            if (string.IsNullOrWhiteSpace(descripcionTipoVacuna))
                throw new ArgumentException("La descripción de la vacuna no puede estar vacía.");

            this.DescripcionTipoVacuna = descripcionTipoVacuna;
        }
    }
}

using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormTipoVacunaLista : Form
    {
        private readonly TipoVacunaClient TipoVacunaClient;
        public FormTipoVacunaLista()
        {
            InitializeComponent();
            this.Load += FormTipoVacunaLista_Load;
            this.Shown += FormTipoVacunaLista_Shown;

            IAuthService authService = Program.AuthService;
            TipoVacunaClient = new TipoVacunaClient(authService);
        }
        private void FormTipoVacunaLista_Shown(object? sender, EventArgs e)
        {
            if (dataGridView1.Columns.Contains("DescripcionTipoVacuna"))
            {
                dataGridView1.Columns["DescripcionTipoVacuna"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private async void FormTipoVacunaLista_Load(object? sender, EventArgs e)
        {
            await ConfigureButtonPermissions();
            await CargarVacunasSeguroAsync();
        }
        private async Task CargarVacunasSeguroAsync()
        {
            try
            {
                var vacunas = await TipoVacunaClient.GetAllAsync();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = vacunas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }
        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idVacunaBuscar.Text))
            {
                await CargarVacunasSeguroAsync();
                return;
            }

            if (int.TryParse(idVacunaBuscar.Text, out int id))
            {
                try
                {
                    var vac = await TipoVacunaClient.GetAsync(id);
                    dataGridView1.DataSource = vac != null ? new List<TipoVacunaDTO> { vac } : new List<TipoVacunaDTO>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar: {ex.Message}");
                }
            }
        }
        private async void Create_Click(object sender, EventArgs e)
        {
            FormTipoVacunaDetalle formDetalle = new FormTipoVacunaDetalle(0);
            if (formDetalle.ShowDialog() == DialogResult.OK) await CargarVacunasSeguroAsync();
        }
        private async void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdTipoVacuna"].Value);
                FormTipoVacunaDetalle formDetalle = new FormTipoVacunaDetalle(idSeleccionado);
                if (formDetalle.ShowDialog() == DialogResult.OK) await CargarVacunasSeguroAsync();
            }
        }
        private async void Delete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdTipoVacuna"].Value);
                if (MessageBox.Show("¿Eliminar este tipo de vacuna?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await TipoVacunaClient.DeleteAsync(idSeleccionado);
                    await CargarVacunasSeguroAsync();
                }
            }
        }
        private async Task ConfigureButtonPermissions()
        {
            var authService = Program.AuthService;

            Create.Visible = await authService.HasPermissionAsync("tipo vacunas.agregar");

            Modificar.Visible = await authService.HasPermissionAsync("tipo vacunas.actualizar");

            Delete.Visible = await authService.HasPermissionAsync("tipo vacunas.eliminar");
        }
    }
}
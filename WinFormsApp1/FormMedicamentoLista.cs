using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormMedicamentoLista : Form
    {
        private readonly MedicamentoClient MedicamentoClient;

        public FormMedicamentoLista()
        {
            InitializeComponent();
            this.Load += FormMedicamentoLista_Load;
            IAuthService authService = Program.AuthService;
            MedicamentoClient = new MedicamentoClient(authService, Program.Configuration);
        }

        private async void FormMedicamentoLista_Load(object? sender, EventArgs e)
        {
            await ConfigureButtonPermissions();
            await CargarMedicamentosSeguroAsync();
        }

        private async Task CargarMedicamentosSeguroAsync()
        {
            try
            {
                var medicamentos = await MedicamentoClient.GetAllAsync();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = medicamentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idMedicamentoBuscar.Text))
            {
                await CargarMedicamentosSeguroAsync();
                return;
            }

            if (!int.TryParse(idMedicamentoBuscar.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            try
            {
                var med = await MedicamentoClient.GetAsync(id);
                dataGridView1.DataSource = med != null ? new List<MedicamentoDTO> { med } : new List<MedicamentoDTO>();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                    MessageBox.Show("No se encontró el medicamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            FormMedicamentoDetalle formDetalle = new FormMedicamentoDetalle(0);
            if (formDetalle.ShowDialog(this) == DialogResult.OK)
            {
                await CargarMedicamentosSeguroAsync();
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un medicamento para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdMedicamento"].Value);
            FormMedicamentoDetalle formDetalle = new FormMedicamentoDetalle(idSeleccionado);

            if (formDetalle.ShowDialog(this) == DialogResult.OK)
            {
                await CargarMedicamentosSeguroAsync();
            }
        }

        private async void Delete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un medicamento para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdMedicamento"].Value);
            string nombre = dataGridView1.CurrentRow.Cells["NombreMedicamento"].Value?.ToString() ?? "";

            var confirmacion = MessageBox.Show($"¿Eliminar el medicamento '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await MedicamentoClient.DeleteAsync(idSeleccionado);
                    await CargarMedicamentosSeguroAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            FormReporteStock formReporte = new FormReporteStock();

            formReporte.MdiParent = this.MdiParent;

            formReporte.WindowState = FormWindowState.Maximized;

            formReporte.Show();
        }

        private async Task ConfigureButtonPermissions()
        {
            var authService = Program.AuthService;
            bool canAdd = await authService.HasPermissionAsync("medicamentos.agregar");
            bool canUpdate = await authService.HasPermissionAsync("medicamentos.actualizar");
            bool canDelete = await authService.HasPermissionAsync("medicamentos.eliminar");

            Create.Visible = canAdd;
            Modificar.Visible = canUpdate;
            Delete.Visible = canDelete;
        }
    }
}
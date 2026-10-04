using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormConsultaLista : Form
    {
        public FormConsultaLista()
        {
            InitializeComponent();
            this.Load += FormConsultaLista_Load;
        }

        private void FormConsultaLista_Load(object? sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            CargarGrilla();
        }

        private async void CargarGrilla()
        {
            try
            {
                var consultas = await ConsultaClient.GetAllAsync();
                dataGridView1.DataSource = consultas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las consultas: {ex.Message}");
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarId.Text))
            {
                CargarGrilla();
                return;
            }

            if (int.TryParse(txtBuscarId.Text, out int idBuscado))
            {
                try
                {
                    var consulta = await ConsultaClient.GetAsync(idBuscado);
                    if (consulta != null)
                    {
                        dataGridView1.DataSource = new List<ConsultaDTO> { consulta };
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ninguna consulta con ese ID.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = new List<ConsultaDTO>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en la búsqueda: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
               int idTurno = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colIdTurno"].Value);

                FormConsultaDetalle formDetalle = new FormConsultaDetalle(idTurno);
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una consulta de la lista para ver o modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idConsulta = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colIdConsulta"].Value);

                var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar todo el registro de la consulta ID {idConsulta}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        await ConsultaClient.DeleteAsync(idConsulta);

                        MessageBox.Show("Consulta eliminada con éxito.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una consulta de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormTurnoLista : Form
    {
        private readonly TurnoClient TurnoClient;
        private readonly IAuthService AuthService;

        private int idPersona = 0;

        public FormTurnoLista()
        {
            InitializeComponent();
            this.Load += FormTurnoLista_Load;
            AuthService = Program.AuthService;
            TurnoClient = new TurnoClient(AuthService, Program.Configuration);
        }

        private async void FormTurnoLista_Load(object? sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            var rol = await AuthService.GetRolAsync();

            if (rol?.Trim().ToUpper() != "VETERINARIO")
            {
                MessageBox.Show("Acceso denegado. Este módulo es exclusivo para veterinarios.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            var id = await AuthService.GetPersonaIdAsync();
            idPersona = id ?? 0;

            CargarGrilla();
        }

        private async void CargarGrilla()
        {
            try
            {
                var turnos = await TurnoClient.GetByVeterinarioIdAsync(idPersona);
                dataGridView1.DataSource = turnos?.ToList() ?? new List<TurnoDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los turnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idTurnoBuscar.Text))
            {
                CargarGrilla();
                return;
            }

            if (int.TryParse(idTurnoBuscar.Text, out int idBuscado))
            {
                try
                {
                    var turno = await TurnoClient.GetAsync(idBuscado);
                    if (turno != null)
                    {
                        if (turno.IdVeterinario != idPersona)
                        {
                            MessageBox.Show("No tiene permisos para ver este turno.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        dataGridView1.DataSource = new List<TurnoDTO> { turno };
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún turno con ese ID.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = new List<TurnoDTO>();
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

        private void Create_Click(object sender, EventArgs e)
        {
            FormTurnoDetalle formDetalle = new(0);
            if (formDetalle.ShowDialog(this) == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idTurno = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colIdTurno"].Value);

                FormTurnoDetalle formDetalle = new(idTurno);
                if (formDetalle.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un turno de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idTurno = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colIdTurno"].Value);

                var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar el turno ID {idTurno}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        await TurnoClient.DeleteAsync(idTurno);
                        MessageBox.Show("Turno eliminado con éxito.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Por favor, seleccione un turno de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colConsulta")
            {
                var turnoSeleccionado = (TurnoDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                if (turnoSeleccionado.EstadoTurno == "Disponible")
                {
                    MessageBox.Show("Solo se puede agregar o modificar una consulta en turnos con estado 'Otorgado'/'Resuelto'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (turnoSeleccionado.IdVeterinario != idPersona)
                {
                    MessageBox.Show("Solo el veterinario asignado a este turno puede gestionar su consulta.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormConsultaDetalle formConsulta = new(turnoSeleccionado.IdTurno);
                if (formConsulta.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Consulta guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                }
            }
        }

        private void Metricas_Click(object sender, EventArgs e)
        {
            FormMetricasTurnos formMetricas = new();
            formMetricas.MdiParent = this.MdiParent;
            formMetricas.Show();
        }
    }
}
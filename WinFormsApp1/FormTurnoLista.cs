using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormTurnoLista : Form
    {
        private readonly TurnoClient TurnoClient;
        public FormTurnoLista()
        {
            InitializeComponent();
            this.Load += FormTurnoLista_Load;
            IAuthService authService = Program.AuthService;
            TurnoClient = new TurnoClient(authService);
        }

        private void FormTurnoLista_Load(object? sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            CargarGrilla();
        }

        private async void CargarGrilla()
        {
            try
            {
                var turnos = await TurnoClient.GetAllAsync();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = turnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los turnos: {ex.Message}");
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
            FormTurnoDetalle formDetalle = new FormTurnoDetalle(0);
            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idTurno = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colIdTurno"].Value);

                FormTurnoDetalle formDetalle = new FormTurnoDetalle(idTurno);
                if (formDetalle.ShowDialog() == DialogResult.OK)
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
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var authService = Program.AuthService;

            int? personaId = await authService.GetPersonaIdAsync();

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colConsulta")
            {                 
                var turnoSeleccionado = (TurnoDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                if (turnoSeleccionado.EstadoTurno == "Pendiente")
                {
                    MessageBox.Show("Solo se puede agregar o modificar una consulta en turnos con estado 'Otorgado'/'Resuelto'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (turnoSeleccionado.IdVeterinario != personaId)
                {
                    MessageBox.Show("Solo el veterinario asignado a este turno puede gestionar su consulta.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FormConsultaDetalle formConsulta = new FormConsultaDetalle(turnoSeleccionado.IdTurno);
                if (formConsulta.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        turnoSeleccionado.EstadoTurno = "Resuelto";
                        await TurnoClient.UpdateAsync(turnoSeleccionado);

                        MessageBox.Show("Consulta guardada y turno marcado como Resuelto.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"La consulta se creó, pero hubo un error al actualizar el estado del turno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

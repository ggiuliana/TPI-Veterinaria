using API.Clients;
using DTOs;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace WinFormsApp1
{
    public partial class FormTurnoAdminListado : Form
    {
        private readonly TurnoClient _turnoClient;
        private readonly VeterinarioClient _veterinarioClient;
        private readonly IAuthService AuthService;

        public FormTurnoAdminListado()
        {
            InitializeComponent();
            this.Load += FormTurnoAdminListado_Load;
            AuthService = Program.AuthService;
            _turnoClient = new TurnoClient(AuthService);
            _veterinarioClient = new VeterinarioClient(AuthService);
        }

        private async void FormTurnoAdminListado_Load(object sender, EventArgs e)
        {
            ConfigurarFechasOpcionales();
            ConfigurarControlesFiltro();
            await CargarVeterinariosComboAsync();
            await CargarTurnosFiltradosAsync();
        }

        private void ConfigurarControlesFiltro()
        {
            estadoTurno.Items.Clear();
            estadoTurno.Items.Add("Todos");
            estadoTurno.Items.Add("Disponible");
            estadoTurno.Items.Add("Otorgado");
            estadoTurno.Items.Add("Resuelto");
            estadoTurno.SelectedIndex = 0;

            fechaDesde.ShowCheckBox = true;
            fechaDesde.Checked = false;

            fechaHasta.ShowCheckBox = true;
            fechaHasta.Checked = false;
        }
        private async Task CargarVeterinariosComboAsync()
        {
            try
            {
                var veterinarios = await _veterinarioClient.GetAllAsync();

                var listaCombo = new List<VeterinarioComboItem>
                {
                    new VeterinarioComboItem { Id = 0, NombreCompleto = "Todos los veterinarios" }
                };

                if (veterinarios != null)
                {
                    listaCombo.AddRange(veterinarios.Select(v => new VeterinarioComboItem
                    {
                        Id = v.IdVeterinario,
                        NombreCompleto = $"{v.NombreVeterinario} {v.Apellido}"
                    }));
                }

                vetTurno.DataSource = listaCombo;
                vetTurno.DisplayMember = "NombreCompleto";
                vetTurno.ValueMember = "Id";
                vetTurno.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar veterinarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarTurnosFiltradosAsync()
        {
            try
            {
                string? estado = estadoTurno.SelectedItem?.ToString();
                if (estado == "Todos") estado = null;

                int? idVeterinario = null;
                if (vetTurno.SelectedValue is int id && id > 0)
                {
                    idVeterinario = id;
                }

                DateOnly? desde = fechaDesde.Checked ? DateOnly.FromDateTime(fechaDesde.Value) : null;
                DateOnly? hasta = fechaHasta.Checked ? DateOnly.FromDateTime(fechaHasta.Value) : null;

                var turnos = await _turnoClient.GetTurnosFiltradosAsync(idVeterinario, estado, desde, hasta);

                dataGridView1.DataSource = turnos;

                string[] columnasAOcultar = {
                    "IdVeterinario",
                    "NombreVeterinario",
                    "ApellidoVeterinario",
                    "EspecialidadVeterinario",
                    "IdMascota"
                };

                foreach (var col in columnasAOcultar)
                {
                    if (dataGridView1.Columns.Contains(col))
                    {
                        dataGridView1.Columns[col].Visible = false;
                    }
                }

                dataGridView1.DataSource = turnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los turnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarFechasOpcionales()
        {
            fechaDesde.ShowCheckBox = true;
            fechaDesde.Checked = false; 

            fechaHasta.ShowCheckBox = true;
            fechaHasta.Checked = false;
        }
        
        private async void Buscar_Click(object sender, EventArgs e)
        {
            await CargarTurnosFiltradosAsync();
        }

        private async void Limpiar_Click(object sender, EventArgs e)
        {
            estadoTurno.SelectedIndex = 0;

            if (vetTurno.Items.Count > 0)
                vetTurno.SelectedIndex = 0;

            fechaDesde.Checked = false;
            fechaHasta.Checked = false;

            await CargarTurnosFiltradosAsync();
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
                        await _turnoClient.DeleteAsync(idTurno);
                        MessageBox.Show("Turno eliminado con éxito.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarTurnosFiltradosAsync();
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

        private async void Create_Click(object sender, EventArgs e)
        {
            FormTurnoDetalle formDetalle = new(0);
            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                await CargarTurnosFiltradosAsync();
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idTurno = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colIdTurno"].Value);

                FormTurnoDetalle formDetalle = new(idTurno);
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    await CargarTurnosFiltradosAsync();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un turno de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colConsulta")
            {
                var turnoSeleccionado = (TurnoDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                if (turnoSeleccionado.EstadoTurno == "Disponible")
                {
                    MessageBox.Show("Solo se puede agregar o modificar una consulta en turnos con estado 'Otorgado'/'Resuelto'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FormConsultaDetalle formConsulta = new(turnoSeleccionado.IdTurno);
                if (formConsulta.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Consulta guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarTurnosFiltradosAsync();
                }
            }
        }

        private void Metricas_Click(object sender, EventArgs e)
        {
            FormMetricasTurnos formMetricas = new();

            formMetricas.MdiParent = this.MdiParent ?? Application.OpenForms["AdminHome"];

            formMetricas.WindowState = FormWindowState.Maximized;

            formMetricas.Show();
        }

        private class VeterinarioComboItem
        {
            public int Id { get; set; }
            public string NombreCompleto { get; set; } = string.Empty;
        }
    }
}
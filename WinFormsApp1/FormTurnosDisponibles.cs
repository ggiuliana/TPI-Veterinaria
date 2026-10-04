using API.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormTurnosDisponibles : Form
    {
        public FormTurnosDisponibles()
        {
            InitializeComponent();
            
        }

        private async void FormTurnosDisponibles_Load(object sender, EventArgs e)
        {
            await CargarTurnosAsync();
        }

        private async Task CargarTurnosAsync()
        {
            try
            {
                var todosLosTurnos = await TurnoClient.GetAllAsync();
                var turnosDisponibles = todosLosTurnos
                    .Where(t => t.EstadoTurno == "Pendiente")
                    .ToList();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = turnosDisponibles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los turnos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SacarTurno_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idTurnoSeleccionado = (int)dataGridView1.CurrentRow.Cells["colIdTurno"].Value;

                var formSacarTurno = new FormSacarTurno(idTurnoSeleccionado);

                if (formSacarTurno.ShowDialog() == DialogResult.OK)
                {
                    await CargarTurnosAsync();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un turno de la lista.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

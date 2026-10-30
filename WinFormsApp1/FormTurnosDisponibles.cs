using API.Clients;
using DTOs;
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
        private readonly TurnoClient TurnoClient;
        public FormTurnosDisponibles()
        {
            InitializeComponent();
            IAuthService authService = Program.AuthService;
            TurnoClient = new TurnoClient(authService, Program.Configuration);
        }

        private async void FormTurnosDisponibles_Load(object sender, EventArgs e)
        {
            await CargarTurnosAsync();
        }

        private async Task CargarTurnosAsync()
        {
            try
            {
                var turnosDisponibles = await TurnoClient.GetDisponiblesAsync();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = turnosDisponibles?.ToList();
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
                var turnoActual = (TurnoDTO)dataGridView1.CurrentRow.Cells[0].OwningRow.DataBoundItem;

                FormSacarTurno formDetalle = new(turnoActual);

                if (formDetalle.ShowDialog(this) == DialogResult.OK)
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

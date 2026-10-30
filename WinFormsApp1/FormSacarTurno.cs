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
    public partial class FormSacarTurno : Form
    {
        private readonly int _idTurno;
        private readonly TurnoClient TurnoClient;
        private readonly MascotaClient MascotaClient;
        private TurnoDTO _turnoSeleccionado; 
        public FormSacarTurno(TurnoDTO turnoSeleccionado)
        {
            InitializeComponent();
            _turnoSeleccionado = turnoSeleccionado;
            IAuthService authService = Program.AuthService;
            TurnoClient = new TurnoClient(authService, Program.Configuration);
            MascotaClient = new MascotaClient(authService, Program.Configuration);
        }

        private async void FormSacarTurno_Load(object sender, EventArgs e)
        {
            await CargarMascotasComboBoxAsync();
        }

        private async Task CargarMascotasComboBoxAsync()
        {
            try
            {
                var authService = Program.AuthService;
                int? idDuenio = await authService.GetPersonaIdAsync();

                if (idDuenio.HasValue)
                {
                    var mascotas = await MascotaClient.GetAllByDuenioAsync(idDuenio.Value);


                    mascotasComboBox.DataSource = mascotas;

                    mascotasComboBox.DisplayMember = "NombreMascota";

                    mascotasComboBox.ValueMember = "IdMascota";

                    mascotasComboBox.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de mascotas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_turnoSeleccionado != null)
                {
                    if (mascotasComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Por favor, seleccione una mascota.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _turnoSeleccionado.IdMascota = (int)mascotasComboBox.SelectedValue;
                    _turnoSeleccionado.EstadoTurno = "Otorgado";

                    var response = await TurnoClient.UpdateAsync(_turnoSeleccionado);

                    MessageBox.Show("Turno reservado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

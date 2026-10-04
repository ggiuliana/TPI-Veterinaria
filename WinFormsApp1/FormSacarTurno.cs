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
    public partial class FormSacarTurno : Form
    {
        private readonly int _idTurno;
        public FormSacarTurno(int idTurno)
        {
            InitializeComponent();
            this._idTurno = idTurno;
        }

        private async void FormSacarTurno_Load(object sender, EventArgs e)
        {
            await CargarMascotasComboBoxAsync();
        }

        private async Task CargarMascotasComboBoxAsync()
        {
            try
            {
                var authService = AuthServiceProvider.Instance;
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
            try { 
                var turno = await TurnoClient.GetAsync(_idTurno);
                if (turno != null)
                {
                    if (mascotasComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Por favor, seleccione una mascota.");
                        return;
                    }
                    turno.IdMascota = (int)mascotasComboBox.SelectedValue;
                    turno.EstadoTurno = "Otorgado";
                    var response = await TurnoClient.UpdateAsync(turno);
                }
                MessageBox.Show("Estudio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

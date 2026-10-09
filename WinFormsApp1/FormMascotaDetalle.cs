using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMascotaDetalle : Form
    {
        private readonly int _idMascotaActual;
        private readonly MascotaClient MascotaClient;
        public FormMascotaDetalle(int idMascota = 0)
        {
            InitializeComponent();
            _idMascotaActual = idMascota;

            this.Load += FormMascotaDetalle_Load;
            IAuthService authService = Program.AuthService;
            MascotaClient = new MascotaClient(authService);
        }
        private async void FormMascotaDetalle_Load(object? sender, EventArgs e)
        {
            if (_idMascotaActual > 0)
            {
                this.Text = "Editar Mascota";
                labelTit.Text = "Editar Mascota";
                try
                {
                    var mascota = await MascotaClient.GetAsync(_idMascotaActual);
                    if (mascota != null)
                    {
                        nombreMascota.Text = mascota.NombreMascota;
                        especieMascota.Text = mascota.Especie;
                        razaMascota.Text = mascota.Especie;
                        castradoMascota.Checked = mascota.Castrado;
                        sexoMascota.Text = mascota.Sexo == 'M' ? "Macho" : "Hembra";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                this.Text = "Nueva Mascota";
                labelTit.Text = "Nueva Mascota";
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                var authService = Program.AuthService;

                int? personaId = await authService.GetPersonaIdAsync();

                var mascota = new MascotaDTO
                {
                    IdMascota = _idMascotaActual,
                    NombreMascota = nombreMascota.Text,
                    Especie = especieMascota.Text,
                    Raza = razaMascota.Text,
                    Castrado = castradoMascota.Checked,
                    Sexo = sexoMascota.Text == "Macho" ? 'M' : 'H',
                    FechaNac = fechaNacimientoMascota.Value,
                    IdDuenio = personaId ?? 0
                };

                if (_idMascotaActual == 0)
                {
                    var est = await MascotaClient.AddAsync(mascota);
                    if (est == null)
                    {
                        MessageBox.Show("No se pudo obtener el ID de la mascota creada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    await MascotaClient.UpdateAsync(mascota);
                }

                MessageBox.Show("Mascota guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
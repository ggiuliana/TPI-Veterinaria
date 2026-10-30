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
    public partial class FormRegistro : Form
    {
        private readonly UsuarioClient _authClient;

        public FormRegistro()
        {
            InitializeComponent();

            IAuthService authService = Program.AuthService;
            _authClient = new UsuarioClient(authService, Program.Configuration);
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usuarioDuenio.Text) ||
                string.IsNullOrWhiteSpace(mailDuenio.Text) ||
                string.IsNullOrWhiteSpace(contraseniaDuenio.Text) ||
                string.IsNullOrWhiteSpace(nombreDuenio.Text) ||
                string.IsNullOrWhiteSpace(apellidoDuenio.Text) ||
                string.IsNullOrWhiteSpace(telefonoDuenio.Text) ||
                string.IsNullOrWhiteSpace(dniDuenio.Text) ||
                string.IsNullOrWhiteSpace(direccionDuenio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dueniodto = new DuenioDTO
            {
                NombreDuenio = nombreDuenio.Text.Trim(),
                Apellido = apellidoDuenio.Text.Trim(),
                Telefono = telefonoDuenio.Text.Trim(),
                Mail = mailDuenio.Text.Trim(),
                Dni = dniDuenio.Text.Trim(),
                Direccion = direccionDuenio.Text.Trim()
            };
            var usuariodto = new UsuarioCreateDTO
            {
                NombreUsuario = usuarioDuenio.Text.Trim(),
                Contrasenia = contraseniaDuenio.Text
            };
            var dto = new DuenioRegisterDTO
            {
                duenio = dueniodto,
                usuario = usuariodto
            };

            try
            {
                Guardar.Enabled = false;

                await _authClient.RegisterDuenioAsync(dto);

                MessageBox.Show("Registro completado con éxito. Ahora puede iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo completar el registro:\n\n{ex.Message}", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Guardar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

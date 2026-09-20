using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        public Login() => InitializeComponent();
        private async void IngresoClick(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    var authService = AuthServiceProvider.Instance;
                    bool success = await authService.LoginAsync(nombreusuario.Text, contrasenia.Text);

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        var adminhome = new AdminHome();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        contrasenia.Clear();
                        contrasenia.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidateInput()
        {
            errorProvider.SetError(nombreusuario, string.Empty);
            errorProvider.SetError(contrasenia, string.Empty);

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(nombreusuario.Text))
            {
                errorProvider.SetError(nombreusuario, "El nombre de usuario es requerido");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(contrasenia.Text))
            {
                errorProvider.SetError(contrasenia, "La contraseña es requerida");
                isValid = false;
            }

            return isValid;
        }
    }
}
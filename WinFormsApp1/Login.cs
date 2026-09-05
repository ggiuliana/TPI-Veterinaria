using API.Clients;
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
            string usuario = nombreusuario.Text;
            string contra = contrasenia.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contra))
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuarios = await UsuarioClient.GetAllAsync();

                var usuarioEncontrado = usuarios.FirstOrDefault(u =>
                    u.NombreUsuario == usuario &&
                    u.Contrasenia == contra
                );

                if (usuarioEncontrado != null)
                {
                    MessageBox.Show("Inicio de sesión correcto.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdminHome adminhome = new AdminHome();
                    adminhome.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error de conexión al iniciar sesión: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
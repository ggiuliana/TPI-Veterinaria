using ServiciosApp;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private readonly IUsuarioService service;
        public Form1(IUsuarioService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private async void IngresoClick(object sender, EventArgs e) 
        {
            string usuario = nombreusuario.Text;
            string contra = contrasenia.Text;
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contra))
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }
            try
            {
                var usuarios = await service.GetAllAsync();

                var usuarioEncontrado = usuarios.FirstOrDefault(u =>
                    u.NombreUsuario == usuario &&
                    u.Contrasenia == contra
                );
                if (usuarioEncontrado != null)
                {
                    MessageBox.Show("Inicio de sesión correcto.");
                    // SE ABRE OTRO FORMULARIO DEPENDIENDO NIVEL DE LOGIN
                    // Form2 form2 = new Form2();
                    // form2.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al iniciar sesión: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

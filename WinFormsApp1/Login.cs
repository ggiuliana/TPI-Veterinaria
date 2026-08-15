using ServiciosApp;
namespace WinFormsApp1
{
    public partial class Login : Form
    {

        private readonly IUsuarioService service;
        private readonly IVeterinarioService servicevet;
        public Login(IUsuarioService service, IVeterinarioService servicevet)
        {
            InitializeComponent();
            this.service = service;
            this.servicevet = servicevet;
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
                    AdminHome adminhome = new AdminHome(servicevet, service);
                    adminhome.Show();
                    this.Hide();
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

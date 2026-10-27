using API.Clients;
using API.Auth.WindowsForms;

namespace WinFormsApp1
{
    internal static class Program
    {
        public static IAuthService AuthService { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            AuthService = new WindowsFormsAuthService();

            try
            {
                RunApplicationLoop().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fatal al iniciar la aplicación:\n{ex.Message}", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static async Task RunApplicationLoop()
        {
            while (true)
            {
                if (!await AuthService.IsAuthenticatedAsync())
                {
                    using var loginForm = new Login();
                    loginForm.StartPosition = FormStartPosition.CenterScreen;
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                try
                {
                    string? rol = await AuthService.GetRolAsync();
                    Form homeForm;

                    switch (rol)
                    {
                        case "Administrador":
                            homeForm = new AdminHome();
                            break;
                        case "Veterinario":
                            homeForm = new VeterinarioHome();
                            break;
                        case "Duenio":
                            homeForm = new DuenioHome();
                            break;
                        default:
                            MessageBox.Show($"Rol no válido: {rol}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            await AuthService.LogoutAsync();
                            continue;
                    }

                    homeForm.WindowState = FormWindowState.Maximized;

                    Application.Run(homeForm);

                    if (await AuthService.IsAuthenticatedAsync())
                    {
                        break;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message, "Sesión Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await AuthService.LogoutAsync();
                }
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is UnauthorizedAccessException)
            {
                MessageBox.Show("Su sesión ha expirado. Debe volver a autenticarse.", "Sesión Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Restart();
            }
            else
            {
                MessageBox.Show($"Error inesperado: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
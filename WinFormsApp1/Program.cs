using API.Clients;
using API.Auth.WindowsForms;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Handler para excepciones de UI no manejadas
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Ejecutar async main
            Task.Run(async () => await MainAsync()).GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Register(authService);

            while (true)
            {
                if (!await authService.IsAuthenticatedAsync())
                {
                    var loginForm = new Login();
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                try
                {
                    string? rol = await authService.GetRolAsync();
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
                            await authService.LogoutAsync();
                            continue;
                    }
                    homeForm.WindowState = FormWindowState.Maximized;
                    Application.Run(homeForm);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message, "Sesión Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await authService.LogoutAsync();
                }
            }
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is UnauthorizedAccessException)
            {
                // Sesión expirada
                MessageBox.Show("Su sesión ha expirado. Debe volver a autenticarse.", "Sesión Expirada",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reiniciar la aplicación para volver al login
                Application.Restart();
            }
            else
            {
                // Otras excepciones, mostrar error genérico
                MessageBox.Show($"Error inesperado: {e.Exception.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}   
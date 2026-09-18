namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Login formLogin = new Login();

            formLogin.StartPosition = FormStartPosition.CenterScreen;

            Application.Run(formLogin);
        }
    }
}   
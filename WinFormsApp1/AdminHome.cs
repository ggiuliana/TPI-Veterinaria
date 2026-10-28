using API.Clients;

namespace WinFormsApp1
{
    public partial class AdminHome : Form
    {
        public AdminHome() => InitializeComponent();

        private async void LogOut_Click(object sender, EventArgs e)
        {
            IAuthService authService = Program.AuthService;

            await authService.LogoutAsync();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void VeterinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormVeterinarioLista>().Any())
            {
                Application.OpenForms.OfType<FormVeterinarioLista>().First().BringToFront();
                return;
            }

            FormVeterinarioLista formVet = new()
            {
                MdiParent = this,

                FormBorderStyle = FormBorderStyle.None,

                Dock = DockStyle.Fill
            };
            formVet.Show();
        }

        private void EstudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormEstudioLista>().Any())
            {
                Application.OpenForms.OfType<FormEstudioLista>().First().BringToFront();
                return;
            }

            FormEstudioLista formEstudio = new()
            {
                MdiParent = this,

                FormBorderStyle = FormBorderStyle.None,

                Dock = DockStyle.Fill
            };
            formEstudio.Show();

        }
        private void TurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormTurnoAdminListado>().Any())
            {
                Application.OpenForms.OfType<FormTurnoAdminListado>().First().BringToFront();
                return;
            }

            FormTurnoAdminListado formTurnos = new()
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            formTurnos.Show();
        }
        private void ConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormConsultaLista>().Any())
            {
                Application.OpenForms.OfType<FormConsultaLista>().First().BringToFront();
                return;
            }
            FormConsultaLista formConsultas = new()
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            formConsultas.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (this.DialogResult != DialogResult.OK)
            {
                Program.AuthService.LogoutAsync().GetAwaiter().GetResult();
            }
        }
        private void MedicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormMedicamentoLista>().Any())
            {
                Application.OpenForms.OfType<FormMedicamentoLista>().First().BringToFront();
                return;
            }
            FormMedicamentoLista formMedicamentos = new() 
            { 
                MdiParent = this, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };
            formMedicamentos.Show();
        }

        private void TiposDeVacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormTipoVacunaLista>().Any())
            {
                Application.OpenForms.OfType<FormTipoVacunaLista>().First().BringToFront();
                return;
            }
            FormTipoVacunaLista formTipoVacunas = new() 
            { 
                MdiParent = this, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };
            formTipoVacunas.Show();
        }
    }
}

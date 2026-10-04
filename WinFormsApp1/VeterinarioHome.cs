using API.Clients;
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
    public partial class VeterinarioHome : Form
    {
        public VeterinarioHome()
        {
            InitializeComponent();
        }

        private async void LogOut_Click(object sender, EventArgs e)
        {
            var authService = AuthServiceProvider.Instance;

            await authService.LogoutAsync();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormTurnoLista>().Any())
            {
                Application.OpenForms.OfType<FormTurnoLista>().First().BringToFront();
                return;
            }

            FormTurnoLista formTurno = new()
            {
                MdiParent = this,

                FormBorderStyle = FormBorderStyle.None,

                Dock = DockStyle.Fill
            };
            formTurno.Show();
        }

        private void ConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormConsultaLista>().Any())
            {
                Application.OpenForms.OfType<FormConsultaLista>().First().BringToFront();
                return;
            }

            FormConsultaLista formConsulta = new()
            {
                MdiParent = this,

                FormBorderStyle = FormBorderStyle.None,

                Dock = DockStyle.Fill
            };
            formConsulta.Show();
        }
    }
}

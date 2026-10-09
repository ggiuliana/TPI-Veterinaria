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
    public partial class DuenioHome : Form
    {
        public DuenioHome()
        {
            InitializeComponent();
        }

        private async void LogOut_Click(object sender, EventArgs e)
        {
            var authService = Program.AuthService;

            await authService.LogoutAsync();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void SacarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormTurnosDisponibles>().Any())
            {
                Application.OpenForms.OfType<FormTurnosDisponibles>().First().BringToFront();
                return;
            }

            FormTurnosDisponibles formTurnos = new()
            {
                MdiParent = this,

                FormBorderStyle = FormBorderStyle.None,

                Dock = DockStyle.Fill
            };
            formTurnos.Show();
        }

        public void MascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormMascotaLista>().Any())
            {
                Application.OpenForms.OfType<FormMascotaLista>().First().BringToFront();
                return;
            }

            FormMascotaLista formMascotas = new()
            {
                MdiParent = this,

                FormBorderStyle = FormBorderStyle.None,

                Dock = DockStyle.Fill
            };
            formMascotas.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (this.DialogResult != DialogResult.OK)
            {
                Program.AuthService.LogoutAsync().GetAwaiter().GetResult();
            }
        }
    }
}

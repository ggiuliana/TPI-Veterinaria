using System;
using API.Clients;
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
    public partial class AdminHome : Form
    {
        public AdminHome() => InitializeComponent();
        
        private void LogOut_Click(object sender, EventArgs e)
        {
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
            if (Application.OpenForms.OfType<FormTurnoLista>().Any())
            {
                Application.OpenForms.OfType<FormTurnoLista>().First().BringToFront();
                return;
            }

            FormTurnoLista formTurnos = new()
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

    }
}

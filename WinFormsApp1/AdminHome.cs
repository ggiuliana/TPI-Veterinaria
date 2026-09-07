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
        /*
        private void VeterinariosCRUD_Click(object sender, EventArgs e)
        {
            MostrarCRUD(new VeterinarioCRUD());
        }
        
        private void MostrarCRUD(UserControl crud)
        {
            panelContenido.Controls.Clear();

            crud.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(crud);
        }
        private void Estudios_Click(object sender, EventArgs e)
        {
            MostrarCRUD(new EstudioCRUD());
        }
        */
        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VeterinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormVeterinarioCRUD>().Any())
            {
                Application.OpenForms.OfType<FormVeterinarioCRUD>().First().BringToFront();
                return;
            }

            FormVeterinarioCRUD formVet = new()
            {
                MdiParent = this
            };
            formVet.Show();
        }

        private void EstudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormEstudioCRUD>().Any())
            {
                Application.OpenForms.OfType<FormEstudioCRUD>().First().BringToFront();
                return;
            }

            FormEstudioCRUD formEstudio = new()
            {
                MdiParent = this
            };
            formEstudio.Show();

        }

    }
}

using ServiciosApp;
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
    public partial class AdminHome : Form
    {
        private readonly IVeterinarioService veterinarioService;
        private readonly IUsuarioService usuarioService;

        public AdminHome(IVeterinarioService veterinarioService, IUsuarioService usuarioService)
        {
            InitializeComponent();

            this.veterinarioService = veterinarioService;

            this.usuarioService = usuarioService;
        }

        private void VeterinariosCRUD_Click(object sender, EventArgs e)
        {
            MostrarCRUD(new VeterinarioCRUD(veterinarioService, usuarioService));
        }

        private void MostrarCRUD(UserControl crud)
        {
            panelContenido.Controls.Clear();

            crud.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(crud);
        }
    }
}

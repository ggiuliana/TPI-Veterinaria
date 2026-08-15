using ModeloDominio;
using ServiciosApp;
using DTOs;
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
    public partial class VeterinarioCRUD : UserControl
    {
        private readonly IVeterinarioService veterinarioService;
        private readonly IUsuarioService usuarioService;

        public VeterinarioCRUD(IVeterinarioService veterinarioService, IUsuarioService usuarioService)
        {
            InitializeComponent();

            this.veterinarioService = veterinarioService;

            this.usuarioService = usuarioService;

            Load += VeterinarioCRUD_Load;
        }

        private async void VeterinarioCRUD_Load(object sender, EventArgs e)
        {
            await CargarVeterinariosAsync();
        }
        private async Task CargarVeterinariosAsync()
        {
            var veterinarios = await veterinarioService.GetAllAsync();

            dataGridView1.DataSource = veterinarios;
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idVet.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }
            var vet = await veterinarioService.GetAsync(id);
            if (vet != null)
            {
                dataGridView1.DataSource = new List<VeterinarioDTO>
                {
                    vet
                };
            }
            else {
                MessageBox.Show("No se encontro el veterinario.");
                return;
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private async void Create_Click(object sender, EventArgs e)
        {
            using var form = new CreateVeterinario(veterinarioService, usuarioService);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarVeterinariosAsync();
            }
        }


    }
}

using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class VeterinarioCRUD : UserControl
    {
        public VeterinarioCRUD()
        {
            InitializeComponent();
            Load += VeterinarioCRUD_Load;
        }

        private async void VeterinarioCRUD_Load(object? sender, EventArgs e)
        {
            await CargarVeterinariosSeguroAsync();
        }

        private async Task CargarVeterinariosSeguroAsync()
        {

            try
            {
                var veterinarios = await VeterinarioClient.GetAllAsync();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = veterinarios;

                dataGridView1.Columns["IdVeterinario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["IdVeterinario"].HeaderText = "ID";
                dataGridView1.Columns["NombreVeterinario"].HeaderText = "Nombre";
                dataGridView1.Columns["Apellido"].HeaderText = "Apellido";
                dataGridView1.Columns["Telefono"].HeaderText = "Teléfono";
                dataGridView1.Columns["Mail"].HeaderText = "Correo Electrónico";
                dataGridView1.Columns["Dni"].HeaderText = "DNI";
                dataGridView1.Columns["Direccion"].HeaderText = "Dirección";
                dataGridView1.Columns["Matricula"].HeaderText = "Matrícula";
                dataGridView1.Columns["Especialidad"].HeaderText = "Especialidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idVet.Text))
            {
                await CargarVeterinariosSeguroAsync();
                return;
            }

            if (!int.TryParse(idVet.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            try
            {
                var vet = await VeterinarioClient.GetAsync(id);
                dataGridView1.DataSource = new List<VeterinarioDTO> { vet! };
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    MessageBox.Show("No se encontró el veterinario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            using var form = new DeleteVeterinario();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarVeterinariosSeguroAsync();
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            using var form = new UpdateVeterinario();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarVeterinariosSeguroAsync();
            }
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            using var form = new CreateVeterinario();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarVeterinariosSeguroAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using ModeloDominio;

namespace WinFormsApp1
{
    public partial class EstudioCRUD : UserControl
    {
        public EstudioCRUD()
        {
            InitializeComponent();
            Load += EstudioCRUD_Load;
        }

        private async void EstudioCRUD_Load(object? sender, EventArgs e)
        {
            await CargarEstudiosSeguroAsync();
        }

        private async Task CargarEstudiosSeguroAsync()
        {
            try
            {
                var estudios = await EstudioClient.GetAllAsync();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = estudios;

                dataGridView1.Columns["IdEstudio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["IdEstudio"].HeaderText = "ID";
                dataGridView1.Columns["NombreEstudio"].HeaderText = "Nombre";
                dataGridView1.Columns["DescripcionEstudio"].HeaderText = "Descripción";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idEstudio.Text))
            {
                await CargarEstudiosSeguroAsync();
                return;
            }

            if (!int.TryParse(idEstudio.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            try
            {
                var estudio = await EstudioClient.GetAsync(id);
                dataGridView1.DataSource = new List<EstudioDTO> { estudio! };
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    MessageBox.Show("No se encontró el estudio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private async void Delete_Click(object? sender, EventArgs e)
        {
            using var form = new DeleteEstudio();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarEstudiosSeguroAsync();
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            using var form = new UpdateEstudio();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarEstudiosSeguroAsync();
            }
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            using var form = new CreateEstudio();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CargarEstudiosSeguroAsync();
            }
        }
    }
}
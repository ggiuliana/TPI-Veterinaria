using API.Clients;
using DTOs;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormEstudioLista : Form
    {
        public FormEstudioLista()
        {
            InitializeComponent();
            this.Load += FormEstudioLista_Load;
        }

        private async void FormEstudioLista_Load(object? sender, EventArgs e)
        {
            await CargarEstudiosSeguroAsync();
        }

        private async Task CargarEstudiosSeguroAsync()
        {
            try
            {
                var estudios = await EstudioClient.GetAllAsync();
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
                    MessageBox.Show("No se encontró el estudio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            FormEstudioDetalle formDetalle = new FormEstudioDetalle(0);

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                await CargarEstudiosSeguroAsync();
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un estudio de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEstudio"].Value);

            FormEstudioDetalle formDetalle = new FormEstudioDetalle(idSeleccionado);

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                await CargarEstudiosSeguroAsync();
            }
        }

        private async void Delete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un estudio de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEstudio"].Value);
            string nombre = dataGridView1.CurrentRow.Cells["NombreEstudio"].Value.ToString() ?? "";

            var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar el estudio '{nombre}'?",
                                               "Confirmar Eliminación",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await EstudioClient.DeleteAsync(idSeleccionado);
                    await CargarEstudiosSeguroAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
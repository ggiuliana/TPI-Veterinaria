using API.Clients;
using DTOs;
using ModeloDominio;
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
    public partial class FormVeterinarioLista : Form
    {
        public FormVeterinarioLista()
        {
            InitializeComponent();
            this.Load += FormVeterinarioLista_Load;
        }

        private async void FormVeterinarioLista_Load(object? sender, EventArgs e)
        {
            await CargarVeterinariosSeguroAsync();
        }

        private async Task CargarVeterinariosSeguroAsync()
        {
            try
            {
                var veterinarios = await VeterinarioClient.GetAllAsync();
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.DataSource = veterinarios;
                /*
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
                */
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
                var veterinario = await VeterinarioClient.GetAsync(id);
                dataGridView1.DataSource = new List<VeterinarioDTO> { veterinario! };
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                    MessageBox.Show("No se encontró el veterinario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            FormVeterinarioDetalle formDetalle = new FormVeterinarioDetalle(0);

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                await CargarVeterinariosSeguroAsync();
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un veterinario de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdVeterinario"].Value);

            FormVeterinarioDetalle formDetalle = new FormVeterinarioDetalle(idSeleccionado);

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                await CargarVeterinariosSeguroAsync();
            }
        }
        private async void Delete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un veterinario de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdVeterinario"].Value);
            string nombre = dataGridView1.CurrentRow.Cells["NombreVeterinario"].Value.ToString() ?? "";

            var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar el veterinario '{nombre}'?",
                                               "Confirmar Eliminación",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await VeterinarioClient.DeleteAsync(idSeleccionado);
                    await CargarVeterinariosSeguroAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

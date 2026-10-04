using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using API.Clients;
using DTOs;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMascotaLista : Form
    {
        public FormMascotaLista()
        {
            InitializeComponent();
            this.Load += FormMascotaLista_Load;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void FormMascotaLista_Load(object? sender, EventArgs e)
        {
            await CargarMascotasSeguroAsync();
        }

        private async Task CargarMascotasSeguroAsync()
        {
            try
            {
                var authService = AuthServiceProvider.Instance;

                int? personaId = await authService.GetPersonaIdAsync();

                if (personaId.HasValue)
                {
                    var mascotas = await MascotaClient.GetAllByDuenioAsync(personaId.Value);

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = mascotas;
                }
                else
                {
                    MessageBox.Show("No se pudo identificar la sesión del usuario. Por favor, vuelva a iniciar sesión.",
                                    "Sesión inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idMascotaBuscar.Text))
            {
                await CargarMascotasSeguroAsync();
                return;
            }

            if (!int.TryParse(idMascotaBuscar.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            try
            {
                var mascota = await MascotaClient.GetAsync(id);
                dataGridView1.DataSource = new List<MascotaDTO> { mascota! };
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                    MessageBox.Show("No se encontró la mascota.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            FormMascotaDetalle formDetalle = new FormMascotaDetalle(0);

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                await CargarMascotasSeguroAsync();
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un mascota de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdMascota"].Value);

            FormMascotaDetalle formDetalle = new FormMascotaDetalle(idSeleccionado);

            if (formDetalle.ShowDialog() == DialogResult.OK)
            {
                await CargarMascotasSeguroAsync();
            }
        }

        private async void Delete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un mascota de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdMascota"].Value);
            string nombre = dataGridView1.CurrentRow.Cells["NombreMascota"].Value.ToString() ?? "";

            var confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar el mascota '{nombre}'?",
                                               "Confirmar Eliminación",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await MascotaClient.DeleteAsync(idSeleccionado);
                    await CargarMascotasSeguroAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DeleteEstudio : Form
    {
        public DeleteEstudio()
        {
            InitializeComponent();
            Load += DeleteEstudio_Load;
        }

        private async void DeleteEstudio_Load(object? sender, EventArgs e)
        {
            await CargarEstudiosSeguroAsync();
        }

        private async Task CargarEstudiosSeguroAsync()
        {
            try
            {
                var estudios = await EstudioClient.GetAllAsync();
                var lista = estudios.Select(es => new
                {
                    Id = es.IdEstudio,
                    Texto = es.NombreEstudio
                }).ToList();

                SeleccionEstudio.ValueMember = "Id";
                SeleccionEstudio.DisplayMember = "Texto";
                SeleccionEstudio.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de estudios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Aceptar_Click(object? sender, EventArgs e)
        {
            if (SeleccionEstudio.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un estudio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEstudio = (int)SeleccionEstudio.SelectedValue;

            var confirmacion = MessageBox.Show(
                "¿Está seguro de eliminar este estudio?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    
                    await EstudioClient.DeleteAsync(idEstudio);

                    MessageBox.Show("Estudio eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Cancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
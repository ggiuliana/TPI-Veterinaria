using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CreateEstudio : Form
    {
        public CreateEstudio()
        {
            InitializeComponent();
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                var estudio = new EstudioDTO
                {
                    IdEstudio = 0,
                    NombreEstudio = nombreEstudio.Text,
                    DescripcionEstudio = descripcionEstudio.Text
                };

                var est = await EstudioClient.AddAsync(estudio);

                if (est == null)
                {
                    MessageBox.Show("No se pudo obtener el ID del estudio creado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Estudio creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
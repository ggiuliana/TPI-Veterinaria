using API.Clients;
using DTOs;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class UpdateEstudio : Form
    {
        public UpdateEstudio()
        {
            InitializeComponent();
            Load += UpdateEstudio_Load;
        }

        private async void UpdateEstudio_Load(object? sender, EventArgs e)
        {
            await CargarEstudiosSeguroAsync();
        }

        private async Task CargarEstudiosSeguroAsync()
        {
            try
            {
                var estudios = await EstudioClient.GetAllAsync();

                SeleccionEstudio.SelectedIndexChanged -= SeleccionEstudio_SelectedIndexChanged;

                var lista = estudios.Select(es => new
                {
                    Id = es.IdEstudio,
                    Texto = es.NombreEstudio
                }).ToList();

                SeleccionEstudio.ValueMember = "Id";
                SeleccionEstudio.DisplayMember = "Texto";
                SeleccionEstudio.DataSource = lista;

                SeleccionEstudio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                SeleccionEstudio.AutoCompleteSource = AutoCompleteSource.ListItems;

                SeleccionEstudio.SelectedIndex = -1;

                SeleccionEstudio.SelectedIndexChanged += SeleccionEstudio_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de estudios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SeleccionEstudio_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (SeleccionEstudio.SelectedValue == null)
                return;

            if (SeleccionEstudio.SelectedValue is not int)
                return;

            int idEstudio = (int)SeleccionEstudio.SelectedValue;

            try
            {
                var estudio = await EstudioClient.GetAsync(idEstudio);

                if (estudio == null)
                    return;

                nombreEstudio.Text = estudio.NombreEstudio;
                descripcionEstudio.Text = estudio.DescripcionEstudio;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos del estudio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            if (SeleccionEstudio.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un estudio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new EstudioDTO
            {
                IdEstudio = (int)SeleccionEstudio.SelectedValue,
                NombreEstudio = nombreEstudio.Text,
                DescripcionEstudio = descripcionEstudio.Text
            };

            try
            {
                await EstudioClient.UpdateAsync(dto);

                MessageBox.Show("Estudio modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
using API.Clients;
using DTOs;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class UpdateVeterinario : Form
    {
        public UpdateVeterinario()
        {
            InitializeComponent();
            Load += UpdateVeterinario_Load;
        }

        private async void UpdateVeterinario_Load(object? sender, EventArgs e)
        {
            await CargarVeterinariosSeguroAsync();
        }

        private async Task CargarVeterinariosSeguroAsync()
        {
            try
            {
                var veterinarios = await VeterinarioClient.GetAllAsync();

                SeleccionVet.SelectedIndexChanged -= SeleccionVet_SelectedIndexChanged;

                var lista = veterinarios.Select(v => new
                {
                    Id = v.IdVeterinario,
                    Texto = $"{v.NombreVeterinario} {v.Apellido}"
                }).ToList();

                SeleccionVet.ValueMember = "Id";
                SeleccionVet.DisplayMember = "Texto";
                SeleccionVet.DataSource = lista;

                SeleccionVet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                SeleccionVet.AutoCompleteSource = AutoCompleteSource.ListItems;

                SeleccionVet.SelectedIndex = -1;

                SeleccionVet.SelectedIndexChanged += SeleccionVet_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de veterinarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SeleccionVet_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (SeleccionVet.SelectedValue == null)
                return;

            if (SeleccionVet.SelectedValue is not int)
                return;

            int idVeterinario = (int)SeleccionVet.SelectedValue;

            try
            {
                var veterinario = await VeterinarioClient.GetAsync(idVeterinario);

                if (veterinario == null)
                    return;

                nombreVeterinario.Text = veterinario.NombreVeterinario;
                apellidoVeterinario.Text = veterinario.Apellido;
                dniVeterinario.Text = veterinario.Dni;
                telefonoVeterinario.Text = veterinario.Telefono;
                mailVeterinario.Text = veterinario.Mail;
                direccionVeterinario.Text = veterinario.Direccion;
                matriculaVeterinario.Text = veterinario.Matricula;
                especialidadVeterinario.Text = veterinario.Especialidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos del veterinario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            if (SeleccionVet.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un veterinario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new VeterinarioDTO
            {
                IdVeterinario = (int)SeleccionVet.SelectedValue,
                NombreVeterinario = nombreVeterinario.Text,
                Apellido = apellidoVeterinario.Text,
                Dni = dniVeterinario.Text,
                Telefono = telefonoVeterinario.Text,
                Mail = mailVeterinario.Text,
                Direccion = direccionVeterinario.Text,
                Matricula = matriculaVeterinario.Text,
                Especialidad = especialidadVeterinario.Text
            };

            try
            {
                await VeterinarioClient.UpdateAsync(dto);

                MessageBox.Show("Veterinario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
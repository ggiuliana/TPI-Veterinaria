using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CreateVeterinario : Form
    {
        public CreateVeterinario() => InitializeComponent();

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                var veterinario = new VeterinarioDTO
                {
                    IdVeterinario = 0,
                    NombreVeterinario = nombreVeterinario.Text,
                    Apellido = apellidoVeterinario.Text,
                    Telefono = telefonoVeterinario.Text,
                    Mail = mailVeterinario.Text,
                    Dni = dniVeterinario.Text,
                    Direccion = direccionVeterinario.Text,
                    Matricula = matriculaVeterinario.Text,
                    Especialidad = especialidadVeterinario.Text
                };


                var vet = await VeterinarioClient.AddAsync(veterinario);

                if (vet == null)
                {
                    MessageBox.Show("No se pudo obtener el ID del veterinario creado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var usuario = new UsuarioDTO
                {
                    IdUsuario = 0,
                    NombreUsuario = nombreUsuario.Text,
                    Contrasenia = contraseniaUsuario.Text,
                    EstadoUsuario = "Activo",
                    IdPersona = vet.IdVeterinario,
                    IdRol = 2
                };

                await UsuarioClient.AddAsync(usuario);

                MessageBox.Show("Veterinario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
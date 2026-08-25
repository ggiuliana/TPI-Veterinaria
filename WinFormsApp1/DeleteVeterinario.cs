using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DeleteVeterinario : Form
    {
        public DeleteVeterinario()
        {
            InitializeComponent();
            Load += DeleteVeterinario_Load; 
        }

        private async void DeleteVeterinario_Load(object sender, EventArgs e)
        {
            await CargarVeterinariosSeguroAsync();
        }

        private async Task CargarVeterinariosSeguroAsync()
        {
            try
            {
                var veterinarios = await VeterinarioClient.GetAllAsync();
                var lista = veterinarios.Select(v => new
                {
                    Id = v.IdVeterinario,
                    Texto = $"{v.NombreVeterinario} {v.Apellido}"
                }).ToList();

                SeleccionVet.ValueMember = "Id";
                SeleccionVet.DisplayMember = "Texto";
                SeleccionVet.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de veterinarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Aceptar_Click(object sender, EventArgs e)
        {
            if (SeleccionVet.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un veterinario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVeterinario = (int)SeleccionVet.SelectedValue;

            var confirmacion = MessageBox.Show(
                "¿Está seguro de eliminar este veterinario y su usuario asociado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var usuarios = await UsuarioClient.GetAllAsync();
                    var usuario = usuarios.FirstOrDefault(u => u.IdPersona == idVeterinario);

                    if (usuario != null)
                    {
                        await UsuarioClient.DeleteAsync(usuario.IdUsuario);
                    }

                    await VeterinarioClient.DeleteAsync(idVeterinario);

                    MessageBox.Show("Veterinario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
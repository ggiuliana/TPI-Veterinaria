using DTOs;
using ServiciosApp;
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
    public partial class DeleteVeterinario : Form
    {
        private readonly IVeterinarioService veterinarioService;
        private readonly IUsuarioService usuarioService;

        public DeleteVeterinario(IVeterinarioService veterinarioService, IUsuarioService usuarioService)
        {
            InitializeComponent();

            this.veterinarioService = veterinarioService;

            this.usuarioService = usuarioService;
        }
        private async void DeleteVeterinario_Load(object sender, EventArgs e)
        {
            await CargarVeterinarios();
        }

        private async Task CargarVeterinarios()
        {
            var veterinarios = await veterinarioService.GetAllAsync();
            var lista = veterinarios.Select(v => new
            {
                Id = v.IdVeterinario,
                Texto = $"{v.NombreVeterinario} {v.Apellido}"
            }).ToList();

            SeleccionVet.ValueMember = "Id";
            SeleccionVet.DisplayMember = "Texto";
            SeleccionVet.DataSource = lista;
        }

        private async void Aceptar_Click(object sender, EventArgs e)
        {
            if (SeleccionVet.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un veterinario.");
                return;
            }

            int idVeterinario = (int)SeleccionVet.SelectedValue;

            var confirmacion = MessageBox.Show(
                "¿Está seguro de eliminar este veterinario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                await veterinarioService.DeleteAsync(idVeterinario);
                var usuarios = await usuarioService.GetAllAsync();
                var usuario = usuarios.FirstOrDefault(u => u.IdPersona == idVeterinario);
                if (usuario != null) {
                    await usuarioService.DeleteAsync(usuario.IdUsuario);
                }
                MessageBox.Show("Veterinario eliminado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

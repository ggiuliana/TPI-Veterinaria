using ModeloDominio;
using ServiciosApp;
using DTOs;
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
    public partial class CreateVeterinario : Form
    {
        private readonly IVeterinarioService veterinarioService;
        private readonly IUsuarioService usuarioService;

        public CreateVeterinario(IVeterinarioService veterinarioService, IUsuarioService usuarioService)
        {
            InitializeComponent();

            this.veterinarioService = veterinarioService;

            this.usuarioService = usuarioService;
        }

        private async void Guardar_Click(object sender, EventArgs e)
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

            var vet = await veterinarioService.AddAsync(veterinario);

            var usuario = new UsuarioDTO
            {
                IdUsuario = 0,
                NombreUsuario = nombreUsuario.Text,
                Contrasenia = contraseniaUsuario.Text,
                EstadoUsuario = "Activo",
                IdPersona = vet.IdVeterinario,
                IdRol = 2
            };

            var usu = await usuarioService.AddAsync(usuario);
            MessageBox.Show("Veterinario creado correctamente.");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

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
    public partial class UpdateVeterinario : Form
    {
        private readonly IVeterinarioService veterinarioService;

        public UpdateVeterinario(IVeterinarioService veterinarioService)
        {
            InitializeComponent();

            this.veterinarioService = veterinarioService;
        }

        private async void UpdateVeterinario_Load(object sender, EventArgs e)
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
        private async void SeleccionVet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeleccionVet.SelectedValue == null)
                return;
            if (SeleccionVet.SelectedValue is not int)
                return;
            int idVeterinario = (int)SeleccionVet.SelectedValue;
            var veterinario = await veterinarioService.GetAsync(idVeterinario);
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

        private async void Guardar_Click(object sender, EventArgs e) {
            if (SeleccionVet.SelectedValue == null) 
            {
                MessageBox.Show("Selecciona un veterinario.");
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
            await veterinarioService.UpdateAsync(dto);
            MessageBox.Show("Veterinario modificado.");
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

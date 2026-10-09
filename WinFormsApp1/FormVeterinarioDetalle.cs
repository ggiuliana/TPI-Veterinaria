using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormVeterinarioDetalle : Form
    {
        private readonly int _idVeterinarioActual;
        private readonly VeterinarioClient VeterinarioClient;
        private readonly UsuarioClient UsuarioClient;
        public FormVeterinarioDetalle(int idVeterinario = 0)
        {
            InitializeComponent();
            _idVeterinarioActual = idVeterinario;
            this.Load += FormVeterinarioDetalle_Load;
            IAuthService authService = Program.AuthService;
            VeterinarioClient = new VeterinarioClient(authService);
            UsuarioClient = new UsuarioClient(authService);
        }

        private async void FormVeterinarioDetalle_Load(object? sender, EventArgs e)
        {
            if (_idVeterinarioActual > 0)
            {
                this.Text = "Editar Veterinario";
                lblTitulo.Text = "MODIFICAR VETERINARIO";

                pnlUsuario.Visible = false;

                try
                {
                    var veterinario = await VeterinarioClient.GetAsync(_idVeterinarioActual);
                    if (veterinario != null)
                    {
                        nombreVeterinario.Text = veterinario.NombreVeterinario;
                        apellidoVeterinario.Text = veterinario.Apellido;
                        telefonoVeterinario.Text = veterinario.Telefono;
                        mailVeterinario.Text = veterinario.Mail;
                        direccionVeterinario.Text = veterinario.Direccion;
                        dniVeterinario.Text = veterinario.Dni;
                        matriculaVeterinario.Text = veterinario.Matricula;
                        especialidadVeterinario.Text = veterinario.Especialidad;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    this.Close();
                }
            }
            else
            {
                this.Text = "Nuevo Veterinario";
                lblTitulo.Text = "NUEVO VETERINARIO";

                pnlUsuario.Visible = true;
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idVeterinarioActual == 0)
                {
                    var vetDto = new VeterinarioDTO
                    {
                        NombreVeterinario = nombreVeterinario.Text,
                        Apellido = apellidoVeterinario.Text,
                        Telefono = telefonoVeterinario.Text,
                        Mail = mailVeterinario.Text,
                        Dni = dniVeterinario.Text,
                        Direccion = direccionVeterinario.Text,
                        Matricula = matriculaVeterinario.Text,
                        Especialidad = especialidadVeterinario.Text
                    };
                    var usuDto = new UsuarioCreateDTO
                    {
                        NombreUsuario = nombreUsuario.Text,
                        Contrasenia = contraseniaUsuario.Text,
                        IdGrupo = 2
                    };
                    var createDto = new VeterinarioRegisterDTO
                    {
                        veterinario = vetDto,
                        usuario = usuDto
                    };
                    var resultado =  await UsuarioClient.RegisterVetAsync(createDto);
                    if (resultado.Exito)
                    {
                        MessageBox.Show(resultado.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultado.Mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    var updateDto = new VeterinarioDTO
                    {
                        IdVeterinario = _idVeterinarioActual,
                        NombreVeterinario = nombreVeterinario.Text,
                        Apellido = apellidoVeterinario.Text,
                        Telefono = telefonoVeterinario.Text,
                        Mail = mailVeterinario.Text,
                        Dni = dniVeterinario.Text,
                        Direccion = direccionVeterinario.Text,
                        Matricula = matriculaVeterinario.Text,
                        Especialidad = especialidadVeterinario.Text
                    };
                    await VeterinarioClient.UpdateAsync(updateDto);
                }

                MessageBox.Show("Guardado exitosamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
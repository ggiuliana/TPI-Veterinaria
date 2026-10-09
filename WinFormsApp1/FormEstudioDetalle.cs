using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormEstudioDetalle : Form
    {
        private readonly int _idEstudioActual;
        private readonly EstudioClient EstudioClient;
        public FormEstudioDetalle(int idEstudio = 0)
        {
            InitializeComponent();
            _idEstudioActual = idEstudio;

            this.Load += FormEstudioDetalle_Load;
            IAuthService authService = Program.AuthService;
            EstudioClient = new EstudioClient(authService);
        }
        private async void FormEstudioDetalle_Load(object? sender, EventArgs e)
        {
            if (_idEstudioActual > 0)
            {
                this.Text = "Editar Estudio";
                lblTitulo.Text = "EDITAR ESTUDIO";
                try
                {
                    var estudio = await EstudioClient.GetAsync(_idEstudioActual);
                    if (estudio != null)
                    {
                        nombreEstudio.Text = estudio.NombreEstudio;
                        descripcionEstudio.Text = estudio.DescripcionEstudio;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el estudio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                this.Text = "Nuevo Estudio";
                lblTitulo.Text = "NUEVO ESTUDIO";
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                var estudio = new EstudioDTO
                {
                    IdEstudio = _idEstudioActual,
                    NombreEstudio = nombreEstudio.Text,
                    DescripcionEstudio = descripcionEstudio.Text
                };

                if (_idEstudioActual == 0)
                {
                    var est = await EstudioClient.AddAsync(estudio);
                    if (est == null)
                    {
                        MessageBox.Show("No se pudo obtener el ID del estudio creado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    await EstudioClient.UpdateAsync(estudio);
                }

                MessageBox.Show("Estudio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
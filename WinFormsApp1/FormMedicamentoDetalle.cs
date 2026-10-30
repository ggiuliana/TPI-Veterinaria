using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMedicamentoDetalle : Form
    {
        private readonly int _idMedicamentoActual;
        private readonly MedicamentoClient MedicamentoClient;

        public FormMedicamentoDetalle(int idMedicamento = 0)
        {
            InitializeComponent();
            _idMedicamentoActual = idMedicamento;
            this.Load += FormMedicamentoDetalle_Load;
            IAuthService authService = Program.AuthService;
            MedicamentoClient = new MedicamentoClient(authService, Program.Configuration);
        }

        private async void FormMedicamentoDetalle_Load(object? sender, EventArgs e)
        {
            if (_idMedicamentoActual > 0)
            {
                this.Text = "Editar Medicamento";
                lblTitulo.Text = "EDITAR MEDICAMENTO";
                try
                {
                    var med = await MedicamentoClient.GetAsync(_idMedicamentoActual);
                    if (med != null)
                    {
                        nombreMedicamento.Text = med.NombreMedicamento;
                        cantidadRestante.Text = med.CantidadRestante.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                this.Text = "Nuevo Medicamento";
                lblTitulo.Text = "NUEVO MEDICAMENTO";
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreMedicamento.Text))
            {
                MessageBox.Show("El nombre del medicamento no puede estar vacío.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nombreMedicamento.Focus();
                return;
            }

            if (!int.TryParse(cantidadRestante.Text, out int cant) || cant <= 0)
            {
                MessageBox.Show("La cantidad restante debe ser un número entero mayor a cero.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cantidadRestante.Focus();
                return;
            }

            try
            {
                var dto = new MedicamentoDTO
                {
                    IdMedicamento = _idMedicamentoActual,
                    NombreMedicamento = nombreMedicamento.Text.Trim(),
                    CantidadRestante = cant
                };

                if (_idMedicamentoActual == 0)
                {
                    await MedicamentoClient.AddAsync(dto);
                }
                else
                {
                    await MedicamentoClient.UpdateAsync(dto);
                }

                MessageBox.Show("Guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
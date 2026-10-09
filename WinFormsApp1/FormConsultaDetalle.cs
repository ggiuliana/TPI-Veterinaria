using System.ComponentModel;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using ModeloDominio;

namespace WinFormsApp1
{
    public partial class FormConsultaDetalle : Form
    {
        private readonly int _idTurnoActual;
        private ConsultaDTO? _consultaExistente;
        private readonly ConsultaClient ConsultaClient;
        private readonly MedicamentoClient MedicamentoClient;

        private BindingList<MedicamentoConsultaDTO> _medicamentosTemporales = new BindingList<MedicamentoConsultaDTO>();

        public FormConsultaDetalle(int idTurno)
        {
            InitializeComponent();
            _idTurnoActual = idTurno;
            this.Load += FormConsultaDetalle_Load;
            IAuthService authService = Program.AuthService;
            ConsultaClient = new ConsultaClient(authService);
            MedicamentoClient = new MedicamentoClient(authService);
        }

        private async void FormConsultaDetalle_Load(object? sender, EventArgs e)
        {
            dgvMedicamentos.AutoGenerateColumns = false;
            dgvMedicamentos.DataSource = _medicamentosTemporales;

            try
            {
                var medicamentosDb = await MedicamentoClient.GetAllAsync();
                cmbMedicamentos.DataSource = medicamentosDb;
                cmbMedicamentos.DisplayMember = "NombreMedicamento";
                cmbMedicamentos.ValueMember = "IdMedicamento";

                _consultaExistente = await ConsultaClient.GetByIdTurnoAsync(_idTurnoActual);

                if (_consultaExistente != null)
                {
                    this.Text = "Editar Consulta";

                    txtDiagnostico.Text = _consultaExistente.Diagnostico;
                    txtTratamiento.Text = _consultaExistente.Tratamiento;
                    numPeso.Value = (decimal)_consultaExistente.Peso;
                    txtObservaciones.Text = _consultaExistente.Observaciones ?? "";

                    if (_consultaExistente.MedicamentoConsulta != null)
                    {
                        var listaMedicamentos = (IEnumerable<MedicamentoDTO>)cmbMedicamentos.DataSource;

                        foreach (var med in _consultaExistente.MedicamentoConsulta)
                        {
                            var infoMed = listaMedicamentos.FirstOrDefault(m => m.IdMedicamento == med.IdMedicamento);
                            if (infoMed != null)
                            {
                                med.NombreMedicamento = infoMed.NombreMedicamento;
                            }

                            _medicamentosTemporales.Add(med);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
                this.Close();
            }
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            if (cmbMedicamentos.SelectedValue != null && numCantidadMedicamento.Value > 0)
            {
                int idMedSeleccionado = (int)cmbMedicamentos.SelectedValue;

                if (_medicamentosTemporales.Any(m => m.IdMedicamento == idMedSeleccionado))
                {
                    MessageBox.Show("Este medicamento ya está en la lista. Si desea modificar la cantidad, elimínelo primero y vuelva a agregarlo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                var nuevoMed = new MedicamentoConsultaDTO
                {
                    IdMedicamento = idMedSeleccionado,
                    CantidadUsada = (int)numCantidadMedicamento.Value,
                    NombreMedicamento = cmbMedicamentos.Text
                };

                _medicamentosTemporales.Add(nuevoMed);
                numCantidadMedicamento.Value = 0;
            }
            else
            {
                MessageBox.Show("Por favor seleccione un medicamento y una cantidad mayor a 0.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnostico.Text) || string.IsNullOrWhiteSpace(txtTratamiento.Text))
            {
                MessageBox.Show("El diagnóstico y el tratamiento son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var consultaDto = new ConsultaDTO
            {
                IdTurno = _idTurnoActual,
                Diagnostico = txtDiagnostico.Text,
                Tratamiento = txtTratamiento.Text,
                Peso = (float)numPeso.Value,
                Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text,
                MedicamentoConsulta = _medicamentosTemporales.ToList()
            };

            try
            {
                if (_consultaExistente == null)
                {
                    await ConsultaClient.AddAsync(consultaDto);
                    MessageBox.Show("Consulta registrada con éxito.");
                }
                else
                {
                    consultaDto.IdConsulta = _consultaExistente.IdConsulta;
                    await ConsultaClient.UpdateAsync(consultaDto);
                    MessageBox.Show("Consulta modificada con éxito.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void btnQuitarMedicamento_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow != null)
            {
                var filaSeleccionada = (MedicamentoConsultaDTO)dgvMedicamentos.CurrentRow.DataBoundItem;

                if (filaSeleccionada != null)
                {
                    _medicamentosTemporales.Remove(filaSeleccionada);
                }
            }
        }
    }
}
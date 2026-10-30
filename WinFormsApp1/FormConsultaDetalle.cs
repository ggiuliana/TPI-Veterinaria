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
        private readonly EstudioClient EstudioClient;

        private BindingList<MedicamentoConsultaDTO> _medicamentosTemporales = new();
        private BindingList<EstudioDTO> _estudiosTemporales = new();

        public FormConsultaDetalle(int idTurno)
        {
            InitializeComponent();
            _idTurnoActual = idTurno;
            this.Load += FormConsultaDetalle_Load;
            IAuthService authService = Program.AuthService;
            ConsultaClient = new ConsultaClient(authService, Program.Configuration);
            MedicamentoClient = new MedicamentoClient(authService, Program.Configuration);
            EstudioClient = new EstudioClient(authService, Program.Configuration);
        }

        private async void FormConsultaDetalle_Load(object? sender, EventArgs e)
        {
            dgvMedicamentos.AutoGenerateColumns = false;
            dgvMedicamentos.DataSource = _medicamentosTemporales;
            dgvEstudios.AutoGenerateColumns = false;
            dgvEstudios.DataSource = _estudiosTemporales;

            try
            {
                var medicamentosDb = await MedicamentoClient.GetAllAsync();
                cmbMedicamentos.DataSource = medicamentosDb;
                cmbMedicamentos.DisplayMember = "NombreMedicamento";
                cmbMedicamentos.ValueMember = "IdMedicamento";

                var estudiosDb = await EstudioClient.GetAllAsync();
                cmbEstudios.DataSource = estudiosDb;
                cmbEstudios.DisplayMember = "NombreEstudio";
                cmbEstudios.ValueMember = "IdEstudio";

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
                        var listaEstudios = (IEnumerable<EstudioDTO>)cmbEstudios.DataSource;
                        foreach (var idEstudio in _consultaExistente?.IdEstudios ?? Enumerable.Empty<int>())
                        {
                            var infoEst = listaEstudios.FirstOrDefault(e => e.IdEstudio == idEstudio);
                            if (infoEst != null)
                            {
                                _estudiosTemporales.Add(infoEst);
                            }
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
                int cantidadIngresada = (int)numCantidadMedicamento.Value;

                var listaMedicamentos = cmbMedicamentos.DataSource as IEnumerable<MedicamentoDTO>;
                var infoMed = listaMedicamentos?.FirstOrDefault(m => m.IdMedicamento == idMedSeleccionado);

                if (infoMed != null && cantidadIngresada > infoMed.CantidadRestante)
                {
                    MessageBox.Show($"Stock insuficiente. Solo quedan {infoMed.CantidadRestante} unidades de {infoMed.NombreMedicamento}.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_medicamentosTemporales.Any(m => m.IdMedicamento == idMedSeleccionado))
                {
                    MessageBox.Show("Este medicamento ya está en la lista. Si desea modificar la cantidad, elimínelo primero y vuelva a agregarlo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoMed = new MedicamentoConsultaDTO
                {
                    IdMedicamento = idMedSeleccionado,
                    CantidadUsada = cantidadIngresada,
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

            if (numPeso.Value <= 0)
            {
                MessageBox.Show("El peso del animal debe ser mayor a cero.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var consultaDto = new ConsultaDTO
            {
                IdTurno = _idTurnoActual,
                Diagnostico = txtDiagnostico.Text,
                Tratamiento = txtTratamiento.Text,
                Peso = (float)numPeso.Value,
                Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text,
                MedicamentoConsulta = _medicamentosTemporales.ToList(),
                IdEstudios = _estudiosTemporales.Select(e => e.IdEstudio).ToList()
            };

            try
            {
                if (_consultaExistente == null)
                {
                    await ConsultaClient.AddAsync(consultaDto);
                }
                else
                {
                    consultaDto.IdConsulta = _consultaExistente.IdConsulta;
                    await ConsultaClient.UpdateAsync(consultaDto);
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
        private void btnAgregarEstudio_Click(object sender, EventArgs e)
        {
            if (cmbEstudios.SelectedValue != null)
            {
                int idSeleccionado = (int)cmbEstudios.SelectedValue;
                var listaEstudios = cmbEstudios.DataSource as IEnumerable<EstudioDTO>;
                var infoEst = listaEstudios?.FirstOrDefault(es => es.IdEstudio == idSeleccionado);

                if (_estudiosTemporales.Any(es => es.IdEstudio == idSeleccionado))
                {
                    MessageBox.Show("Este estudio ya está en la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (infoEst != null)
                {
                    _estudiosTemporales.Add(infoEst);
                }
            }
        }
        private void btnQuitarEstudio_Click(object sender, EventArgs e)
        {
            if (dgvEstudios.CurrentRow != null)
            {
                var fila = (EstudioDTO)dgvEstudios.CurrentRow.DataBoundItem;
                if (fila != null) _estudiosTemporales.Remove(fila);
            }
        }
    }
}
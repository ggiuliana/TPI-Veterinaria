using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormTurnoDetalle : Form
    {
        private readonly int _idTurnoActual;

        public FormTurnoDetalle(int idTurno = 0)
        {
            InitializeComponent();
            _idTurnoActual = idTurno;
            this.Load += FormTurnoDetalle_Load;
        }

        private async void FormTurnoDetalle_Load(object? sender, EventArgs e)
        {
            if (_idTurnoActual > 0)
            {
                this.Text = "Editar Turno";
                lblTitulo.Text = "MODIFICAR TURNO";

                try
                {
                    var turno = await TurnoClient.GetAsync(_idTurnoActual);
                    if (turno != null)
                    {
                        dtpFecha.Value = turno.FechaTurno.ToDateTime(TimeOnly.MinValue);
                        dtpHora.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                     turno.HoraTurno.Hour, turno.HoraTurno.Minute, 0);

                        txtIdMascota.Text = turno.IdMascota.ToString();
                        txtIdVeterinario.Text = turno.IdVeterinario.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el turno: {ex.Message}");
                    this.Close();
                }
            }
            else
            {
                this.Text = "Nuevo Turno";
                lblTitulo.Text = "NUEVO TURNO";
                dtpFecha.Value = DateTime.Now;
                dtpHora.Value = DateTime.Now;
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdVeterinario.Text, out int idVeterinario))
                {
                    MessageBox.Show("El ID del veterinario debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? idMascota = null;
                if (!string.IsNullOrWhiteSpace(txtIdMascota.Text))
                {
                    if (int.TryParse(txtIdMascota.Text, out int idParseado))
                    {
                        idMascota = idParseado;
                    }
                    else
                    {
                        MessageBox.Show("Si asigna una mascota, el ID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var turnoDto = new TurnoDTO
                {
                    FechaTurno = DateOnly.FromDateTime(dtpFecha.Value),
                    HoraTurno = TimeOnly.FromDateTime(dtpHora.Value),
                    IdVeterinario = idVeterinario,
                    IdMascota = idMascota,

                    EstadoTurno = idMascota.HasValue ? "Otorgado" : "Pendiente"
                };

                if (_idTurnoActual == 0)
                {
                    await TurnoClient.AddAsync(turnoDto);
                }
                else
                {
                    turnoDto.IdTurno = _idTurnoActual;
                    await TurnoClient.UpdateAsync(turnoDto);
                }

                MessageBox.Show("Guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

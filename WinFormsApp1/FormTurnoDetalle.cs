using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormTurnoDetalle : Form
    {
        private readonly int _idTurnoActual;
        private readonly TurnoClient TurnoClient;
        private string _estadoActual = "Disponible";
        public FormTurnoDetalle(int idTurno = 0)
        {
            InitializeComponent();
            _idTurnoActual = idTurno;
            this.Load += FormTurnoDetalle_Load;
            IAuthService authService = Program.AuthService;
            TurnoClient = new TurnoClient(authService);
        }

        private async void FormTurnoDetalle_Load(object? sender, EventArgs e)
        {
            string rolActual = await Program.AuthService.GetRolAsync();
            int? idUsuarioActual = await Program.AuthService.GetPersonaIdAsync();
            bool esAdministrador = rolActual == "Administrador";
            txtIdVeterinario.Visible = esAdministrador;
            lblVeterinario.Visible = esAdministrador;

            if (_idTurnoActual > 0)
            {
                this.Text = "Editar Turno";
                lblTitulo.Text = "MODIFICAR TURNO";

                txtIdMascota.Visible = true;
                lblMascota.Visible = true;
                txtIdMascota.ReadOnly = true;

                try
                {
                    var turno = await TurnoClient.GetAsync(_idTurnoActual);
                    if (turno != null)
                    {
                        _estadoActual = turno.EstadoTurno;

                        dtpFecha.Value = turno.FechaTurno.ToDateTime(TimeOnly.MinValue);
                        dtpHora.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                     turno.HoraTurno.Hour, turno.HoraTurno.Minute, 0);

                        txtIdMascota.Text = turno.IdMascota.ToString();
                        txtIdVeterinario.Text = turno.IdVeterinario.ToString();
                        txtObservaciones.Text = turno.Observaciones ?? "";
                        if (turno.EstadoTurno == "Otorgado" || turno.EstadoTurno == "Resuelto")
                        {
                            dtpFecha.Enabled = false;
                            dtpHora.Enabled = false;
                        }
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

                txtIdMascota.Visible = false;
                lblMascota.Visible = false;
                txtIdMascota.Text = "";
                txtObservaciones.Text = "";
            }
            if (!esAdministrador)
            {
                txtIdVeterinario.Text = idUsuarioActual.ToString();
            }
            else
            {
                txtIdVeterinario.Text = "";
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

                    EstadoTurno = (_estadoActual == "Resuelto") ? "Resuelto" : (idMascota.HasValue ? "Otorgado" : "Disponible"),
                    Observaciones = string.IsNullOrWhiteSpace(txtObservaciones.Text) ? null : txtObservaciones.Text
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

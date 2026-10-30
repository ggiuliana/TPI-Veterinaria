using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormTurnoDetalle : Form
    {
        private readonly int _idTurnoActual;
        private readonly TurnoClient TurnoClient;
        private readonly VeterinarioClient VeterinarioClient;
        private readonly MascotaClient MascotaClient; 
        private string _estadoActual = "Disponible";

        public FormTurnoDetalle(int idTurno = 0)
        {
            InitializeComponent();
            _idTurnoActual = idTurno;
            this.Load += FormTurnoDetalle_Load;

            IAuthService authService = Program.AuthService;
            TurnoClient = new TurnoClient(authService, Program.Configuration);
            VeterinarioClient = new VeterinarioClient(authService, Program.Configuration);
            MascotaClient = new MascotaClient(authService, Program.Configuration);
        }

        private async void FormTurnoDetalle_Load(object? sender, EventArgs e)
        {
            try
            {
                string rolActual = await Program.AuthService.GetRolAsync();
                int? idUsuarioActual = await Program.AuthService.GetPersonaIdAsync();
                bool esAdministrador = rolActual?.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase) == true;

                txtVeterinario.Visible = esAdministrador;
                lblVeterinario.Visible = esAdministrador;

                if (esAdministrador)
                {
                    var veterinarios = await VeterinarioClient.GetAllAsync();
                    if (veterinarios != null)
                    {
                        var listaVets = veterinarios.Select(v => new
                        {
                            Id = v.IdVeterinario,
                            NombreCompleto = $"{v.NombreVeterinario} {v.Apellido}"
                        }).ToList();

                        txtVeterinario.DataSource = listaVets;
                        txtVeterinario.DisplayMember = "NombreCompleto";
                        txtVeterinario.ValueMember = "Id";
                        txtVeterinario.SelectedIndex = -1;
                    }
                }

                var mascotas = await MascotaClient.GetAllAsync();
                if (mascotas != null)
                {
                    var listaMascotas = mascotas.Select(m => new
                    {
                        Id = m.IdMascota,
                        Nombre = m.NombreMascota
                    }).ToList();

                    txtMascota.DataSource = listaMascotas;
                    txtMascota.DisplayMember = "Nombre";
                    txtMascota.ValueMember = "Id";
                    txtMascota.SelectedIndex = -1;
                }

                if (_idTurnoActual > 0)
                {
                    this.Text = "Editar Turno";
                    lblTitulo.Text = "MODIFICAR TURNO";

                    txtMascota.Visible = true;
                    lblMascota.Visible = true;

                    var turno = await TurnoClient.GetAsync(_idTurnoActual);
                    if (turno != null)
                    {
                        _estadoActual = turno.EstadoTurno;

                        dtpFecha.Value = turno.FechaTurno.ToDateTime(TimeOnly.MinValue);
                        dtpHora.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                     turno.HoraTurno.Hour, turno.HoraTurno.Minute, 0);

                        txtObservaciones.Text = turno.Observaciones ?? "";

                        if (turno.IdMascota.HasValue)
                        {
                            txtMascota.SelectedValue = turno.IdMascota.Value;
                        }

                        if (esAdministrador)
                        {
                            txtVeterinario.SelectedValue = turno.IdVeterinario;
                        }

                        if (turno.EstadoTurno == "Otorgado" || turno.EstadoTurno == "Resuelto")
                        {
                            dtpFecha.Enabled = false;
                            dtpHora.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.Text = "Nuevo Turno";
                    lblTitulo.Text = "NUEVO TURNO";
                    dtpFecha.Value = DateTime.Now;
                    dtpHora.Value = DateTime.Now;
                    txtMascota.Visible = false;
                    lblMascota.Visible = false;
                    txtMascota.SelectedIndex = -1;
                    txtObservaciones.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el detalle del turno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rolActual = await Program.AuthService.GetRolAsync();
                bool esAdministrador = rolActual?.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase) == true;

                int idVeterinario;
                if (esAdministrador)
                {
                    if (txtVeterinario.SelectedValue == null || !int.TryParse(txtVeterinario.SelectedValue.ToString(), out idVeterinario))
                    {
                        MessageBox.Show("Debe seleccionar un veterinario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    int? idUsuarioActual = await Program.AuthService.GetPersonaIdAsync();
                    if (!idUsuarioActual.HasValue)
                    {
                        MessageBox.Show("No se pudo identificar al veterinario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    idVeterinario = idUsuarioActual.Value;
                }

                int? idMascota = null;

                if (txtMascota.Visible && txtMascota.SelectedValue != null)
                {
                    if (int.TryParse(txtMascota.SelectedValue.ToString(), out int idParseado))
                    {
                        idMascota = idParseado;
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
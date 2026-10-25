using API.Clients;
using DTOs;
using ModeloDominio;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMascotaDetalle : Form
    {
        private readonly int _idMascotaActual;
        private readonly MascotaClient MascotaClient;
        private readonly TipoVacunaClient TipoVacunaClient;
        private ICollection<VacunaDTO> _vacunasPendientes = new List<VacunaDTO>();
        private ICollection<TipoVacunaDTO> _tiposVacuna = new List<TipoVacunaDTO>();
        public FormMascotaDetalle(int idMascota = 0)
        {
            InitializeComponent();
            _idMascotaActual = idMascota;

            this.Load += FormMascotaDetalle_Load;
            IAuthService authService = Program.AuthService;
            MascotaClient = new MascotaClient(authService);
            TipoVacunaClient = new TipoVacunaClient(authService);
        }
        private async void FormMascotaDetalle_Load(object? sender, EventArgs e)
        {
            tipoVacuna.DataSource = await TipoVacunaClient.GetAllAsync();
            tipoVacuna.DisplayMember = "NombreTipoVacuna";
            tipoVacuna.ValueMember = "IdTipoVacuna";
            CargarGrilla();

            _tiposVacuna = await TipoVacunaClient.GetAllAsync();

            tipoVacuna.DataSource = _tiposVacuna;
            tipoVacuna.DisplayMember = nameof(TipoVacunaDTO.NombreTipoVacuna);
            tipoVacuna.ValueMember = nameof(TipoVacunaDTO.IdTipoVacuna);

            if (_idMascotaActual > 0)
            {
                this.Text = "Editar Mascota";
                labelTit.Text = "Editar Mascota";
                try
                {
                    var mascota = await MascotaClient.GetAsync(_idMascotaActual);
                    if (mascota != null)
                    {
                        nombreMascota.Text = mascota.NombreMascota;
                        especieMascota.Text = mascota.Especie;
                        razaMascota.Text = mascota.Raza;
                        castradoMascota.Checked = mascota.Castrado;
                        sexoMascota.Text = mascota.Sexo == 'M' ? "Macho" : "Hembra";
                        fechaNacimientoMascota.Value = mascota.FechaNac;
                    }

                    var diccionarioTipos = _tiposVacuna.ToDictionary(t => t.IdTipoVacuna, t => t.NombreTipoVacuna);

                    if (mascota!.Vacunas != null && mascota.Vacunas.Any())
                    {
                        _vacunasPendientes = mascota.Vacunas.ToList();

                        var vacunasParaMostrar = mascota.Vacunas.Select(v => new
                        {
                            Nombre = diccionarioTipos.ContainsKey(v.IdTipoVacuna)
                                ? diccionarioTipos[v.IdTipoVacuna]
                                : "Desconocida",
                            Fecha = v.FechaColocacion.ToString("dd/MM/yyyy")
                        }).ToList();

                        vacunasLista.DataSource = vacunasParaMostrar;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                this.Text = "Nueva Mascota";
                labelTit.Text = "Nueva Mascota";
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (tipoVacuna.SelectedValue == null) return;

            var nuevaVacuna = new VacunaDTO
            {
                IdTipoVacuna = (int)tipoVacuna.SelectedValue,
                FechaColocacion = DateOnly.FromDateTime(fechaVacuna.Value)
            };

            _vacunasPendientes.Add(nuevaVacuna);
            ActualizarGrillaVacunas();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (vacunasLista.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una vacuna de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indiceSeleccionado = vacunasLista.CurrentRow.Index;

            if (indiceSeleccionado >= 0 && indiceSeleccionado < _vacunasPendientes.Count)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de que desea quitar esta vacuna?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    _vacunasPendientes.Remove(_vacunasPendientes.ElementAt(indiceSeleccionado));

                    ActualizarGrillaVacunas();
                }
            }
        }

        private void ActualizarGrillaVacunas()
        {
            if (!_vacunasPendientes.Any())
            {
                vacunasLista.DataSource = null;
                return;
            }

            if (_tiposVacuna == null || !_tiposVacuna.Any())
            {
                MessageBox.Show("Aún no se han cargado los tipos de vacuna desde el servidor.");
                return;
            }

            var diccionarioTipos = _tiposVacuna.ToDictionary(t => t.IdTipoVacuna, t => t.NombreTipoVacuna);

            var vacunasParaMostrar = _vacunasPendientes.Select(v => new
            {
                Vacuna = diccionarioTipos.ContainsKey(v.IdTipoVacuna) ? diccionarioTipos[v.IdTipoVacuna] : "Desconocida",
                Fecha = v.FechaColocacion.ToString("dd/MM/yyyy")
            }).ToList();

            vacunasLista.DataSource = null;
            vacunasLista.DataSource = vacunasParaMostrar;
        }

        private void CargarGrilla()
        {
            vacunasLista.AutoGenerateColumns = true; 
            vacunasLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            vacunasLista.AllowUserToAddRows = false;
            foreach (DataGridViewColumn columna in vacunasLista.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                var authService = Program.AuthService;

                int? personaId = await authService.GetPersonaIdAsync();

                var mascota = new MascotaDTO
                {
                    IdMascota = _idMascotaActual,
                    NombreMascota = nombreMascota.Text,
                    Especie = especieMascota.Text,
                    Raza = razaMascota.Text,
                    Castrado = castradoMascota.Checked,
                    Sexo = sexoMascota.Text == "Macho" ? 'M' : 'H',
                    FechaNac = fechaNacimientoMascota.Value,
                    IdDuenio = personaId ?? 0,
                    Vacunas = _vacunasPendientes
                };

                if (_idMascotaActual == 0)
                {
                    var est = await MascotaClient.AddAsync(mascota);
                    if (est == null)
                    {
                        MessageBox.Show("No se pudo obtener el ID de la mascota creada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    await MascotaClient.UpdateAsync(mascota);
                }

                MessageBox.Show("Mascota guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
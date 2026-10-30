using API.Clients;
using DTOs;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMetricasTurnos : Form
    {
        private readonly TurnoClient TurnoClient;
        private readonly VeterinarioClient VeterinarioClient;
        private readonly IAuthService AuthService;

        private FlowLayoutPanel? panelMetricas;
        private TableLayoutPanel? tablaPrincipal;

        private string rolUsuario = string.Empty;
        private int idPersona = 0;

        public FormMetricasTurnos()
        {
            InitializeComponent();

            AuthService = Program.AuthService;
            TurnoClient = new TurnoClient(AuthService, Program.Configuration);
            VeterinarioClient = new VeterinarioClient(AuthService, Program.Configuration);

            ConstruirLayoutDinamico();

            if (Buscar != null) Buscar.Click += btnBuscar_Click;
            if (Limpiar != null) Limpiar.Click += btnLimpiar_Click;

            this.Load += FormMetricasTurnos_Load;
        }

        private void ConstruirLayoutDinamico()
        {
            panelMetricas = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Padding = new Padding(15),
                WrapContents = false,
                BackColor = Color.White
            };

            tablaPrincipal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(0, 65, 0, 0)
            };
            tablaPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tablaPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));

            TableLayoutPanel tablaGraficos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            tablaGraficos.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablaGraficos.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            if (pieChart1 != null)
            {
                pieChart1.Dock = DockStyle.Fill;
                pieChart1.Margin = new Padding(10);
                tablaGraficos.Controls.Add(pieChart1, 0, 0);
            }

            if (cartesianChart1 != null)
            {
                cartesianChart1.Dock = DockStyle.Fill;
                cartesianChart1.Margin = new Padding(10);
                tablaGraficos.Controls.Add(cartesianChart1, 0, 1);
            }

            tablaPrincipal.Controls.Add(panelMetricas, 0, 0);
            tablaPrincipal.Controls.Add(tablaGraficos, 1, 0);

            this.Controls.Add(tablaPrincipal);
            tablaPrincipal.SendToBack();
        }

        private async void FormMetricasTurnos_Load(object? sender, EventArgs e)
        {
            try
            {
                var rol = await AuthService.GetRolAsync();
                rolUsuario = rol?.Trim().ToUpper() ?? string.Empty;

                if (estadoTurno != null)
                {
                    estadoTurno.Items.Clear();
                    estadoTurno.Items.Add("Todos");
                    estadoTurno.Items.Add("Disponible");
                    estadoTurno.Items.Add("Otorgado");
                    estadoTurno.Items.Add("Resuelto");
                    estadoTurno.SelectedIndex = 0;
                }

                if (fechaDesde != null) fechaDesde.ShowCheckBox = true;
                if (fechaHasta != null) fechaHasta.ShowCheckBox = true;

                if (rolUsuario == "VETERINARIO")
                {
                    var id = await AuthService.GetPersonaIdAsync();
                    idPersona = id ?? 0;

                    if (vetTurno != null)
                    {
                        vetTurno.Visible = false;
                        label1.Visible = false;
                    }
                }
                else if (rolUsuario == "ADMINISTRADOR")
                {
                    var vets = await VeterinarioClient.GetAllAsync();
                    if (vets != null && vetTurno != null)
                    {
                        var listaVets = vets.Select(v => new
                        {
                            IdVeterinario = v.IdVeterinario,
                            NombreCompleto = $"{v.NombreVeterinario} {v.Apellido}"
                        }).ToList();

                        vetTurno.DataSource = listaVets;
                        vetTurno.DisplayMember = "NombreCompleto";
                        vetTurno.ValueMember = "IdVeterinario";
                        vetTurno.SelectedIndex = -1;
                        vetTurno.Text = "Todos los veterinarios";
                    }
                }

                await CargarGraficosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la pantalla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscar_Click(object? sender, EventArgs e)
        {
            await CargarGraficosAsync();
        }

        private async void btnLimpiar_Click(object? sender, EventArgs e)
        {
            if (vetTurno != null && vetTurno.Visible && vetTurno.Items.Count > 0)
            {
                vetTurno.SelectedIndex = -1;
                vetTurno.Text = "Todos los veterinarios";
            }

            if (estadoTurno != null)
            {
                estadoTurno.SelectedIndex = 0;
            }

            if (fechaDesde != null)
            {
                fechaDesde.Checked = false;
            }

            if (fechaHasta != null)
            {
                fechaHasta.Checked = false;
            }

            await CargarGraficosAsync();
        }

        private async Task CargarGraficosAsync()
        {
            try
            {
                int? idVetFiltro = null;
                if (rolUsuario == "VETERINARIO")
                {
                    idVetFiltro = idPersona;
                }
                else if (rolUsuario == "ADMINISTRADOR" && vetTurno?.SelectedItem != null)
                {
                    if (vetTurno.SelectedValue is int selectedId && selectedId > 0)
                    {
                        idVetFiltro = selectedId;
                    }
                }

                string? estadoFiltro = null;
                if (estadoTurno?.SelectedItem != null && estadoTurno.SelectedItem.ToString() != "Todos")
                {
                    estadoFiltro = estadoTurno.SelectedItem.ToString();
                }

                DateOnly? dDesde = (fechaDesde != null && fechaDesde.Checked) ? DateOnly.FromDateTime(fechaDesde.Value) : null;
                DateOnly? dHasta = (fechaHasta != null && fechaHasta.Checked) ? DateOnly.FromDateTime(fechaHasta.Value) : null;

                if (dDesde.HasValue && dHasta.HasValue && dDesde.Value > dHasta.Value)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Validación de Filtros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IEnumerable<TurnoDTO> turnos = await TurnoClient.GetTurnosFiltradosAsync(idVetFiltro, estadoFiltro, dDesde, dHasta) ?? new List<TurnoDTO>();

                int totalTurnos = turnos.Count();
                int turnosOtorgados = turnos.Count(t => t.EstadoTurno != null && t.EstadoTurno.Equals("otorgado", StringComparison.OrdinalIgnoreCase));
                int turnosDisponibles = turnos.Count(t => t.EstadoTurno != null && t.EstadoTurno.Equals("disponible", StringComparison.OrdinalIgnoreCase));
                int turnosResueltos = turnos.Count(t => t.EstadoTurno != null && t.EstadoTurno.Equals("resuelto", StringComparison.OrdinalIgnoreCase));

                if (panelMetricas != null)
                {
                    panelMetricas.Controls.Clear();

                    Label lblTotal = new Label
                    {
                        Text = $"Turnos totales: {totalTurnos}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        Margin = new Padding(0, 5, 0, 15)
                    };

                    Label lblOtorgado = new Label
                    {
                        Text = $"Otorgados: {turnosOtorgados}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10F),
                        Margin = new Padding(0, 0, 0, 10)
                    };

                    Label lblDisponible = new Label
                    {
                        Text = $"Disponibles: {turnosDisponibles}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10F),
                        Margin = new Padding(0, 0, 0, 10)
                    };

                    Label lblResuelto = new Label
                    {
                        Text = $"Resueltos: {turnosResueltos}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10F),
                        Margin = new Padding(0, 0, 0, 10)
                    };

                    panelMetricas.Controls.Add(lblTotal);
                    panelMetricas.Controls.Add(lblOtorgado);
                    panelMetricas.Controls.Add(lblDisponible);
                    panelMetricas.Controls.Add(lblResuelto);
                }

                var turnosAgrupados = turnos
                    .GroupBy(t => t.EstadoTurno ?? "Sin Estado")
                    .Select(grupo => new
                    {
                        Estado = grupo.Key,
                        Cantidad = grupo.Count()
                    })
                    .ToList();

                var pieSeries = new List<ISeries>();
                foreach (var item in turnosAgrupados)
                {
                    pieSeries.Add(new PieSeries<int>
                    {
                        Values = new int[] { item.Cantidad },
                        Name = item.Estado,
                        DataLabelsFormatter = point => $"{point.Context.Series.Name}: {point.Model}",
                        DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle
                    });
                }
                if (pieChart1 != null) pieChart1.Series = pieSeries;

                var etiquetasBarras = turnosAgrupados.Select(x => x.Estado).ToArray();

                if (cartesianChart1 != null)
                {
                    cartesianChart1.Series = new ISeries[]
                    {
                        new ColumnSeries<int>
                        {
                            Values = turnosAgrupados.Select(x => x.Cantidad).ToArray(),
                            Name = "Cantidad de Turnos"
                        }
                    };

                    cartesianChart1.XAxes = new Axis[]
                    {
                        new Axis
                        {
                            Labels = etiquetasBarras,
                            LabelsRotation = 15
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las métricas filtradas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
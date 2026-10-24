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
        private readonly IAuthService AuthService;
        private FlowLayoutPanel panelMetricas;

        private string rolUsuario = string.Empty;
        private int idPersona = 0;

        public FormMetricasTurnos()
        {
            InitializeComponent();

            AuthService = Program.AuthService;
            TurnoClient = new TurnoClient(AuthService);

            ConfigurarPantalla();
            this.Load += FormMetricasTurnos_Load;
        }

        private async void FormMetricasTurnos_Load(object? sender, EventArgs e)
        {
            var rol = await AuthService.GetRolAsync();
            rolUsuario = rol?.Trim().ToUpper() ?? string.Empty;

            if (rolUsuario == "VETERINARIO")
            {
                var id = await AuthService.GetPersonaIdAsync();
                idPersona = id ?? 0;
            }

            await CargarGraficosAsync();
        }

        private void ConfigurarPantalla()
        {
            Label lblTitulo = new Label
            {
                Text = "Proporción de los diferentes estados de turnos",
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                BackColor = Color.Transparent
            };

            Panel panelInferior = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.Transparent
            };

            Button btnRetroceso = new Button
            {
                Text = "Volver",
                Width = 120,
                Height = 40,
                Location = new Point((this.ClientSize.Width - 120) / 2, 10),
                Anchor = AnchorStyles.None
            };
            btnRetroceso.Click += btnRetroceso_Click;
            panelInferior.Controls.Add(btnRetroceso);

            TableLayoutPanel tablaPrincipal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };

            tablaPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tablaPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            panelMetricas = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Padding = new Padding(20, 30, 20, 20),
                WrapContents = false
            };

            TableLayoutPanel tablaGraficos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };

            tablaGraficos.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablaGraficos.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            pieChart1.Dock = DockStyle.Fill;
            pieChart1.Margin = new Padding(15);

            cartesianChart1.Dock = DockStyle.Fill;
            cartesianChart1.Margin = new Padding(15);

            tablaGraficos.Controls.Add(pieChart1, 0, 0);
            tablaGraficos.Controls.Add(cartesianChart1, 0, 1);

            tablaPrincipal.Controls.Add(panelMetricas, 0, 0);
            tablaPrincipal.Controls.Add(tablaGraficos, 1, 0);

            this.Controls.Add(tablaPrincipal);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(panelInferior);

            tablaPrincipal.BringToFront();
        }

        private void btnRetroceso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task CargarGraficosAsync()
        {
            try
            {
                IEnumerable<TurnoDTO> turnos;

                if (rolUsuario == "VETERINARIO")
                {
                    turnos = await TurnoClient.GetByVeterinarioIdAsync(idPersona);
                }
                else
                {
                    turnos = await TurnoClient.GetAllAsync();
                }

                int totalTurnos = turnos.Count();

                int turnosOtorgados = turnos.Count(t => t.EstadoTurno != null && t.EstadoTurno.ToLower() == "otorgado");
                int turnosDisponibles = turnos.Count(t => t.EstadoTurno != null && t.EstadoTurno.ToLower() == "disponible");
                int turnosResueltos = turnos.Count(t => t.EstadoTurno != null && t.EstadoTurno.ToLower() == "resuelto");

                panelMetricas.Controls.Clear();

                Label lblTotal = new Label
                {
                    Text = $"Turnos totales: {totalTurnos}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Margin = new Padding(0, 0, 0, 20)
                };

                Label lblOtorgado = new Label
                {
                    Text = $"Turnos en estado Otorgado: {turnosOtorgados}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F),
                    Margin = new Padding(0, 0, 0, 10)
                };

                Label lblPendiente = new Label
                {
                    Text = $"Turnos en estado Disponible: {turnosDisponibles}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F),
                    Margin = new Padding(0, 0, 0, 10)
                };

                Label lblResuelto = new Label
                {
                    Text = $"Turnos en estado Resuelto: {turnosResueltos}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11F),
                    Margin = new Padding(0, 0, 0, 10)
                };

                panelMetricas.Controls.Add(lblTotal);
                panelMetricas.Controls.Add(lblOtorgado);
                panelMetricas.Controls.Add(lblPendiente);
                panelMetricas.Controls.Add(lblResuelto);

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
                pieChart1.Series = pieSeries;

                var valoresBarras = turnosAgrupados.Select(x => x.Cantidad).ToArray();
                var etiquetasBarras = turnosAgrupados.Select(x => x.Estado).ToArray();

                cartesianChart1.Series = new ISeries[]
                {
                    new ColumnSeries<int>
                    {
                        Values = valoresBarras,
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las métricas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
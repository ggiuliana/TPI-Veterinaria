using API.Clients;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMetricasTurnos : Form
    {
        private readonly TurnoClient TurnoClient;
        public FormMetricasTurnos()
        {
            InitializeComponent();
            IAuthService authService = Program.AuthService;
            TurnoClient = new TurnoClient(authService);
            ConfigurarPantalla();
            this.Load += FormMetricasTurnos_Load;
        }

        private async void FormMetricasTurnos_Load(object? sender, EventArgs e)
        {
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

            TableLayoutPanel tablaGraficos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            tablaGraficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablaGraficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            pieChart1.Dock = DockStyle.Fill;
            pieChart1.Margin = new Padding(15);

            cartesianChart1.Dock = DockStyle.Fill;
            cartesianChart1.Margin = new Padding(15);

            tablaGraficos.Controls.Add(pieChart1, 0, 0);
            tablaGraficos.Controls.Add(cartesianChart1, 1, 0);

            this.Controls.Add(lblTitulo);    
            this.Controls.Add(panelInferior);  
            this.Controls.Add(tablaGraficos); 

            tablaGraficos.BringToFront();
        }
        private void btnRetroceso_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task CargarGraficosAsync()
        {
            try
            {
                var turnos = await TurnoClient.GetAllAsync();
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

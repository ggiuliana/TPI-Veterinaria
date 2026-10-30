using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WinFormsApp1
{
    public partial class FormReporteStock : Form
    {
        private readonly MedicamentoClient MedicamentoClient;

        public FormReporteStock()
        {
            InitializeComponent();

            IAuthService authService = Program.AuthService;
            MedicamentoClient = new MedicamentoClient(authService, Program.Configuration);

            ConfigurarColumnas(dataGridView1);
            ConfigurarColumnas(dataGridView2);
            ConfigurarColumnas(dataGridView3);

            this.Load += FormStockMedicamento_Load;
        }

        private void ConfigurarColumnas(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreMedicamento",
                HeaderText = "Nombre del medicamento",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadRestante",
                HeaderText = "Cantidad restante",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private async void FormStockMedicamento_Load(object? sender, EventArgs e)
        {
            await CargarStockAsync();
        }

        private async Task CargarStockAsync()
        {
            try
            {
                var reporte = await MedicamentoClient.GetReporteStockAsync();

                if (reporte != null)
                {
                    var sinStock = reporte.Agotados ?? new List<MedicamentoDTO>();
                    var pocoStock = reporte.StockBajo ?? new List<MedicamentoDTO>();
                    var enStock = reporte.StockSuficiente ?? new List<MedicamentoDTO>();

                    dataGridView1.DataSource = sinStock;
                    dataGridView2.DataSource = pocoStock;
                    dataGridView3.DataSource = enStock;

                    label2.Text = $"Sin stock, reposición inmediata: ({sinStock.Count})";
                    label3.Text = $"Bajo stock, pronta reposición: ({pocoStock.Count})";
                    label4.Text = $"En stock: ({enStock.Count})";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Acceso denegado: {ex.Message}", "Permisos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
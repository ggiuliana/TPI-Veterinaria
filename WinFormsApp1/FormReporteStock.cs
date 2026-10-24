using System;
using System.Linq;
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
            MedicamentoClient = new MedicamentoClient(authService);

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
                var medicamentos = await MedicamentoClient.GetAllAsync();

                if (medicamentos != null && medicamentos.Any())
                {
                    var sinStock = medicamentos.Where(m => m.CantidadRestante == 0).ToList();
                    var pocoStock = medicamentos.Where(m => m.CantidadRestante > 0 && m.CantidadRestante <= 5).ToList();
                    var enStock = medicamentos.Where(m => m.CantidadRestante > 5).ToList();

                    int totalSinStock = sinStock.Count;
                    int totalPocoStock = pocoStock.Count;
                    int totalEnStock = enStock.Count;

                    dataGridView1.DataSource = sinStock;
                    dataGridView2.DataSource = pocoStock;
                    dataGridView3.DataSource = enStock;

                    label2.Text = $"Sin stock, reposición inmediata: ({totalSinStock})";
                    label3.Text = $"Bajo stock, pronta reposición: ({totalPocoStock})";
                    label4.Text = $"En stock: ({totalEnStock})";
                }
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
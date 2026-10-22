using API.Clients;
using DTOs;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormTipoVacunaDetalle : Form
    {
        private readonly int _idTipoVacunaActual;
        private readonly TipoVacunaClient TipoVacunaClient;

        public FormTipoVacunaDetalle(int idTipoVacuna = 0)
        {
            InitializeComponent();
            _idTipoVacunaActual = idTipoVacuna;
            this.Load += FormTipoVacunaDetalle_Load;
            IAuthService authService = Program.AuthService;
            TipoVacunaClient = new TipoVacunaClient(authService);
        }

        private async void FormTipoVacunaDetalle_Load(object? sender, EventArgs e)
        {
            if (_idTipoVacunaActual > 0)
            {
                lblTitulo.Text = "EDITAR VACUNA";
                var vac = await TipoVacunaClient.GetAsync(_idTipoVacunaActual);
                if (vac != null)
                {
                    nombreTipoVacuna.Text = vac.NombreTipoVacuna;
                    descripcionTipoVacuna.Text = vac.DescripcionTipoVacuna;
                }
            }
            else
            {
                lblTitulo.Text = "NUEVA VACUNA";
            }
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {
            var dto = new TipoVacunaDTO
            {
                IdTipoVacuna = _idTipoVacunaActual,
                NombreTipoVacuna = nombreTipoVacuna.Text,
                DescripcionTipoVacuna = descripcionTipoVacuna.Text
            };

            if (_idTipoVacunaActual == 0) await TipoVacunaClient.AddAsync(dto);
            else await TipoVacunaClient.UpdateAsync(dto);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
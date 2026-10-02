namespace WinFormsApp1
{
    partial class FormTurnoDetalle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();
            txtIdMascota = new TextBox();
            txtIdVeterinario = new TextBox();
            lblMascota = new Label();
            lblVeterinario = new Label();
            lblHora = new Label();
            lblFecha = new Label();
            lblTitulo = new Label();
            Cancelar = new Button();
            Guardar = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(121, 63);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(228, 23);
            dtpFecha.TabIndex = 18;
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.ShowUpDown = true;
            dtpHora.Location = new Point(121, 98);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(228, 23);
            dtpHora.TabIndex = 19;
            // 
            // txtIdMascota
            // 
            txtIdMascota.Location = new Point(121, 133);
            txtIdMascota.Name = "txtIdMascota";
            txtIdMascota.Size = new Size(228, 23);
            txtIdMascota.TabIndex = 20;
            // 
            // txtIdVeterinario
            // 
            txtIdVeterinario.Location = new Point(121, 168);
            txtIdVeterinario.Name = "txtIdVeterinario";
            txtIdVeterinario.Size = new Size(228, 23);
            txtIdVeterinario.TabIndex = 21;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(40, 66);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 15;
            lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(40, 101);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(36, 15);
            lblHora.TabIndex = 16;
            lblHora.Text = "Hora:";
            // 
            // lblMascota
            // 
            lblMascota.AutoSize = true;
            lblMascota.Location = new Point(40, 136);
            lblMascota.Name = "lblMascota";
            lblMascota.Size = new Size(69, 15);
            lblMascota.TabIndex = 17;
            lblMascota.Text = "ID Mascota:";
            // 
            // lblVeterinario
            // 
            lblVeterinario.AutoSize = true;
            lblVeterinario.Location = new Point(40, 171);
            lblVeterinario.Name = "lblVeterinario";
            lblVeterinario.Size = new Size(79, 15);
            lblVeterinario.TabIndex = 22;
            lblVeterinario.Text = "ID Veterinario:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(104, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 30);
            lblTitulo.TabIndex = 14;
            lblTitulo.Text = "Turno";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ControlLight;
            Cancelar.Cursor = Cursors.Hand;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(57, 220);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(123, 39);
            Cancelar.TabIndex = 40;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // Guardar
            // 
            Guardar.BackColor = SystemColors.ActiveCaption;
            Guardar.Cursor = Cursors.Hand;
            Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Guardar.ForeColor = SystemColors.ControlText;
            Guardar.Location = new Point(209, 220);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(123, 39);
            Guardar.TabIndex = 39;
            Guardar.Text = "Guardar";
            Guardar.UseVisualStyleBackColor = false;
            Guardar.Click += Guardar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(Guardar);
            panel1.Controls.Add(Cancelar);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(lblFecha);
            panel1.Controls.Add(dtpFecha);
            panel1.Controls.Add(lblHora);
            panel1.Controls.Add(dtpHora);
            panel1.Controls.Add(lblMascota);
            panel1.Controls.Add(txtIdMascota);
            panel1.Controls.Add(lblVeterinario);
            panel1.Controls.Add(txtIdVeterinario);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 280);
            panel1.TabIndex = 41;
            // 
            // FormTurnoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 310);
            Controls.Add(panel1);
            Name = "FormTurnoDetalle";
            Text = "Detalle Turno";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFecha;
        private Label lblHora;
        private Label lblMascota;
        private Label lblVeterinario;
        private Label lblTitulo;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private TextBox txtIdMascota;
        private TextBox txtIdVeterinario;
        private Button Cancelar;
        private Button Guardar;
        private Panel panel1;
    }
}
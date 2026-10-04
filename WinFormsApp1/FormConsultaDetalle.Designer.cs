namespace WinFormsApp1
{
    partial class FormConsultaDetalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGuardar = new Button();
            Cancelar = new Button();
            lblDiagnostico = new Label();
            txtDiagnostico = new TextBox();
            lblTratamiento = new Label();
            txtTratamiento = new TextBox();
            numPeso = new NumericUpDown();
            lblPeso = new Label();
            txtObservaciones = new TextBox();
            lblObservaciones = new Label();
            cmbMedicamentos = new ComboBox();
            lblMedicamento = new Label();
            lblCantMedicamento = new Label();
            numCantidadMedicamento = new NumericUpDown();
            dgvMedicamentos = new DataGridView();
            colIdMedicamento = new DataGridViewTextBoxColumn();
            colNombreMedicamento = new DataGridViewTextBoxColumn();
            colCantidadUsada = new DataGridViewTextBoxColumn();
            btnAgregarMedicamento = new Button();
            btnQuitarMedicamento = new Button();
            ((System.ComponentModel.ISupportInitialize)numPeso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadMedicamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ControlText;
            btnGuardar.Location = new Point(400, 460);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(123, 39);
            btnGuardar.TabIndex = 39;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ControlLight;
            Cancelar.Cursor = Cursors.Hand;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(237, 460);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(123, 39);
            Cancelar.TabIndex = 40;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Location = new Point(198, 39);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(73, 15);
            lblDiagnostico.TabIndex = 16;
            lblDiagnostico.Text = "Diagnóstico:";
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Location = new Point(300, 37);
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.Size = new Size(228, 21);
            txtDiagnostico.TabIndex = 19;
            // 
            // lblTratamiento
            // 
            lblTratamiento.AutoSize = true;
            lblTratamiento.Location = new Point(198, 73);
            lblTratamiento.Name = "lblTratamiento";
            lblTratamiento.Size = new Size(73, 15);
            lblTratamiento.TabIndex = 15;
            lblTratamiento.Text = "Tratamiento:";
            // 
            // txtTratamiento
            // 
            txtTratamiento.Location = new Point(300, 71);
            txtTratamiento.Multiline = true;
            txtTratamiento.Name = "txtTratamiento";
            txtTratamiento.Size = new Size(228, 21);
            txtTratamiento.TabIndex = 41;
            // 
            // numPeso
            // 
            numPeso.DecimalPlaces = 2;
            numPeso.Location = new Point(302, 104);
            numPeso.Margin = new Padding(3, 2, 3, 2);
            numPeso.Name = "numPeso";
            numPeso.Size = new Size(73, 23);
            numPeso.TabIndex = 42;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(216, 107);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(35, 15);
            lblPeso.TabIndex = 43;
            lblPeso.Text = "Peso:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(302, 138);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(228, 21);
            txtObservaciones.TabIndex = 44;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(198, 140);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 45;
            lblObservaciones.Text = "Observaciones:";
            // 
            // cmbMedicamentos
            // 
            cmbMedicamentos.FormattingEnabled = true;
            cmbMedicamentos.Location = new Point(152, 246);
            cmbMedicamentos.Margin = new Padding(3, 2, 3, 2);
            cmbMedicamentos.Name = "cmbMedicamentos";
            cmbMedicamentos.Size = new Size(133, 23);
            cmbMedicamentos.TabIndex = 46;
            // 
            // lblMedicamento
            // 
            lblMedicamento.AutoSize = true;
            lblMedicamento.Location = new Point(45, 249);
            lblMedicamento.Name = "lblMedicamento";
            lblMedicamento.Size = new Size(84, 15);
            lblMedicamento.TabIndex = 47;
            lblMedicamento.Text = "Medicamento:";
            // 
            // lblCantMedicamento
            // 
            lblCantMedicamento.AutoSize = true;
            lblCantMedicamento.Location = new Point(61, 292);
            lblCantMedicamento.Name = "lblCantMedicamento";
            lblCantMedicamento.Size = new Size(58, 15);
            lblCantMedicamento.TabIndex = 49;
            lblCantMedicamento.Text = "Cantidad:";
            // 
            // numCantidadMedicamento
            // 
            numCantidadMedicamento.Location = new Point(152, 291);
            numCantidadMedicamento.Margin = new Padding(3, 2, 3, 2);
            numCantidadMedicamento.Name = "numCantidadMedicamento";
            numCantidadMedicamento.Size = new Size(53, 23);
            numCantidadMedicamento.TabIndex = 48;
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Columns.AddRange(new DataGridViewColumn[] { colIdMedicamento, colNombreMedicamento, colCantidadUsada });
            dgvMedicamentos.Location = new Point(302, 203);
            dgvMedicamentos.Margin = new Padding(3, 2, 3, 2);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowHeadersWidth = 51;
            dgvMedicamentos.Size = new Size(421, 156);
            dgvMedicamentos.TabIndex = 50;
            // 
            // colIdMedicamento
            // 
            colIdMedicamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdMedicamento.DataPropertyName = "IdMedicamento";
            colIdMedicamento.HeaderText = "ID";
            colIdMedicamento.MinimumWidth = 6;
            colIdMedicamento.Name = "colIdMedicamento";
            colIdMedicamento.ReadOnly = true;
            colIdMedicamento.Width = 43;
            // 
            // colNombreMedicamento
            // 
            colNombreMedicamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombreMedicamento.DataPropertyName = "NombreMedicamento";
            colNombreMedicamento.HeaderText = "Nombre";
            colNombreMedicamento.MinimumWidth = 6;
            colNombreMedicamento.Name = "colNombreMedicamento";
            colNombreMedicamento.ReadOnly = true;
            // 
            // colCantidadUsada
            // 
            colCantidadUsada.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCantidadUsada.DataPropertyName = "CantidadUsada";
            colCantidadUsada.HeaderText = "Cantidad Usada";
            colCantidadUsada.MinimumWidth = 6;
            colCantidadUsada.Name = "colCantidadUsada";
            colCantidadUsada.ReadOnly = true;
            colCantidadUsada.Width = 106;
            // 
            // btnAgregarMedicamento
            // 
            btnAgregarMedicamento.Location = new Point(45, 375);
            btnAgregarMedicamento.Margin = new Padding(3, 2, 3, 2);
            btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            btnAgregarMedicamento.Size = new Size(154, 22);
            btnAgregarMedicamento.TabIndex = 51;
            btnAgregarMedicamento.Text = "Agregar medicamento";
            btnAgregarMedicamento.UseVisualStyleBackColor = true;
            btnAgregarMedicamento.Click += btnAgregarMedicamento_Click;
            // 
            // btnQuitarMedicamento
            // 
            btnQuitarMedicamento.Location = new Point(569, 375);
            btnQuitarMedicamento.Margin = new Padding(3, 2, 3, 2);
            btnQuitarMedicamento.Name = "btnQuitarMedicamento";
            btnQuitarMedicamento.Size = new Size(154, 22);
            btnQuitarMedicamento.TabIndex = 52;
            btnQuitarMedicamento.Text = "Quitar medicamento";
            btnQuitarMedicamento.UseVisualStyleBackColor = true;
            btnQuitarMedicamento.Click += btnQuitarMedicamento_Click;
            // 
            // FormConsultaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 529);
            Controls.Add(btnQuitarMedicamento);
            Controls.Add(btnAgregarMedicamento);
            Controls.Add(dgvMedicamentos);
            Controls.Add(lblCantMedicamento);
            Controls.Add(numCantidadMedicamento);
            Controls.Add(lblMedicamento);
            Controls.Add(cmbMedicamentos);
            Controls.Add(lblObservaciones);
            Controls.Add(txtObservaciones);
            Controls.Add(lblPeso);
            Controls.Add(numPeso);
            Controls.Add(txtTratamiento);
            Controls.Add(Cancelar);
            Controls.Add(lblDiagnostico);
            Controls.Add(txtDiagnostico);
            Controls.Add(lblTratamiento);
            Controls.Add(btnGuardar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormConsultaDetalle";
            Text = "FormConsultaDetalle";
            ((System.ComponentModel.ISupportInitialize)numPeso).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadMedicamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Button Cancelar;
        private Label lblDiagnostico;
        private TextBox txtDiagnostico;
        private Label lblTratamiento;
        private TextBox txtTratamiento;
        private NumericUpDown numPeso;
        private Label lblPeso;
        private TextBox txtObservaciones;
        private Label lblObservaciones;
        private ComboBox cmbMedicamentos;
        private Label lblMedicamento;
        private Label lblCantMedicamento;
        private NumericUpDown numCantidadMedicamento;
        private DataGridView dgvMedicamentos;
        private DataGridViewTextBoxColumn colIdMedicamento;
        private DataGridViewTextBoxColumn colNombreMedicamento;
        private DataGridViewTextBoxColumn colCantidadUsada;
        private Button btnAgregarMedicamento;
        private Button btnQuitarMedicamento;
    }
}
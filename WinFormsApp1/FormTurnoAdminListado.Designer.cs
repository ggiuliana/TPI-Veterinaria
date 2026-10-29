namespace WinFormsApp1
{
    partial class FormTurnoAdminListado
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
            Metricas = new Button();
            label1 = new Label();
            Create = new Button();
            Modificar = new Button();
            Delete = new Button();
            Buscar = new Button();
            dataGridView1 = new DataGridView();
            colIdTurno = new DataGridViewTextBoxColumn();
            colFechaTurno = new DataGridViewTextBoxColumn();
            colHoraTurno = new DataGridViewTextBoxColumn();
            colMascota = new DataGridViewTextBoxColumn();
            colVeterinario = new DataGridViewTextBoxColumn();
            colEstadoTurno = new DataGridViewTextBoxColumn();
            colObservaciones = new DataGridViewTextBoxColumn();
            colConsulta = new DataGridViewButtonColumn();
            estadoTurno = new ComboBox();
            vetTurno = new ComboBox();
            fechaDesde = new DateTimePicker();
            fechaHasta = new DateTimePicker();
            Limpiar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Metricas
            // 
            Metricas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Metricas.BackColor = SystemColors.ActiveCaption;
            Metricas.Cursor = Cursors.Hand;
            Metricas.Location = new Point(315, 398);
            Metricas.Name = "Metricas";
            Metricas.Size = new Size(154, 23);
            Metricas.TabIndex = 49;
            Metricas.Text = "Ver métricas";
            Metricas.UseVisualStyleBackColor = false;
            Metricas.Click += Metricas_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(668, 30);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 42;
            label1.Text = "TURNOS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Create
            // 
            Create.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Create.Cursor = Cursors.Hand;
            Create.Location = new Point(705, 398);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 48;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Modificar
            // 
            Modificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Modificar.Cursor = Cursors.Hand;
            Modificar.Location = new Point(616, 398);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(75, 23);
            Modificar.TabIndex = 47;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Delete.Cursor = Cursors.Hand;
            Delete.Location = new Point(20, 398);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 46;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Cursor = Cursors.Hand;
            Buscar.Location = new Point(573, 31);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 45;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colIdTurno, colFechaTurno, colHoraTurno, colMascota, colVeterinario, colEstadoTurno, colObservaciones, colConsulta });
            dataGridView1.Location = new Point(21, 76);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 316);
            dataGridView1.TabIndex = 41;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colIdTurno
            // 
            colIdTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdTurno.DataPropertyName = "IdTurno";
            colIdTurno.HeaderText = "ID";
            colIdTurno.MinimumWidth = 6;
            colIdTurno.Name = "colIdTurno";
            colIdTurno.ReadOnly = true;
            colIdTurno.Width = 43;
            // 
            // colFechaTurno
            // 
            colFechaTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colFechaTurno.DataPropertyName = "FechaTurno";
            colFechaTurno.HeaderText = "Fecha";
            colFechaTurno.MinimumWidth = 6;
            colFechaTurno.Name = "colFechaTurno";
            colFechaTurno.ReadOnly = true;
            colFechaTurno.Width = 63;
            // 
            // colHoraTurno
            // 
            colHoraTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colHoraTurno.DataPropertyName = "HoraTurno";
            colHoraTurno.HeaderText = "Hora";
            colHoraTurno.MinimumWidth = 6;
            colHoraTurno.Name = "colHoraTurno";
            colHoraTurno.ReadOnly = true;
            colHoraTurno.Width = 58;
            // 
            // colMascota
            // 
            colMascota.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colMascota.DataPropertyName = "NombreMascota";
            colMascota.HeaderText = "Mascota";
            colMascota.MinimumWidth = 6;
            colMascota.Name = "colMascota";
            colMascota.ReadOnly = true;
            colMascota.Width = 77;
            // 
            // colVeterinario
            // 
            colVeterinario.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colVeterinario.DataPropertyName = "NombreCompletoVeterinario";
            colVeterinario.HeaderText = "Veterinario";
            colVeterinario.MinimumWidth = 6;
            colVeterinario.Name = "colVeterinario";
            colVeterinario.ReadOnly = true;
            colVeterinario.Width = 88;
            // 
            // colEstadoTurno
            // 
            colEstadoTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colEstadoTurno.DataPropertyName = "EstadoTurno";
            colEstadoTurno.HeaderText = "Estado";
            colEstadoTurno.MinimumWidth = 6;
            colEstadoTurno.Name = "colEstadoTurno";
            colEstadoTurno.ReadOnly = true;
            colEstadoTurno.Width = 67;
            // 
            // colObservaciones
            // 
            colObservaciones.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colObservaciones.DataPropertyName = "Observaciones";
            colObservaciones.HeaderText = "Observaciones";
            colObservaciones.MinimumWidth = 6;
            colObservaciones.Name = "colObservaciones";
            colObservaciones.ReadOnly = true;
            // 
            // colConsulta
            // 
            colConsulta.HeaderText = "Consulta";
            colConsulta.MinimumWidth = 6;
            colConsulta.Name = "colConsulta";
            colConsulta.ReadOnly = true;
            colConsulta.Text = "+";
            colConsulta.UseColumnTextForButtonValue = true;
            // 
            // estadoTurno
            // 
            estadoTurno.FormattingEnabled = true;
            estadoTurno.Location = new Point(21, 31);
            estadoTurno.Name = "estadoTurno";
            estadoTurno.Size = new Size(121, 23);
            estadoTurno.TabIndex = 50;
            // 
            // vetTurno
            // 
            vetTurno.FormattingEnabled = true;
            vetTurno.Location = new Point(148, 31);
            vetTurno.Name = "vetTurno";
            vetTurno.Size = new Size(121, 23);
            vetTurno.TabIndex = 51;
            // 
            // fechaDesde
            // 
            fechaDesde.Format = DateTimePickerFormat.Short;
            fechaDesde.Location = new Point(275, 31);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(102, 23);
            fechaDesde.TabIndex = 52;
            // 
            // fechaHasta
            // 
            fechaHasta.Format = DateTimePickerFormat.Short;
            fechaHasta.Location = new Point(383, 31);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(103, 23);
            fechaHasta.TabIndex = 53;
            // 
            // Limpiar
            // 
            Limpiar.BackColor = SystemColors.ActiveCaption;
            Limpiar.Location = new Point(492, 31);
            Limpiar.Name = "Limpiar";
            Limpiar.Size = new Size(75, 23);
            Limpiar.TabIndex = 54;
            Limpiar.Text = "Limpiar";
            Limpiar.UseVisualStyleBackColor = false;
            Limpiar.Click += Limpiar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 13);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 55;
            label2.Text = "Estado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 13);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 56;
            label3.Text = "Veterinario:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 13);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 57;
            label4.Text = "Fecha desde:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 13);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 58;
            label5.Text = "Fecha hasta:";
            // 
            // FormTurnoAdminListado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Limpiar);
            Controls.Add(fechaHasta);
            Controls.Add(fechaDesde);
            Controls.Add(vetTurno);
            Controls.Add(estadoTurno);
            Controls.Add(Metricas);
            Controls.Add(label1);
            Controls.Add(Create);
            Controls.Add(Modificar);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(dataGridView1);
            Name = "FormTurnoAdminListado";
            Text = "Turnos Admin";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Metricas;
        private Label label1;
        private Button Create;
        private Button Modificar;
        private Button Delete;
        private Button Buscar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colIdTurno;
        private DataGridViewTextBoxColumn colFechaTurno;
        private DataGridViewTextBoxColumn colHoraTurno;
        private DataGridViewTextBoxColumn colMascota;
        private DataGridViewTextBoxColumn colVeterinario;
        private DataGridViewTextBoxColumn colEstadoTurno;
        private DataGridViewTextBoxColumn colObservaciones;
        private DataGridViewButtonColumn colConsulta;
        private ComboBox estadoTurno;
        private ComboBox vetTurno;
        private DateTimePicker fechaDesde;
        private DateTimePicker fechaHasta;
        private Button Limpiar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
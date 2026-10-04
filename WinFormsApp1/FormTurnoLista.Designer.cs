namespace WinFormsApp1
{
    partial class FormTurnoLista
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
            label1 = new Label();
            Create = new Button();
            Modificar = new Button();
            Delete = new Button();
            Buscar = new Button();
            idTurnoBuscar = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            colIdTurno = new DataGridViewTextBoxColumn();
            colFechaTurno = new DataGridViewTextBoxColumn();
            colHoraTurno = new DataGridViewTextBoxColumn();
            colIdMascota = new DataGridViewTextBoxColumn();
            colIdVeterinario = new DataGridViewTextBoxColumn();
            colEstadoTurno = new DataGridViewTextBoxColumn();
            colObservaciones = new DataGridViewTextBoxColumn();
            colConsulta = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(771, 21);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 33;
            label1.Text = "TURNOS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Create
            // 
            Create.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Create.Cursor = Cursors.Hand;
            Create.Location = new Point(814, 512);
            Create.Margin = new Padding(3, 4, 3, 4);
            Create.Name = "Create";
            Create.Size = new Size(86, 31);
            Create.TabIndex = 39;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Modificar
            // 
            Modificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Modificar.Cursor = Cursors.Hand;
            Modificar.Location = new Point(712, 512);
            Modificar.Margin = new Padding(3, 4, 3, 4);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(86, 31);
            Modificar.TabIndex = 38;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Delete.Cursor = Cursors.Hand;
            Delete.Location = new Point(31, 512);
            Delete.Margin = new Padding(3, 4, 3, 4);
            Delete.Name = "Delete";
            Delete.Size = new Size(86, 31);
            Delete.TabIndex = 37;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Cursor = Cursors.Hand;
            Buscar.Location = new Point(145, 44);
            Buscar.Margin = new Padding(3, 4, 3, 4);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(86, 31);
            Buscar.TabIndex = 36;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // idTurnoBuscar
            // 
            idTurnoBuscar.Location = new Point(61, 44);
            idTurnoBuscar.Margin = new Padding(3, 4, 3, 4);
            idTurnoBuscar.Name = "idTurnoBuscar";
            idTurnoBuscar.Size = new Size(77, 27);
            idTurnoBuscar.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 47);
            label2.Name = "label2";
            label2.Size = new Size(25, 23);
            label2.TabIndex = 34;
            label2.Text = "Id";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colIdTurno, colFechaTurno, colHoraTurno, colIdMascota, colIdVeterinario, colEstadoTurno, colObservaciones, colConsulta });
            dataGridView1.Location = new Point(32, 83);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(869, 421);
            dataGridView1.TabIndex = 32;
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
            colIdTurno.Width = 53;
            // 
            // colFechaTurno
            // 
            colFechaTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colFechaTurno.DataPropertyName = "FechaTurno";
            colFechaTurno.HeaderText = "Fecha";
            colFechaTurno.MinimumWidth = 6;
            colFechaTurno.Name = "colFechaTurno";
            colFechaTurno.ReadOnly = true;
            colFechaTurno.Width = 76;
            // 
            // colHoraTurno
            // 
            colHoraTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colHoraTurno.DataPropertyName = "HoraTurno";
            colHoraTurno.HeaderText = "Hora";
            colHoraTurno.MinimumWidth = 6;
            colHoraTurno.Name = "colHoraTurno";
            colHoraTurno.ReadOnly = true;
            colHoraTurno.Width = 71;
            // 
            // colIdMascota
            // 
            colIdMascota.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdMascota.DataPropertyName = "IdMascota";
            colIdMascota.HeaderText = "ID Mascota";
            colIdMascota.MinimumWidth = 6;
            colIdMascota.Name = "colIdMascota";
            colIdMascota.ReadOnly = true;
            colIdMascota.Width = 104;
            // 
            // colIdVeterinario
            // 
            colIdVeterinario.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdVeterinario.DataPropertyName = "IdVeterinario";
            colIdVeterinario.HeaderText = "ID Veterinario";
            colIdVeterinario.MinimumWidth = 6;
            colIdVeterinario.Name = "colIdVeterinario";
            colIdVeterinario.ReadOnly = true;
            colIdVeterinario.Width = 119;
            // 
            // colEstadoTurno
            // 
            colEstadoTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colEstadoTurno.DataPropertyName = "EstadoTurno";
            colEstadoTurno.HeaderText = "Estado";
            colEstadoTurno.MinimumWidth = 6;
            colEstadoTurno.Name = "colEstadoTurno";
            colEstadoTurno.ReadOnly = true;
            colEstadoTurno.Width = 83;
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
            // FormTurnoLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 572);
            Controls.Add(label1);
            Controls.Add(Create);
            Controls.Add(Modificar);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idTurnoBuscar);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Name = "FormTurnoLista";
            Text = "FormTurnosCRUD";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Create;
        private Button Modificar;
        private Button Delete;
        private Button Buscar;
        private TextBox idTurnoBuscar;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colIdTurno;
        private DataGridViewTextBoxColumn colFechaTurno;
        private DataGridViewTextBoxColumn colHoraTurno;
        private DataGridViewTextBoxColumn colIdMascota;
        private DataGridViewTextBoxColumn colIdVeterinario;
        private DataGridViewTextBoxColumn colEstadoTurno;
        private DataGridViewTextBoxColumn colObservaciones;
        private DataGridViewButtonColumn colConsulta;
    }
}
namespace WinFormsApp1
{
    partial class FormTurnosDisponibles
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
            SacarTurno = new Button();
            dataGridView1 = new DataGridView();
            colIdTurno = new DataGridViewTextBoxColumn();
            colFechaTurno = new DataGridViewTextBoxColumn();
            colHoraTurno = new DataGridViewTextBoxColumn();
            colIdVeterinario = new DataGridViewTextBoxColumn();
            colEstadoTurno = new DataGridViewTextBoxColumn();
            colObservaciones = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(616, 34);
            label1.Name = "label1";
            label1.Size = new Size(159, 20);
            label1.TabIndex = 41;
            label1.Text = "TURNOS DISPONIBLES";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SacarTurno
            // 
            SacarTurno.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SacarTurno.Cursor = Cursors.Hand;
            SacarTurno.Location = new Point(705, 398);
            SacarTurno.Name = "SacarTurno";
            SacarTurno.Size = new Size(75, 23);
            SacarTurno.TabIndex = 47;
            SacarTurno.Text = "Sacar turno";
            SacarTurno.UseVisualStyleBackColor = true;
            SacarTurno.Click += SacarTurno_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colIdTurno, colFechaTurno, colHoraTurno, colIdVeterinario, colEstadoTurno, colObservaciones });
            dataGridView1.Location = new Point(21, 76);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 316);
            dataGridView1.TabIndex = 40;
            // 
            // idTurno
            // 
            colIdTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdTurno.DataPropertyName = "IdTurno";
            colIdTurno.HeaderText = "ID";
            colIdTurno.MinimumWidth = 6;
            colIdTurno.Name = "colIdTurno";
            colIdTurno.ReadOnly = true;
            colIdTurno.Width = 63;
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
            // colIdVeterinario
            // 
            colIdVeterinario.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdVeterinario.DataPropertyName = "IdVeterinario";
            colIdVeterinario.HeaderText = "ID Veterinario";
            colIdVeterinario.MinimumWidth = 6;
            colIdVeterinario.Name = "colIdVeterinario";
            colIdVeterinario.ReadOnly = true;
            colIdVeterinario.Width = 102;
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
            // FormTurnosDisponibles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(SacarTurno);
            Controls.Add(dataGridView1);
            Name = "FormTurnosDisponibles";
            Text = "Form1";
            Load += FormTurnosDisponibles_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button SacarTurno;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colIdTurno;
        private DataGridViewTextBoxColumn colFechaTurno;
        private DataGridViewTextBoxColumn colHoraTurno;
        private DataGridViewTextBoxColumn colIdVeterinario;
        private DataGridViewTextBoxColumn colEstadoTurno;
        private DataGridViewTextBoxColumn colObservaciones;
    }
}
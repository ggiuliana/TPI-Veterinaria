namespace WinFormsApp1
{
    partial class FormConsultaLista
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
            btnModificar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscarId = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            colIdConsulta = new DataGridViewTextBoxColumn();
            colIdTurno = new DataGridViewTextBoxColumn();
            colDiagnostico = new DataGridViewTextBoxColumn();
            colTratamiento = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(869, 69);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 41;
            label1.Text = "CONSULTAS";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnModificar.Cursor = Cursors.Hand;
            btnModificar.Location = new Point(913, 560);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(86, 31);
            btnModificar.TabIndex = 46;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Location = new Point(129, 560);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 45;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Location = new Point(243, 92);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(86, 31);
            btnBuscar.TabIndex = 44;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarId
            // 
            txtBuscarId.Location = new Point(159, 92);
            txtBuscarId.Margin = new Padding(3, 4, 3, 4);
            txtBuscarId.Name = "txtBuscarId";
            txtBuscarId.Size = new Size(77, 27);
            txtBuscarId.TabIndex = 43;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(130, 95);
            label2.Name = "label2";
            label2.Size = new Size(25, 23);
            label2.TabIndex = 42;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colIdConsulta, colIdTurno, colDiagnostico, colTratamiento });
            dataGridView1.Location = new Point(130, 131);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(869, 421);
            dataGridView1.TabIndex = 40;
            // 
            // colIdConsulta
            // 
            colIdConsulta.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdConsulta.DataPropertyName = "IdConsulta";
            colIdConsulta.HeaderText = "ID Consulta";
            colIdConsulta.MinimumWidth = 6;
            colIdConsulta.Name = "colIdConsulta";
            colIdConsulta.ReadOnly = true;
            colIdConsulta.Width = 114;
            // 
            // colIdTurno
            // 
            colIdTurno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colIdTurno.DataPropertyName = "IdTurno";
            colIdTurno.HeaderText = "ID Turno";
            colIdTurno.MinimumWidth = 6;
            colIdTurno.Name = "colIdTurno";
            colIdTurno.ReadOnly = true;
            colIdTurno.Width = 95;
            // 
            // colDiagnostico
            // 
            colDiagnostico.DataPropertyName = "Diagnostico";
            colDiagnostico.HeaderText = "Diagnóstico";
            colDiagnostico.MinimumWidth = 6;
            colDiagnostico.Name = "colDiagnostico";
            colDiagnostico.ReadOnly = true;
            // 
            // colTratamiento
            // 
            colTratamiento.DataPropertyName = "Tratamiento";
            colTratamiento.HeaderText = "Tratamiento";
            colTratamiento.MinimumWidth = 6;
            colTratamiento.Name = "colTratamiento";
            colTratamiento.ReadOnly = true;
            // 
            // FormConsultaLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 660);
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarId);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Name = "FormConsultaLista";
            Text = "FormConsultaLista";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscarId;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colIdConsulta;
        private DataGridViewTextBoxColumn colIdTurno;
        private DataGridViewTextBoxColumn colDiagnostico;
        private DataGridViewTextBoxColumn colTratamiento;
    }
}
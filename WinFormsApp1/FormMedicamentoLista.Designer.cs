namespace WinFormsApp1
{
    partial class FormMedicamentoLista
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
            idMedicamentoBuscar = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            IdMedicamento = new DataGridViewTextBoxColumn();
            NombreMedicamento = new DataGridViewTextBoxColumn();
            CantidadRestante = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(778, 18);
            label1.Name = "label1";
            label1.Size = new Size(155, 25);
            label1.TabIndex = 41;
            label1.Text = "MEDICAMENTOS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Create
            // 
            Create.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Create.Cursor = Cursors.Hand;
            Create.Location = new Point(855, 510);
            Create.Margin = new Padding(3, 4, 3, 4);
            Create.Name = "Create";
            Create.Size = new Size(86, 31);
            Create.TabIndex = 47;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Modificar
            // 
            Modificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Modificar.Cursor = Cursors.Hand;
            Modificar.Location = new Point(753, 510);
            Modificar.Margin = new Padding(3, 4, 3, 4);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(86, 31);
            Modificar.TabIndex = 46;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Delete.Cursor = Cursors.Hand;
            Delete.Location = new Point(27, 510);
            Delete.Margin = new Padding(3, 4, 3, 4);
            Delete.Name = "Delete";
            Delete.Size = new Size(86, 31);
            Delete.TabIndex = 45;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Cursor = Cursors.Hand;
            Buscar.Location = new Point(141, 19);
            Buscar.Margin = new Padding(3, 4, 3, 4);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(86, 31);
            Buscar.TabIndex = 44;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // idMedicamentoBuscar
            // 
            idMedicamentoBuscar.Location = new Point(57, 19);
            idMedicamentoBuscar.Margin = new Padding(3, 4, 3, 4);
            idMedicamentoBuscar.Name = "idMedicamentoBuscar";
            idMedicamentoBuscar.Size = new Size(77, 27);
            idMedicamentoBuscar.TabIndex = 43;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 22);
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdMedicamento, NombreMedicamento, CantidadRestante });
            dataGridView1.Location = new Point(27, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(906, 402);
            dataGridView1.TabIndex = 48;
            // 
            // IdMedicamento
            // 
            IdMedicamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IdMedicamento.DataPropertyName = "IdMedicamento";
            IdMedicamento.HeaderText = "ID";
            IdMedicamento.MinimumWidth = 6;
            IdMedicamento.Name = "IdMedicamento";
            IdMedicamento.ReadOnly = true;
            IdMedicamento.Width = 53;
            // 
            // NombreMedicamento
            // 
            NombreMedicamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NombreMedicamento.DataPropertyName = "NombreMedicamento";
            NombreMedicamento.HeaderText = "Nombre";
            NombreMedicamento.MinimumWidth = 6;
            NombreMedicamento.Name = "NombreMedicamento";
            NombreMedicamento.ReadOnly = true;
            // 
            // CantidadRestante
            // 
            CantidadRestante.DataPropertyName = "CantidadRestante";
            CantidadRestante.HeaderText = "Cantidad Restante";
            CantidadRestante.MinimumWidth = 6;
            CantidadRestante.Name = "CantidadRestante";
            CantidadRestante.ReadOnly = true;
            CantidadRestante.Width = 300;
            // 
            // FormMedicamentoLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 559);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(Create);
            Controls.Add(Modificar);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idMedicamentoBuscar);
            Controls.Add(label2);
            Name = "FormMedicamentoLista";
            Text = "FormMedicamentoLista";
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
        private TextBox idMedicamentoBuscar;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdMedicamento;
        private DataGridViewTextBoxColumn NombreMedicamento;
        private DataGridViewTextBoxColumn CantidadRestante;
    }
}
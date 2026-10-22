namespace WinFormsApp1
{
    partial class FormTipoVacunaLista
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
            idVacunaBuscar = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            IdTipoVacuna = new DataGridViewTextBoxColumn();
            NombreTipoVacuna = new DataGridViewTextBoxColumn();
            DescripcionTipoVacuna = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(776, 14);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 49;
            label1.Text = "VACUNAS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Create
            // 
            Create.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Create.Cursor = Cursors.Hand;
            Create.Location = new Point(854, 480);
            Create.Margin = new Padding(3, 4, 3, 4);
            Create.Name = "Create";
            Create.Size = new Size(86, 31);
            Create.TabIndex = 55;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Modificar
            // 
            Modificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Modificar.Cursor = Cursors.Hand;
            Modificar.Location = new Point(751, 480);
            Modificar.Margin = new Padding(3, 4, 3, 4);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(86, 31);
            Modificar.TabIndex = 54;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Delete.Cursor = Cursors.Hand;
            Delete.Location = new Point(25, 480);
            Delete.Margin = new Padding(3, 4, 3, 4);
            Delete.Name = "Delete";
            Delete.Size = new Size(86, 31);
            Delete.TabIndex = 53;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Cursor = Cursors.Hand;
            Buscar.Location = new Point(139, 15);
            Buscar.Margin = new Padding(3, 4, 3, 4);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(86, 31);
            Buscar.TabIndex = 52;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // idVacunaBuscar
            // 
            idVacunaBuscar.Location = new Point(55, 15);
            idVacunaBuscar.Margin = new Padding(3, 4, 3, 4);
            idVacunaBuscar.Name = "idVacunaBuscar";
            idVacunaBuscar.Size = new Size(77, 27);
            idVacunaBuscar.TabIndex = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 18);
            label2.Name = "label2";
            label2.Size = new Size(25, 23);
            label2.TabIndex = 50;
            label2.Text = "Id";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdTipoVacuna, NombreTipoVacuna, DescripcionTipoVacuna });
            dataGridView1.Location = new Point(26, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(914, 420);
            dataGridView1.TabIndex = 56;
            // 
            // IdTipoVacuna
            // 
            IdTipoVacuna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IdTipoVacuna.DataPropertyName = "IdTipoVacuna";
            IdTipoVacuna.HeaderText = "ID";
            IdTipoVacuna.MinimumWidth = 6;
            IdTipoVacuna.Name = "IdTipoVacuna";
            IdTipoVacuna.ReadOnly = true;
            IdTipoVacuna.Width = 53;
            // 
            // NombreTipoVacuna
            // 
            NombreTipoVacuna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            NombreTipoVacuna.DataPropertyName = "NombreTipoVacuna";
            NombreTipoVacuna.HeaderText = "Nombre";
            NombreTipoVacuna.MinimumWidth = 6;
            NombreTipoVacuna.Name = "NombreTipoVacuna";
            NombreTipoVacuna.ReadOnly = true;
            NombreTipoVacuna.Width = 93;
            // 
            // DescripcionTipoVacuna
            // 
            DescripcionTipoVacuna.DataPropertyName = "DescripcionTipoVacuna";
            DescripcionTipoVacuna.HeaderText = "Descripción";
            DescripcionTipoVacuna.MinimumWidth = 6;
            DescripcionTipoVacuna.Name = "DescripcionTipoVacuna";
            DescripcionTipoVacuna.ReadOnly = true;
            DescripcionTipoVacuna.Width = 715;
            // 
            // FormTipoVacunaLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 524);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(Create);
            Controls.Add(Modificar);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idVacunaBuscar);
            Controls.Add(label2);
            Name = "FormTipoVacunaLista";
            Text = "FormTipoVacunaLista";
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
        private TextBox idVacunaBuscar;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdTipoVacuna;
        private DataGridViewTextBoxColumn NombreTipoVacuna;
        private DataGridViewTextBoxColumn DescripcionTipoVacuna;
    }
}
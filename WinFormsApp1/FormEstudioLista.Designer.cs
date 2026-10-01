namespace WinFormsApp1
{
    partial class FormEstudioLista
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
            idEstudioBuscar = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            IdEstudio = new DataGridViewTextBoxColumn();
            NombreEstudio = new DataGridViewTextBoxColumn();
            DescripcionEstudio = new DataGridViewTextBoxColumn();
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
            label1.Size = new Size(97, 25);
            label1.TabIndex = 33;
            label1.Text = "ESTUDIOS";
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
            // idEstudioBuscar
            // 
            idEstudioBuscar.Location = new Point(61, 44);
            idEstudioBuscar.Margin = new Padding(3, 4, 3, 4);
            idEstudioBuscar.Name = "idEstudioBuscar";
            idEstudioBuscar.Size = new Size(77, 27);
            idEstudioBuscar.TabIndex = 35;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdEstudio, NombreEstudio, DescripcionEstudio });
            dataGridView1.Location = new Point(32, 83);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(869, 421);
            dataGridView1.TabIndex = 32;
            // 
            // IdEstudio
            // 
            IdEstudio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IdEstudio.DataPropertyName = "IdEstudio";
            IdEstudio.HeaderText = "ID";
            IdEstudio.MinimumWidth = 6;
            IdEstudio.Name = "IdEstudio";
            IdEstudio.ReadOnly = true;
            IdEstudio.Width = 53;
            // 
            // NombreEstudio
            // 
            NombreEstudio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            NombreEstudio.DataPropertyName = "NombreEstudio";
            NombreEstudio.HeaderText = "Nombre";
            NombreEstudio.MinimumWidth = 6;
            NombreEstudio.Name = "NombreEstudio";
            NombreEstudio.ReadOnly = true;
            NombreEstudio.Width = 93;
            // 
            // DescripcionEstudio
            // 
            DescripcionEstudio.DataPropertyName = "DescripcionEstudio";
            DescripcionEstudio.HeaderText = "Descripción";
            DescripcionEstudio.MinimumWidth = 6;
            DescripcionEstudio.Name = "DescripcionEstudio";
            DescripcionEstudio.ReadOnly = true;
            // 
            // FormEstudioLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 572);
            Controls.Add(label1);
            Controls.Add(Create);
            Controls.Add(Modificar);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idEstudioBuscar);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Name = "FormEstudioLista";
            Text = "FormEstudioCRUD";
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
        private TextBox idEstudioBuscar;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdEstudio;
        private DataGridViewTextBoxColumn NombreEstudio;
        private DataGridViewTextBoxColumn DescripcionEstudio;
    }
}
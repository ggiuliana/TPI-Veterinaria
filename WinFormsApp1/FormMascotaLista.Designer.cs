namespace WinFormsApp1
{
    partial class FormMascotaLista
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
            idMascotaBuscar = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            IdMascota = new DataGridViewTextBoxColumn();
            NombreMascota = new DataGridViewTextBoxColumn();
            Especie = new DataGridViewTextBoxColumn();
            Raza = new DataGridViewTextBoxColumn();
            Castrado = new DataGridViewTextBoxColumn();
            Sexo = new DataGridViewTextBoxColumn();
            FechaNac = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(668, 30);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 41;
            label1.Text = "MASCOTAS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Create
            // 
            Create.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Create.Cursor = Cursors.Hand;
            Create.Location = new Point(705, 398);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 47;
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
            Modificar.TabIndex = 46;
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
            Delete.TabIndex = 45;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Cursor = Cursors.Hand;
            Buscar.Location = new Point(120, 47);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 44;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // idMascotaBuscar
            // 
            idMascotaBuscar.Location = new Point(46, 47);
            idMascotaBuscar.Name = "idMascotaBuscar";
            idMascotaBuscar.Size = new Size(68, 23);
            idMascotaBuscar.TabIndex = 43;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 49);
            label2.Name = "label2";
            label2.Size = new Size(19, 17);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdMascota, NombreMascota, Especie, Raza, Castrado, Sexo, FechaNac });
            dataGridView1.Location = new Point(21, 76);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 316);
            dataGridView1.TabIndex = 40;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // IdMascota
            // 
            IdMascota.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IdMascota.DataPropertyName = "IdMascota";
            IdMascota.HeaderText = "ID";
            IdMascota.MinimumWidth = 6;
            IdMascota.Name = "IdMascota";
            IdMascota.ReadOnly = true;
            IdMascota.Width = 43;
            // 
            // NombreMascota
            // 
            NombreMascota.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NombreMascota.DataPropertyName = "NombreMascota";
            NombreMascota.HeaderText = "Nombre";
            NombreMascota.MinimumWidth = 6;
            NombreMascota.Name = "NombreMascota";
            NombreMascota.ReadOnly = true;
            NombreMascota.Width = 76;
            // 
            // Especie
            // 
            Especie.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Especie.DataPropertyName = "Especie";
            Especie.HeaderText = "Especie";
            Especie.MinimumWidth = 6;
            Especie.Name = "Especie";
            Especie.ReadOnly = true;
            Especie.Width = 71;
            // 
            // Raza
            // 
            Raza.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Raza.DataPropertyName = "Raza";
            Raza.HeaderText = "Raza";
            Raza.MinimumWidth = 6;
            Raza.Name = "Raza";
            Raza.ReadOnly = true;
            Raza.Width = 56;
            // 
            // Castrado
            // 
            Castrado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Castrado.DataPropertyName = "Castrado";
            Castrado.HeaderText = "Castrado";
            Castrado.MinimumWidth = 6;
            Castrado.Name = "Castrado";
            Castrado.ReadOnly = true;
            Castrado.Width = 56;
            // 
            // Sexo
            // 
            Sexo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Sexo.DataPropertyName = "Sexo";
            Sexo.HeaderText = "Sexo";
            Sexo.MinimumWidth = 6;
            Sexo.Name = "Sexo";
            Sexo.ReadOnly = true;
            Sexo.Width = 56;
            // 
            // FechaNac
            // 
            FechaNac.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FechaNac.DataPropertyName = "FechaNac";
            FechaNac.HeaderText = "Fecha de Nacimiento";
            FechaNac.MinimumWidth = 6;
            FechaNac.Name = "FechaNac";
            FechaNac.ReadOnly = true;
            FechaNac.Width = 56;
            // 
            // FormMascotaLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(Create);
            Controls.Add(Modificar);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idMascotaBuscar);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Name = "FormMascotaLista";
            Text = "Form1";
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
        private TextBox idMascotaBuscar;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdMascota;
        private DataGridViewTextBoxColumn NombreMascota;
        private DataGridViewTextBoxColumn Especie;
        private DataGridViewTextBoxColumn Raza;
        private DataGridViewTextBoxColumn Castrado;
        private DataGridViewTextBoxColumn Sexo;
        private DataGridViewTextBoxColumn FechaNac;
    }
}
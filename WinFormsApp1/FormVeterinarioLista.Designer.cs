namespace WinFormsApp1
{
    partial class FormVeterinarioLista
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
            Create = new Button();
            Modificar = new Button();
            Delete = new Button();
            Buscar = new Button();
            idVet = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            IdVeterinario = new DataGridViewTextBoxColumn();
            Mail = new DataGridViewTextBoxColumn();
            Dni = new DataGridViewTextBoxColumn();
            Direcccion = new DataGridViewTextBoxColumn();
            Especialidad = new DataGridViewTextBoxColumn();
            Matricula = new DataGridViewTextBoxColumn();
            NombreVeterinario = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Create.Cursor = Cursors.Hand;
            Create.Location = new Point(815, 436);
            Create.Margin = new Padding(3, 4, 3, 4);
            Create.Name = "Create";
            Create.Size = new Size(86, 31);
            Create.TabIndex = 31;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Modificar
            // 
            Modificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Modificar.Cursor = Cursors.Hand;
            Modificar.Location = new Point(722, 436);
            Modificar.Margin = new Padding(3, 4, 3, 4);
            Modificar.Name = "Modificar";
            Modificar.Size = new Size(86, 31);
            Modificar.TabIndex = 30;
            Modificar.Text = "Modificar";
            Modificar.UseVisualStyleBackColor = true;
            Modificar.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Delete.Cursor = Cursors.Hand;
            Delete.Location = new Point(29, 436);
            Delete.Margin = new Padding(3, 4, 3, 4);
            Delete.Name = "Delete";
            Delete.Size = new Size(86, 31);
            Delete.TabIndex = 29;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Cursor = Cursors.Hand;
            Buscar.Location = new Point(142, 27);
            Buscar.Margin = new Padding(3, 4, 3, 4);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(86, 31);
            Buscar.TabIndex = 28;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // idVet
            // 
            idVet.Location = new Point(57, 27);
            idVet.Margin = new Padding(3, 4, 3, 4);
            idVet.Name = "idVet";
            idVet.Size = new Size(77, 27);
            idVet.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 29);
            label2.Name = "label2";
            label2.Size = new Size(25, 23);
            label2.TabIndex = 26;
            label2.Text = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(722, 12);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 25;
            label1.Text = "VETERINARIOS";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdVeterinario, Mail, Dni, Direcccion, Especialidad, Matricula, NombreVeterinario, Apellido, Telefono });
            dataGridView1.Location = new Point(29, 65);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(872, 349);
            dataGridView1.TabIndex = 24;
            // 
            // IdVeterinario
            // 
            IdVeterinario.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IdVeterinario.DataPropertyName = "IdVeterinario";
            IdVeterinario.FillWeight = 96.2566757F;
            IdVeterinario.HeaderText = "ID";
            IdVeterinario.MinimumWidth = 6;
            IdVeterinario.Name = "IdVeterinario";
            IdVeterinario.ReadOnly = true;
            IdVeterinario.Width = 53;
            // 
            // Mail
            // 
            Mail.DataPropertyName = "Mail";
            Mail.FillWeight = 100.467926F;
            Mail.HeaderText = "Mail";
            Mail.MinimumWidth = 6;
            Mail.Name = "Mail";
            Mail.ReadOnly = true;
            // 
            // Dni
            // 
            Dni.DataPropertyName = "Dni";
            Dni.FillWeight = 100.467926F;
            Dni.HeaderText = "Dni";
            Dni.MinimumWidth = 6;
            Dni.Name = "Dni";
            Dni.ReadOnly = true;
            // 
            // Direcccion
            // 
            Direcccion.DataPropertyName = "Direccion";
            Direcccion.FillWeight = 100.467926F;
            Direcccion.HeaderText = "Dirección";
            Direcccion.MinimumWidth = 6;
            Direcccion.Name = "Direcccion";
            Direcccion.ReadOnly = true;
            // 
            // Especialidad
            // 
            Especialidad.DataPropertyName = "Especialidad";
            Especialidad.FillWeight = 100.467926F;
            Especialidad.HeaderText = "Especialidad";
            Especialidad.MinimumWidth = 6;
            Especialidad.Name = "Especialidad";
            Especialidad.ReadOnly = true;
            // 
            // Matricula
            // 
            Matricula.DataPropertyName = "Matricula";
            Matricula.FillWeight = 100.467926F;
            Matricula.HeaderText = "Matrícula";
            Matricula.MinimumWidth = 6;
            Matricula.Name = "Matricula";
            Matricula.ReadOnly = true;
            // 
            // NombreVeterinario
            // 
            NombreVeterinario.DataPropertyName = "NombreVeterinario";
            NombreVeterinario.FillWeight = 100.467926F;
            NombreVeterinario.HeaderText = "Nombre";
            NombreVeterinario.MinimumWidth = 6;
            NombreVeterinario.Name = "NombreVeterinario";
            NombreVeterinario.ReadOnly = true;
            // 
            // Apellido
            // 
            Apellido.DataPropertyName = "Apellido";
            Apellido.FillWeight = 100.467926F;
            Apellido.HeaderText = "Apellido";
            Apellido.MinimumWidth = 6;
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            // 
            // Telefono
            // 
            Telefono.DataPropertyName = "Telefono";
            Telefono.FillWeight = 100.467926F;
            Telefono.HeaderText = "Teléfono";
            Telefono.MinimumWidth = 6;
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            // 
            // FormVeterinarioLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 483);
            Controls.Add(Create);
            Controls.Add(Modificar);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idVet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormVeterinarioLista";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Create;
        private Button Modificar;
        private Button Delete;
        private Button Buscar;
        private TextBox idVet;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdVeterinario;
        private DataGridViewTextBoxColumn Mail;
        private DataGridViewTextBoxColumn Dni;
        private DataGridViewTextBoxColumn Direcccion;
        private DataGridViewTextBoxColumn Especialidad;
        private DataGridViewTextBoxColumn Matricula;
        private DataGridViewTextBoxColumn NombreVeterinario;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Telefono;
    }
}
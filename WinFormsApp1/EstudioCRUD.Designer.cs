namespace WinFormsApp1
{
    partial class EstudioCRUD
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Create = new Button();
            Update = new Button();
            Delete = new Button();
            Buscar = new Button();
            idEstudio = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Location = new Point(682, 312);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 31;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Update
            // 
            Update.Location = new Point(601, 312);
            Update.Name = "Update";
            Update.Size = new Size(75, 23);
            Update.TabIndex = 30;
            Update.Text = "Modificar";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(43, 312);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 29;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Location = new Point(142, 39);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 28;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // idEstudio
            // 
            idEstudio.Location = new Point(68, 39);
            idEstudio.Name = "idEstudio";
            idEstudio.Size = new Size(68, 23);
            idEstudio.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 41);
            label2.Name = "label2";
            label2.Size = new Size(19, 17);
            label2.TabIndex = 26;
            label2.Text = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(333, 17);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 25;
            label1.Text = "ESTUDIOS";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(714, 229);
            dataGridView1.TabIndex = 24;
            // 
            // EstudioCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Create);
            Controls.Add(Update);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idEstudio);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "EstudioCRUD";
            Size = new Size(800, 352);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Create;
        private Button Update;
        private Button Delete;
        private Button Buscar;
        private TextBox idEstudios;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox idEstudio;
    }
}

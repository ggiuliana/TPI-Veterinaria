namespace WinFormsApp1
{
    partial class VeterinarioCRUD
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
            components = new System.ComponentModel.Container();
            veterinarioServiceBindingSource = new BindingSource(components);
            Create = new Button();
            Update = new Button();
            Delete = new Button();
            Buscar = new Button();
            idVet = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)veterinarioServiceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Location = new Point(682, 312);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 23;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Update
            // 
            Update.Location = new Point(601, 312);
            Update.Name = "Update";
            Update.Size = new Size(75, 23);
            Update.TabIndex = 22;
            Update.Text = "Modificar";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(43, 312);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 21;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Buscar
            // 
            Buscar.Location = new Point(142, 39);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 20;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // idVet
            // 
            idVet.Location = new Point(68, 39);
            idVet.Name = "idVet";
            idVet.Size = new Size(68, 23);
            idVet.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 41);
            label2.Name = "label2";
            label2.Size = new Size(19, 17);
            label2.TabIndex = 18;
            label2.Text = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(333, 17);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 17;
            label1.Text = "VETERINARIOS";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = veterinarioServiceBindingSource;
            dataGridView1.Location = new Point(43, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(714, 229);
            dataGridView1.TabIndex = 16;
            // 
            // VeterinarioCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Create);
            Controls.Add(Update);
            Controls.Add(Delete);
            Controls.Add(Buscar);
            Controls.Add(idVet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "VeterinarioCRUD";
            Size = new Size(800, 352);
            Load += VeterinarioCRUD_Load;
            ((System.ComponentModel.ISupportInitialize)veterinarioServiceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource veterinarioServiceBindingSource;
        private Button Create;
        private Button Update;
        private Button Delete;
        private Button Buscar;
        private TextBox idVet;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
    }
}

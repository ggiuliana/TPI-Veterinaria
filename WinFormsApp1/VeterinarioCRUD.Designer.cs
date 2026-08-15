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
            dataGridView1 = new DataGridView();
            veterinarioServiceBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            idVet = new TextBox();
            Buscar = new Button();
            Delete = new Button();
            Update = new Button();
            Create = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)veterinarioServiceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = veterinarioServiceBindingSource;
            dataGridView1.Location = new Point(32, 89);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(433, 204);
            dataGridView1.TabIndex = 0;
            // 
            // veterinarioServiceBindingSource
            // 
            veterinarioServiceBindingSource.DataSource = typeof(ServiciosApp.VeterinarioService);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(181, 13);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 1;
            label1.Text = "VETERINARIOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(68, 52);
            label2.Name = "label2";
            label2.Size = new Size(19, 17);
            label2.TabIndex = 2;
            label2.Text = "Id";
            // 
            // idVet
            // 
            idVet.Location = new Point(93, 51);
            idVet.Name = "idVet";
            idVet.Size = new Size(268, 23);
            idVet.TabIndex = 3;
            // 
            // Buscar
            // 
            Buscar.Location = new Point(367, 52);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 4;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = true;
            Buscar.Click += Buscar_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(32, 324);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 5;
            Delete.Text = "Eliminar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Update
            // 
            Update.Location = new Point(309, 324);
            Update.Name = "Update";
            Update.Size = new Size(75, 23);
            Update.TabIndex = 6;
            Update.Text = "Modificar";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Create
            // 
            Create.Location = new Point(390, 324);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 7;
            Create.Text = "Agregar";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
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
            Size = new Size(498, 386);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)veterinarioServiceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource veterinarioServiceBindingSource;
        private Label label1;
        private Label label2;
        private TextBox idVet;
        private Button Buscar;
        private Button Delete;
        private Button Update;
        private Button Create;
    }
}

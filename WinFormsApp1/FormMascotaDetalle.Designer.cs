namespace WinFormsApp1
{
    partial class FormMascotaDetalle
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
            panel1 = new Panel();
            Vacunas = new GroupBox();
            vacunasLista = new DataGridView();
            label7 = new Label();
            label6 = new Label();
            Eliminar = new Button();
            Agregar = new Button();
            fechaVacuna = new DateTimePicker();
            tipoVacuna = new ComboBox();
            labelTit = new Label();
            fechaNacimientoMascota = new DateTimePicker();
            label5 = new Label();
            sexoMascota = new ComboBox();
            label4 = new Label();
            castradoMascota = new CheckBox();
            label1 = new Label();
            razaMascota = new TextBox();
            Guardar = new Button();
            Cancelar = new Button();
            lblTitulo = new Label();
            label2 = new Label();
            especieMascota = new TextBox();
            label3 = new Label();
            nombreMascota = new TextBox();
            panel1.SuspendLayout();
            Vacunas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vacunasLista).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(Vacunas);
            panel1.Controls.Add(labelTit);
            panel1.Controls.Add(fechaNacimientoMascota);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(sexoMascota);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(castradoMascota);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(razaMascota);
            panel1.Controls.Add(Guardar);
            panel1.Controls.Add(Cancelar);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(especieMascota);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nombreMascota);
            panel1.Location = new Point(31, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(492, 528);
            panel1.TabIndex = 42;
            // 
            // Vacunas
            // 
            Vacunas.Controls.Add(vacunasLista);
            Vacunas.Controls.Add(label7);
            Vacunas.Controls.Add(label6);
            Vacunas.Controls.Add(Eliminar);
            Vacunas.Controls.Add(Agregar);
            Vacunas.Controls.Add(fechaVacuna);
            Vacunas.Controls.Add(tipoVacuna);
            Vacunas.Location = new Point(20, 281);
            Vacunas.Name = "Vacunas";
            Vacunas.Size = new Size(453, 178);
            Vacunas.TabIndex = 50;
            Vacunas.TabStop = false;
            Vacunas.Text = "Vacunas";
            // 
            // vacunasLista
            // 
            vacunasLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            vacunasLista.Location = new Point(152, 18);
            vacunasLista.Name = "vacunasLista";
            vacunasLista.Size = new Size(294, 150);
            vacunasLista.TabIndex = 53;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 73);
            label7.Name = "label7";
            label7.Size = new Size(118, 15);
            label7.TabIndex = 52;
            label7.Text = "Fecha de colocación:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 21);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 51;
            label6.Text = "Tipo de vacuna:";
            // 
            // Eliminar
            // 
            Eliminar.BackColor = SystemColors.ActiveCaption;
            Eliminar.Location = new Point(81, 134);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(64, 23);
            Eliminar.TabIndex = 3;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = false;
            Eliminar.Click += Eliminar_Click;
            // 
            // Agregar
            // 
            Agregar.Location = new Point(20, 134);
            Agregar.Name = "Agregar";
            Agregar.Size = new Size(64, 23);
            Agregar.TabIndex = 2;
            Agregar.Text = "Agregar";
            Agregar.UseVisualStyleBackColor = true;
            Agregar.Click += Agregar_Click;
            // 
            // fechaVacuna
            // 
            fechaVacuna.Format = DateTimePickerFormat.Short;
            fechaVacuna.Location = new Point(22, 91);
            fechaVacuna.Name = "fechaVacuna";
            fechaVacuna.Size = new Size(121, 23);
            fechaVacuna.TabIndex = 1;
            // 
            // tipoVacuna
            // 
            tipoVacuna.FormattingEnabled = true;
            tipoVacuna.Location = new Point(22, 41);
            tipoVacuna.Name = "tipoVacuna";
            tipoVacuna.Size = new Size(121, 23);
            tipoVacuna.TabIndex = 0;
            // 
            // labelTit
            // 
            labelTit.AutoSize = true;
            labelTit.Font = new Font("Segoe UI", 15F);
            labelTit.Location = new Point(121, 14);
            labelTit.Name = "labelTit";
            labelTit.Size = new Size(0, 28);
            labelTit.TabIndex = 49;
            // 
            // fechaNacimientoMascota
            // 
            fechaNacimientoMascota.Format = DateTimePickerFormat.Short;
            fechaNacimientoMascota.Location = new Point(209, 244);
            fechaNacimientoMascota.Name = "fechaNacimientoMascota";
            fechaNacimientoMascota.Size = new Size(197, 23);
            fechaNacimientoMascota.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(97, 250);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 47;
            label5.Text = "Fecha Nacimiento:";
            // 
            // sexoMascota
            // 
            sexoMascota.FormattingEnabled = true;
            sexoMascota.Items.AddRange(new object[] { "Macho", "Hembra" });
            sexoMascota.Location = new Point(255, 200);
            sexoMascota.Name = "sexoMascota";
            sexoMascota.Size = new Size(151, 23);
            sexoMascota.TabIndex = 46;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(213, 205);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 45;
            label4.Text = "Sexo:";
            // 
            // castradoMascota
            // 
            castradoMascota.AutoSize = true;
            castradoMascota.Location = new Point(97, 204);
            castradoMascota.Name = "castradoMascota";
            castradoMascota.Size = new Size(73, 19);
            castradoMascota.TabIndex = 44;
            castradoMascota.Text = "Castrado";
            castradoMascota.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 148);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 42;
            label1.Text = "Raza:";
            // 
            // razaMascota
            // 
            razaMascota.Location = new Point(178, 148);
            razaMascota.Name = "razaMascota";
            razaMascota.Size = new Size(228, 23);
            razaMascota.TabIndex = 41;
            // 
            // Guardar
            // 
            Guardar.BackColor = SystemColors.ActiveCaption;
            Guardar.Cursor = Cursors.Hand;
            Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Guardar.ForeColor = SystemColors.ControlText;
            Guardar.Location = new Point(262, 472);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(123, 39);
            Guardar.TabIndex = 39;
            Guardar.Text = "Guardar";
            Guardar.UseVisualStyleBackColor = false;
            Guardar.Click += Guardar_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ControlLight;
            Cancelar.Cursor = Cursors.Hand;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(118, 472);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(123, 39);
            Cancelar.TabIndex = 40;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(104, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(0, 30);
            lblTitulo.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 70);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 15;
            label2.Text = "Nombre:";
            // 
            // especieMascota
            // 
            especieMascota.Location = new Point(178, 102);
            especieMascota.Name = "especieMascota";
            especieMascota.Size = new Size(228, 23);
            especieMascota.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 105);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 16;
            label3.Text = "Especie:";
            // 
            // nombreMascota
            // 
            nombreMascota.Location = new Point(178, 67);
            nombreMascota.Name = "nombreMascota";
            nombreMascota.Size = new Size(228, 23);
            nombreMascota.TabIndex = 18;
            // 
            // FormMascotaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 565);
            Controls.Add(panel1);
            Name = "FormMascotaDetalle";
            Text = "Mascota Detalle";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Vacunas.ResumeLayout(false);
            Vacunas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)vacunasLista).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox razaMascota;
        private Button Guardar;
        private Button Cancelar;
        private Label lblTitulo;
        private Label label2;
        private TextBox especieMascota;
        private Label label3;
        private TextBox nombreMascota;
        private Label label1;
        private CheckBox castradoMascota;
        private ComboBox sexoMascota;
        private Label label4;
        private DateTimePicker fechaNacimientoMascota;
        private Label label5;
        private Label labelTit;
        private GroupBox Vacunas;
        private ComboBox tipoVacuna;
        private DataGridView vacunasLista;
        private Label label7;
        private Label label6;
        private Button Eliminar;
        private Button Agregar;
        private DateTimePicker fechaVacuna;
    }
}
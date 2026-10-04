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
            Guardar = new Button();
            Cancelar = new Button();
            lblTitulo = new Label();
            label2 = new Label();
            especieMascota = new TextBox();
            label3 = new Label();
            nombreMascota = new TextBox();
            razaMascota = new TextBox();
            label1 = new Label();
            castradoMascota = new CheckBox();
            label4 = new Label();
            sexoMascota = new ComboBox();
            label5 = new Label();
            fechaNacimientoMascota = new DateTimePicker();
            labelTit = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
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
            panel1.Location = new Point(0, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 380);
            panel1.TabIndex = 42;
            // 
            // Guardar
            // 
            Guardar.BackColor = SystemColors.ActiveCaption;
            Guardar.Cursor = Cursors.Hand;
            Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Guardar.ForeColor = SystemColors.ControlText;
            Guardar.Location = new Point(198, 313);
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
            Cancelar.Location = new Point(54, 313);
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
            label2.Location = new Point(40, 66);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 15;
            label2.Text = "Nombre:";
            // 
            // especieMascota
            // 
            especieMascota.Location = new Point(121, 98);
            especieMascota.Name = "especieMascota";
            especieMascota.Size = new Size(228, 23);
            especieMascota.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 101);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 16;
            label3.Text = "Especie:";
            // 
            // nombreMascota
            // 
            nombreMascota.Location = new Point(121, 63);
            nombreMascota.Name = "nombreMascota";
            nombreMascota.Size = new Size(228, 23);
            nombreMascota.TabIndex = 18;
            // 
            // razaMascota
            // 
            razaMascota.Location = new Point(121, 144);
            razaMascota.Name = "razaMascota";
            razaMascota.Size = new Size(228, 23);
            razaMascota.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 144);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 42;
            label1.Text = "Raza:";
            // 
            // castradoMascota
            // 
            castradoMascota.AutoSize = true;
            castradoMascota.Location = new Point(40, 200);
            castradoMascota.Name = "castradoMascota";
            castradoMascota.Size = new Size(73, 19);
            castradoMascota.TabIndex = 44;
            castradoMascota.Text = "Castrado";
            castradoMascota.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(156, 201);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 45;
            label4.Text = "Sexo:";
            // 
            // sexoMascota
            // 
            sexoMascota.FormattingEnabled = true;
            sexoMascota.Items.AddRange(new object[] { "Macho", "Hembra" });
            sexoMascota.Location = new Point(198, 196);
            sexoMascota.Name = "sexoMascota";
            sexoMascota.Size = new Size(151, 23);
            sexoMascota.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 246);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 47;
            label5.Text = "Fecha Nacimiento:";
            // 
            // fechaNacimientoMascota
            // 
            fechaNacimientoMascota.Location = new Point(152, 240);
            fechaNacimientoMascota.Name = "fechaNacimientoMascota";
            fechaNacimientoMascota.Size = new Size(197, 23);
            fechaNacimientoMascota.TabIndex = 48;
            // 
            // labelTit
            // 
            labelTit.AutoSize = true;
            labelTit.Font = new Font("Segoe UI", 15F);
            labelTit.Location = new Point(121, 14);
            labelTit.Name = "labelTit";
            labelTit.Size = new Size(137, 28);
            labelTit.TabIndex = 49;
            // 
            // FormMascotaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 387);
            Controls.Add(panel1);
            Name = "FormMascotaDetalle";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}
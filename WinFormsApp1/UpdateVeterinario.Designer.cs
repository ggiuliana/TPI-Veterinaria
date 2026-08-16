namespace WinFormsApp1
{
    partial class UpdateVeterinario
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
            SeleccionVet = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            especialidadVeterinario = new TextBox();
            matriculaVeterinario = new TextBox();
            dniVeterinario = new TextBox();
            direccionVeterinario = new TextBox();
            mailVeterinario = new TextBox();
            telefonoVeterinario = new TextBox();
            apellidoVeterinario = new TextBox();
            nombreVeterinario = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label10 = new Label();
            label11 = new Label();
            Guardar = new Button();
            Cancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 24);
            label1.Name = "label1";
            label1.Size = new Size(275, 30);
            label1.TabIndex = 0;
            label1.Text = "MODIFICAR VETERINARIO";
            // 
            // SeleccionVet
            // 
            SeleccionVet.FormattingEnabled = true;
            SeleccionVet.Location = new Point(136, 82);
            SeleccionVet.Name = "SeleccionVet";
            SeleccionVet.Size = new Size(189, 23);
            SeleccionVet.TabIndex = 1;
            SeleccionVet.SelectedIndexChanged += SeleccionVet_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 81);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 2;
            label2.Text = "Veterinario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(357, 20);
            label3.TabIndex = 3;
            label3.Text = "----------------------------------------------------------";
            // 
            // especialidadVeterinario
            // 
            especialidadVeterinario.Location = new Point(116, 408);
            especialidadVeterinario.Name = "especialidadVeterinario";
            especialidadVeterinario.Size = new Size(228, 23);
            especialidadVeterinario.TabIndex = 34;
            // 
            // matriculaVeterinario
            // 
            matriculaVeterinario.Location = new Point(116, 375);
            matriculaVeterinario.Name = "matriculaVeterinario";
            matriculaVeterinario.Size = new Size(228, 23);
            matriculaVeterinario.TabIndex = 33;
            // 
            // dniVeterinario
            // 
            dniVeterinario.Location = new Point(116, 340);
            dniVeterinario.Name = "dniVeterinario";
            dniVeterinario.Size = new Size(228, 23);
            dniVeterinario.TabIndex = 32;
            // 
            // direccionVeterinario
            // 
            direccionVeterinario.Location = new Point(116, 304);
            direccionVeterinario.Name = "direccionVeterinario";
            direccionVeterinario.Size = new Size(228, 23);
            direccionVeterinario.TabIndex = 31;
            // 
            // mailVeterinario
            // 
            mailVeterinario.Location = new Point(116, 267);
            mailVeterinario.Name = "mailVeterinario";
            mailVeterinario.Size = new Size(228, 23);
            mailVeterinario.TabIndex = 30;
            // 
            // telefonoVeterinario
            // 
            telefonoVeterinario.Location = new Point(116, 231);
            telefonoVeterinario.Name = "telefonoVeterinario";
            telefonoVeterinario.Size = new Size(228, 23);
            telefonoVeterinario.TabIndex = 29;
            // 
            // apellidoVeterinario
            // 
            apellidoVeterinario.Location = new Point(116, 195);
            apellidoVeterinario.Name = "apellidoVeterinario";
            apellidoVeterinario.Size = new Size(228, 23);
            apellidoVeterinario.TabIndex = 28;
            // 
            // nombreVeterinario
            // 
            nombreVeterinario.Location = new Point(116, 160);
            nombreVeterinario.Name = "nombreVeterinario";
            nombreVeterinario.Size = new Size(228, 23);
            nombreVeterinario.TabIndex = 27;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(35, 411);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 26;
            label9.Text = "Especialidad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(35, 378);
            label8.Name = "label8";
            label8.Size = new Size(60, 15);
            label8.TabIndex = 25;
            label8.Text = "Matricula:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(35, 343);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 24;
            label7.Text = "Dni:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 307);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 23;
            label6.Text = "Direccion:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 270);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 22;
            label5.Text = "Mail:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 234);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 21;
            label4.Text = "Telefono:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(35, 198);
            label10.Name = "label10";
            label10.Size = new Size(54, 15);
            label10.TabIndex = 20;
            label10.Text = "Apellido:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(35, 163);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 19;
            label11.Text = "Nombre:";
            // 
            // Guardar
            // 
            Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Guardar.Location = new Point(202, 473);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(123, 39);
            Guardar.TabIndex = 35;
            Guardar.Text = "Guardar";
            Guardar.UseVisualStyleBackColor = true;
            Guardar.Click += Guardar_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ActiveCaption;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(50, 473);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(123, 39);
            Cancelar.TabIndex = 36;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // UpdateVeterinario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 545);
            Controls.Add(Cancelar);
            Controls.Add(Guardar);
            Controls.Add(especialidadVeterinario);
            Controls.Add(matriculaVeterinario);
            Controls.Add(dniVeterinario);
            Controls.Add(direccionVeterinario);
            Controls.Add(mailVeterinario);
            Controls.Add(telefonoVeterinario);
            Controls.Add(apellidoVeterinario);
            Controls.Add(nombreVeterinario);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(SeleccionVet);
            Controls.Add(label1);
            Name = "UpdateVeterinario";
            Text = "Form1";
            Load += UpdateVeterinario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox SeleccionVet;
        private Label label2;
        private Label label3;
        private TextBox especialidadVeterinario;
        private TextBox matriculaVeterinario;
        private TextBox dniVeterinario;
        private TextBox direccionVeterinario;
        private TextBox mailVeterinario;
        private TextBox telefonoVeterinario;
        private TextBox apellidoVeterinario;
        private TextBox nombreVeterinario;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label10;
        private Label label11;
        private Button Guardar;
        private Button Cancelar;
    }
}
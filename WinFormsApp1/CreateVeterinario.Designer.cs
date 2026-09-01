namespace WinFormsApp1
{
    partial class CreateVeterinario
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            guardar = new Button();
            cancelar = new Button();
            nombreVeterinario = new TextBox();
            apellidoVeterinario = new TextBox();
            telefonoVeterinario = new TextBox();
            mailVeterinario = new TextBox();
            direccionVeterinario = new TextBox();
            dniVeterinario = new TextBox();
            matriculaVeterinario = new TextBox();
            especialidadVeterinario = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            nombreUsuario = new TextBox();
            contraseniaUsuario = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(103, 32);
            label1.Name = "label1";
            label1.Size = new Size(251, 37);
            label1.TabIndex = 0;
            label1.Text = "Nuevo Veterinario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 108);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 155);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 2;
            label3.Text = "Apellido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 203);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "Telefono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 251);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 4;
            label5.Text = "Mail:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 300);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 5;
            label6.Text = "Direccion:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 348);
            label7.Name = "label7";
            label7.Size = new Size(35, 20);
            label7.TabIndex = 6;
            label7.Text = "Dni:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 395);
            label8.Name = "label8";
            label8.Size = new Size(74, 20);
            label8.TabIndex = 7;
            label8.Text = "Matricula:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(25, 439);
            label9.Name = "label9";
            label9.Size = new Size(96, 20);
            label9.TabIndex = 8;
            label9.Text = "Especialidad:";
            // 
            // guardar
            // 
            guardar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guardar.Location = new Point(229, 733);
            guardar.Margin = new Padding(3, 4, 3, 4);
            guardar.Name = "guardar";
            guardar.Size = new Size(126, 59);
            guardar.TabIndex = 9;
            guardar.Text = "Guardar";
            guardar.UseVisualStyleBackColor = true;
            guardar.Click += Guardar_Click;
            // 
            // cancelar
            // 
            cancelar.BackColor = SystemColors.ActiveCaption;
            cancelar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelar.Location = new Point(61, 733);
            cancelar.Margin = new Padding(3, 4, 3, 4);
            cancelar.Name = "cancelar";
            cancelar.Size = new Size(137, 59);
            cancelar.TabIndex = 10;
            cancelar.Text = "Cancelar";
            cancelar.UseVisualStyleBackColor = false;
            cancelar.Click += Cancelar_Click;
            // 
            // nombreVeterinario
            // 
            nombreVeterinario.Location = new Point(118, 104);
            nombreVeterinario.Margin = new Padding(3, 4, 3, 4);
            nombreVeterinario.Name = "nombreVeterinario";
            nombreVeterinario.Size = new Size(260, 27);
            nombreVeterinario.TabIndex = 11;
            // 
            // apellidoVeterinario
            // 
            apellidoVeterinario.Location = new Point(118, 151);
            apellidoVeterinario.Margin = new Padding(3, 4, 3, 4);
            apellidoVeterinario.Name = "apellidoVeterinario";
            apellidoVeterinario.Size = new Size(260, 27);
            apellidoVeterinario.TabIndex = 12;
            // 
            // telefonoVeterinario
            // 
            telefonoVeterinario.Location = new Point(118, 199);
            telefonoVeterinario.Margin = new Padding(3, 4, 3, 4);
            telefonoVeterinario.Name = "telefonoVeterinario";
            telefonoVeterinario.Size = new Size(260, 27);
            telefonoVeterinario.TabIndex = 13;
            // 
            // mailVeterinario
            // 
            mailVeterinario.Location = new Point(118, 247);
            mailVeterinario.Margin = new Padding(3, 4, 3, 4);
            mailVeterinario.Name = "mailVeterinario";
            mailVeterinario.Size = new Size(260, 27);
            mailVeterinario.TabIndex = 14;
            // 
            // direccionVeterinario
            // 
            direccionVeterinario.Location = new Point(118, 296);
            direccionVeterinario.Margin = new Padding(3, 4, 3, 4);
            direccionVeterinario.Name = "direccionVeterinario";
            direccionVeterinario.Size = new Size(260, 27);
            direccionVeterinario.TabIndex = 15;
            // 
            // dniVeterinario
            // 
            dniVeterinario.Location = new Point(118, 344);
            dniVeterinario.Margin = new Padding(3, 4, 3, 4);
            dniVeterinario.Name = "dniVeterinario";
            dniVeterinario.Size = new Size(260, 27);
            dniVeterinario.TabIndex = 16;
            // 
            // matriculaVeterinario
            // 
            matriculaVeterinario.Location = new Point(118, 391);
            matriculaVeterinario.Margin = new Padding(3, 4, 3, 4);
            matriculaVeterinario.Name = "matriculaVeterinario";
            matriculaVeterinario.Size = new Size(260, 27);
            matriculaVeterinario.TabIndex = 17;
            // 
            // especialidadVeterinario
            // 
            especialidadVeterinario.Location = new Point(118, 435);
            especialidadVeterinario.Margin = new Padding(3, 4, 3, 4);
            especialidadVeterinario.Name = "especialidadVeterinario";
            especialidadVeterinario.Size = new Size(260, 27);
            especialidadVeterinario.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(61, 493);
            label10.Name = "label10";
            label10.Size = new Size(309, 20);
            label10.TabIndex = 19;
            label10.Text = "--------------------------------------------------";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(103, 532);
            label11.Name = "label11";
            label11.Size = new Size(240, 37);
            label11.TabIndex = 20;
            label11.Text = "Usuario asignado";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(25, 597);
            label12.Name = "label12";
            label12.Size = new Size(119, 20);
            label12.TabIndex = 21;
            label12.Text = "Nombre usuario:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(25, 647);
            label13.Name = "label13";
            label13.Size = new Size(86, 20);
            label13.TabIndex = 22;
            label13.Text = "Contraseña:";
            // 
            // nombreUsuario
            // 
            nombreUsuario.Location = new Point(142, 593);
            nombreUsuario.Margin = new Padding(3, 4, 3, 4);
            nombreUsuario.Name = "nombreUsuario";
            nombreUsuario.Size = new Size(236, 27);
            nombreUsuario.TabIndex = 23;
            // 
            // contraseniaUsuario
            // 
            contraseniaUsuario.Location = new Point(142, 643);
            contraseniaUsuario.Margin = new Padding(3, 4, 3, 4);
            contraseniaUsuario.Name = "contraseniaUsuario";
            contraseniaUsuario.Size = new Size(236, 27);
            contraseniaUsuario.TabIndex = 24;
            // 
            // CreateVeterinario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 827);
            Controls.Add(contraseniaUsuario);
            Controls.Add(nombreUsuario);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(especialidadVeterinario);
            Controls.Add(matriculaVeterinario);
            Controls.Add(dniVeterinario);
            Controls.Add(direccionVeterinario);
            Controls.Add(mailVeterinario);
            Controls.Add(telefonoVeterinario);
            Controls.Add(apellidoVeterinario);
            Controls.Add(nombreVeterinario);
            Controls.Add(cancelar);
            Controls.Add(guardar);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CreateVeterinario";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button guardar;
        private Button cancelar;
        private TextBox nombreVeterinario;
        private TextBox apellidoVeterinario;
        private TextBox telefonoVeterinario;
        private TextBox mailVeterinario;
        private TextBox direccionVeterinario;
        private TextBox dniVeterinario;
        private TextBox matriculaVeterinario;
        private TextBox especialidadVeterinario;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox nombreUsuario;
        private TextBox contraseniaUsuario;
    }
}
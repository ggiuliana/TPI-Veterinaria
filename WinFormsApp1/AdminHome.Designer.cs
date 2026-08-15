namespace WinFormsApp1
{
    partial class AdminHome
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
            Veterinarios = new Button();
            Medicamentos = new Button();
            Estudios = new Button();
            panelContenido = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(565, 9);
            label1.Name = "label1";
            label1.Size = new Size(223, 45);
            label1.TabIndex = 0;
            label1.Text = "Administrador";
            // 
            // Veterinarios
            // 
            Veterinarios.Location = new Point(47, 121);
            Veterinarios.Name = "Veterinarios";
            Veterinarios.Size = new Size(95, 38);
            Veterinarios.TabIndex = 1;
            Veterinarios.Text = "Veterinarios";
            Veterinarios.UseVisualStyleBackColor = true;
            Veterinarios.Click += VeterinariosCRUD_Click;
            // 
            // Medicamentos
            // 
            Medicamentos.Location = new Point(47, 195);
            Medicamentos.Name = "Medicamentos";
            Medicamentos.Size = new Size(95, 38);
            Medicamentos.TabIndex = 5;
            Medicamentos.Text = "Medicamentos";
            Medicamentos.UseVisualStyleBackColor = true;
            // 
            // Estudios
            // 
            Estudios.Location = new Point(47, 272);
            Estudios.Name = "Estudios";
            Estudios.Size = new Size(95, 38);
            Estudios.TabIndex = 6;
            Estudios.Text = "Estudios";
            Estudios.UseVisualStyleBackColor = true;
            // 
            // panelContenido
            // 
            panelContenido.Location = new Point(183, 78);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(605, 360);
            panelContenido.TabIndex = 7;
            // 
            // AdminHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenido);
            Controls.Add(Estudios);
            Controls.Add(Medicamentos);
            Controls.Add(Veterinarios);
            Controls.Add(label1);
            Name = "AdminHome";
            Text = "  ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Veterinarios;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button Medicamentos;
        private Button Estudios;
        private Panel panelContenido;
    }
}
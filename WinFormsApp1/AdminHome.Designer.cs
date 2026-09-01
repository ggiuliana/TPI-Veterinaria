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
            Veterinarios = new Button();
            Medicamentos = new Button();
            Estudios = new Button();
            panelContenido = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Veterinarios
            // 
            Veterinarios.Location = new Point(12, 56);
            Veterinarios.Name = "Veterinarios";
            Veterinarios.Size = new Size(95, 38);
            Veterinarios.TabIndex = 1;
            Veterinarios.Text = "Veterinarios";
            Veterinarios.UseVisualStyleBackColor = true;
            Veterinarios.Click += VeterinariosCRUD_Click;
            // 
            // Medicamentos
            // 
            Medicamentos.Location = new Point(113, 56);
            Medicamentos.Name = "Medicamentos";
            Medicamentos.Size = new Size(102, 38);
            Medicamentos.TabIndex = 5;
            Medicamentos.Text = "Medicamentos";
            Medicamentos.UseVisualStyleBackColor = true;
            // 
            // Estudios
            // 
            Estudios.Location = new Point(221, 57);
            Estudios.Name = "Estudios";
            Estudios.Size = new Size(95, 38);
            Estudios.TabIndex = 6;
            Estudios.Text = "Estudios";
            Estudios.UseVisualStyleBackColor = true;
            Estudios.Click += Estudios_Click;
            // 
            // panelContenido
            // 
            panelContenido.Location = new Point(0, 100);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(800, 352);
            panelContenido.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Estudios);
            panel1.Controls.Add(Medicamentos);
            panel1.Controls.Add(Veterinarios);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 95);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 0);
            label1.Name = "label1";
            label1.Size = new Size(223, 45);
            label1.TabIndex = 7;
            label1.Text = "Administrador";
            label1.Click += label1_Click;
            // 
            // AdminHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(panelContenido);
            Name = "AdminHome";
            Text = "  ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button Veterinarios;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button Medicamentos;
        private Button Estudios;
        private Panel panelContenido;
        private Panel panel1;
        private Label label1;
    }
}
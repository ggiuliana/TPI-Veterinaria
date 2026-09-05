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
            Estudios = new Button();
            panelContenido = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Veterinarios
            // 
            Veterinarios.BackColor = SystemColors.Control;
            Veterinarios.Cursor = Cursors.Hand;
            Veterinarios.FlatStyle = FlatStyle.Flat;
            Veterinarios.Location = new Point(9, 60);
            Veterinarios.Name = "Veterinarios";
            Veterinarios.Size = new Size(95, 38);
            Veterinarios.TabIndex = 1;
            Veterinarios.Text = "Veterinarios";
            Veterinarios.UseVisualStyleBackColor = false;
            Veterinarios.Click += VeterinariosCRUD_Click;
            // 
            // Estudios
            // 
            Estudios.BackColor = SystemColors.ButtonFace;
            Estudios.Cursor = Cursors.Hand;
            Estudios.FlatStyle = FlatStyle.Flat;
            Estudios.ForeColor = SystemColors.ControlText;
            Estudios.Location = new Point(113, 60);
            Estudios.Name = "Estudios";
            Estudios.Size = new Size(95, 38);
            Estudios.TabIndex = 6;
            Estudios.Text = "Estudios";
            Estudios.UseVisualStyleBackColor = false;
            Estudios.Click += Estudios_Click;
            // 
            // panelContenido
            // 
            panelContenido.BackColor = SystemColors.Control;
            panelContenido.Location = new Point(0, 93);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(800, 359);
            panelContenido.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(Veterinarios);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Estudios);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 92);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 4);
            label1.Name = "label1";
            label1.Size = new Size(199, 40);
            label1.TabIndex = 7;
            label1.Text = "Administrador";
            // 
            // AdminHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenido);
            Controls.Add(panel1);
            Name = "AdminHome";
            Text = "  ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Veterinarios;
        private Button Estudios;
        private Panel panelContenido;
        private Panel panel1;
        private Label label1;
    }
}
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
            LogOut = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Veterinarios
            // 
            Veterinarios.BackColor = SystemColors.Control;
            Veterinarios.Cursor = Cursors.Hand;
            Veterinarios.FlatStyle = FlatStyle.Flat;
            Veterinarios.Location = new Point(10, 85);
            Veterinarios.Margin = new Padding(3, 4, 3, 4);
            Veterinarios.Name = "Veterinarios";
            Veterinarios.Size = new Size(109, 31);
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
            Estudios.Location = new Point(129, 85);
            Estudios.Margin = new Padding(3, 4, 3, 4);
            Estudios.Name = "Estudios";
            Estudios.Size = new Size(109, 31);
            Estudios.TabIndex = 6;
            Estudios.Text = "Estudios";
            Estudios.UseVisualStyleBackColor = false;
            Estudios.Click += Estudios_Click;
            // 
            // panelContenido
            // 
            panelContenido.BackColor = SystemColors.Control;
            panelContenido.Location = new Point(0, 124);
            panelContenido.Margin = new Padding(3, 4, 3, 4);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(914, 479);
            panelContenido.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(LogOut);
            panel1.Controls.Add(Veterinarios);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Estudios);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 123);
            panel1.TabIndex = 8;
            // 
            // LogOut
            // 
            LogOut.BackColor = SystemColors.GradientActiveCaption;
            LogOut.Cursor = Cursors.Hand;
            LogOut.FlatStyle = FlatStyle.Popup;
            LogOut.ForeColor = SystemColors.ControlText;
            LogOut.Location = new Point(791, 82);
            LogOut.Margin = new Padding(3, 4, 3, 4);
            LogOut.Name = "LogOut";
            LogOut.Size = new Size(109, 29);
            LogOut.TabIndex = 8;
            LogOut.Text = "Cerrar Sesión";
            LogOut.UseVisualStyleBackColor = false;
            LogOut.Click += LogOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 5);
            label1.Name = "label1";
            label1.Size = new Size(257, 50);
            label1.TabIndex = 7;
            label1.Text = "Administrador";
            // 
            // AdminHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panelContenido);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button LogOut;
    }
}
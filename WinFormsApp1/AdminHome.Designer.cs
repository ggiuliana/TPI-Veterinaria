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
            menuStrip1 = new MenuStrip();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            veterinarioToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem1 = new ToolStripMenuItem();
            consultasToolStripMenuItem1 = new ToolStripMenuItem();
            estudiosToolStripMenuItem1 = new ToolStripMenuItem();
            medicamentosToolStripMenuItem1 = new ToolStripMenuItem();
            vacunasToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { veterinarioToolStripMenuItem, turnosToolStripMenuItem1, estudiosToolStripMenuItem1, medicamentosToolStripMenuItem1, vacunasToolStripMenuItem1, cerrarSesiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(981, 30);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(110, 24);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += LogOut_Click;
            // 
            // veterinarioToolStripMenuItem
            // 
            veterinarioToolStripMenuItem.Name = "veterinarioToolStripMenuItem";
            veterinarioToolStripMenuItem.Size = new Size(101, 24);
            veterinarioToolStripMenuItem.Text = "Veterinarios";
            veterinarioToolStripMenuItem.Click += VeterinariosToolStripMenuItem_Click;
            // 
            // turnosToolStripMenuItem1
            // 
            turnosToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { consultasToolStripMenuItem1 });
            turnosToolStripMenuItem1.Name = "turnosToolStripMenuItem1";
            turnosToolStripMenuItem1.Size = new Size(67, 24);
            turnosToolStripMenuItem1.Text = "Turnos";
            turnosToolStripMenuItem1.Click += TurnosToolStripMenuItem_Click;
            // 
            // consultasToolStripMenuItem1
            // 
            consultasToolStripMenuItem1.Name = "consultasToolStripMenuItem1";
            consultasToolStripMenuItem1.Size = new Size(224, 26);
            consultasToolStripMenuItem1.Text = "Consultas";
            consultasToolStripMenuItem1.Click += ConsultasToolStripMenuItem_Click;
            // 
            // estudiosToolStripMenuItem1
            // 
            estudiosToolStripMenuItem1.Name = "estudiosToolStripMenuItem1";
            estudiosToolStripMenuItem1.Size = new Size(78, 24);
            estudiosToolStripMenuItem1.Text = "Estudios";
            estudiosToolStripMenuItem1.Click += EstudiosToolStripMenuItem_Click;
            // 
            // medicamentosToolStripMenuItem1
            // 
            medicamentosToolStripMenuItem1.Name = "medicamentosToolStripMenuItem1";
            medicamentosToolStripMenuItem1.Size = new Size(121, 24);
            medicamentosToolStripMenuItem1.Text = "Medicamentos";
            medicamentosToolStripMenuItem1.Click += MedicamentosToolStripMenuItem_Click;
            // 
            // vacunasToolStripMenuItem1
            // 
            vacunasToolStripMenuItem1.Name = "vacunasToolStripMenuItem1";
            vacunasToolStripMenuItem1.Size = new Size(76, 24);
            vacunasToolStripMenuItem1.Text = "Vacunas";
            vacunasToolStripMenuItem1.Click += TiposDeVacunaToolStripMenuItem_Click;
            // 
            // AdminHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 632);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminHome";
            Text = "  AdminHome";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem veterinarioToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem1;
        private ToolStripMenuItem consultasToolStripMenuItem1;
        private ToolStripMenuItem estudiosToolStripMenuItem1;
        private ToolStripMenuItem medicamentosToolStripMenuItem1;
        private ToolStripMenuItem vacunasToolStripMenuItem1;
    }
}
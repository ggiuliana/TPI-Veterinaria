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
            vistaToolStripMenuItem = new ToolStripMenuItem();
            veterinariosToolStripMenuItem = new ToolStripMenuItem();
            estudiosToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { vistaToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(981, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // vistaToolStripMenuItem
            // 
            vistaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { veterinariosToolStripMenuItem, estudiosToolStripMenuItem });
            vistaToolStripMenuItem.Name = "vistaToolStripMenuItem";
            vistaToolStripMenuItem.Size = new Size(73, 24);
            vistaToolStripMenuItem.Text = "Gestión";
            // 
            // veterinariosToolStripMenuItem
            // 
            veterinariosToolStripMenuItem.Name = "veterinariosToolStripMenuItem";
            veterinariosToolStripMenuItem.Size = new Size(224, 26);
            veterinariosToolStripMenuItem.Text = "Veterinarios";
            veterinariosToolStripMenuItem.Click += VeterinariosToolStripMenuItem_Click;
            // 
            // estudiosToolStripMenuItem
            // 
            estudiosToolStripMenuItem.Name = "estudiosToolStripMenuItem";
            estudiosToolStripMenuItem.Size = new Size(224, 26);
            estudiosToolStripMenuItem.Text = "Estudios";
            estudiosToolStripMenuItem.Click += EstudiosToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(110, 24);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += LogOut_Click;
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
            Text = "  ";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem vistaToolStripMenuItem;
        private ToolStripMenuItem veterinariosToolStripMenuItem;
        private ToolStripMenuItem estudiosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}
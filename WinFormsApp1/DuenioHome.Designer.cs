namespace WinFormsApp1
{
    partial class DuenioHome
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
            sacarTurnoToolStripMenuItem = new ToolStripMenuItem();
            mascotaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sacarTurnoToolStripMenuItem, mascotaToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // sacarTurnoToolStripMenuItem
            // 
            sacarTurnoToolStripMenuItem.Name = "sacarTurnoToolStripMenuItem";
            sacarTurnoToolStripMenuItem.Size = new Size(79, 20);
            sacarTurnoToolStripMenuItem.Text = "Sacar turno";
            sacarTurnoToolStripMenuItem.Click += SacarTurnoToolStripMenuItem_Click;
            // 
            // mascotaToolStripMenuItem
            // 
            mascotaToolStripMenuItem.Name = "mascotaToolStripMenuItem";
            mascotaToolStripMenuItem.Size = new Size(69, 20);
            mascotaToolStripMenuItem.Text = "Mascotas";
            mascotaToolStripMenuItem.Click += MascotasToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(88, 20);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += LogOut_Click;
            // 
            // DuenioHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Name = "DuenioHome";
            Text = "DuenioHome";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem mascotaToolStripMenuItem;
        private ToolStripMenuItem sacarTurnoToolStripMenuItem;
    }
}
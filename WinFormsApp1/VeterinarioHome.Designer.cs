namespace WinFormsApp1
{
    partial class VeterinarioHome
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
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { vistaToolStripMenuItem, consultasToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // vistaToolStripMenuItem
            // 
            vistaToolStripMenuItem.Name = "vistaToolStripMenuItem";
            vistaToolStripMenuItem.Size = new Size(67, 24);
            vistaToolStripMenuItem.Text = "Turnos";
            vistaToolStripMenuItem.Click += TurnosToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(110, 24);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += LogOut_Click;
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(86, 24);
            consultasToolStripMenuItem.Text = "Consultas";
            consultasToolStripMenuItem.Click += ConsultasToolStripMenuItem_Click;
            // 
            // VeterinarioHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "VeterinarioHome";
            Text = "VeterinarioForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem vistaToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem consultasToolStripMenuItem;
    }
}
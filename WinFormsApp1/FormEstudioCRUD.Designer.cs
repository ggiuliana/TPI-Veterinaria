namespace WinFormsApp1
{
    partial class FormEstudioCRUD
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
            estudiocrud1 = new EstudioCRUD();
            SuspendLayout();
            // 
            // estudiocrud1
            // 
            estudiocrud1.Dock = DockStyle.Fill;
            estudiocrud1.Location = new Point(0, 0);
            estudiocrud1.Margin = new Padding(3, 4, 3, 4);
            estudiocrud1.Name = "estudiocrud1";
            estudiocrud1.Size = new Size(893, 467);
            estudiocrud1.TabIndex = 0;
            // 
            // FormEstudioCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 467);
            Controls.Add(estudiocrud1);
            Name = "FormEstudioCRUD";
            Text = "FormEstudioCRUD";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private EstudioCRUD estudiocrud1;
    }
}
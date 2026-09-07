namespace WinFormsApp1
{
    partial class FormVeterinarioCRUD
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
            veterinariocrud1 = new VeterinarioCRUD();
            SuspendLayout();
            // 
            // veterinariocrud1
            // 
            veterinariocrud1.Dock = DockStyle.Fill;
            veterinariocrud1.Location = new Point(0, 0);
            veterinariocrud1.Margin = new Padding(3, 4, 3, 4);
            veterinariocrud1.Name = "veterinariocrud1";
            veterinariocrud1.Size = new Size(897, 473);
            veterinariocrud1.TabIndex = 1;
            // 
            // FormVeterinarioCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 473);
            Controls.Add(veterinariocrud1);
            Name = "FormVeterinarioCRUD";
            Text = "FormVeterinarioCRUD";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion
        private VeterinarioCRUD veterinariocrud1;
    }
}
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
            veterinariocrud1.Name = "veterinariocrud1";
            veterinariocrud1.Size = new Size(1087, 544);
            veterinariocrud1.TabIndex = 1;
            veterinariocrud1.Load += veterinariocrud1_Load;
            // 
            // FormVeterinarioCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 544);
            Controls.Add(veterinariocrud1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormVeterinarioCRUD";
            Text = "FormVeterinarioCRUD";
            WindowState = FormWindowState.Maximized;
            Load += FormVeterinarioCRUD_Load_1;
            ResumeLayout(false);
        }

        #endregion
        private VeterinarioCRUD veterinariocrud1;
    }
}
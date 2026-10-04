namespace WinFormsApp1
{
    partial class FormSacarTurno
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
            mascotasComboBox = new ComboBox();
            label1 = new Label();
            Confirmar = new Button();
            SuspendLayout();
            // 
            // mascotasComboBox
            // 
            mascotasComboBox.FormattingEnabled = true;
            mascotasComboBox.Location = new Point(88, 120);
            mascotasComboBox.Name = "mascotasComboBox";
            mascotasComboBox.Size = new Size(249, 23);
            mascotasComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(154, 67);
            label1.Name = "label1";
            label1.Size = new Size(124, 30);
            label1.TabIndex = 1;
            label1.Text = "Turno para:";
            // 
            // Confirmar
            // 
            Confirmar.Location = new Point(142, 172);
            Confirmar.Name = "Confirmar";
            Confirmar.Size = new Size(141, 39);
            Confirmar.TabIndex = 2;
            Confirmar.Text = "Confirmar";
            Confirmar.UseVisualStyleBackColor = true;
            Confirmar.Click += Confirmar_Click;
            // 
            // FormSacarTurno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 283);
            Controls.Add(Confirmar);
            Controls.Add(label1);
            Controls.Add(mascotasComboBox);
            Name = "FormSacarTurno";
            Text = "Form1";
            Load += FormSacarTurno_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox mascotasComboBox;
        private Label label1;
        private Button Confirmar;
    }
}
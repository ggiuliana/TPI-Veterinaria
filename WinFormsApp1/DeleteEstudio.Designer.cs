namespace WinFormsApp1
{
    partial class DeleteEstudio
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
            SeleccionEstudio = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            Guardar = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // SeleccionEstudio
            // 
            SeleccionEstudio.FormattingEnabled = true;
            SeleccionEstudio.Location = new Point(78, 121);
            SeleccionEstudio.Name = "SeleccionEstudio";
            SeleccionEstudio.Size = new Size(202, 23);
            SeleccionEstudio.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(99, 77);
            label2.Name = "label2";
            label2.Size = new Size(160, 21);
            label2.TabIndex = 6;
            label2.Text = "Selecciona un Estudio";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.Location = new Point(68, 17);
            label1.Name = "label1";
            label1.Size = new Size(209, 30);
            label1.TabIndex = 5;
            label1.Text = "ELIMINAR ESTUDIO";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(35, 186);
            button1.Name = "button1";
            button1.Size = new Size(123, 39);
            button1.TabIndex = 40;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Cancelar_Click;
            // 
            // Guardar
            // 
            Guardar.BackColor = SystemColors.ActiveCaption;
            Guardar.Cursor = Cursors.Hand;
            Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Guardar.ForeColor = SystemColors.ControlText;
            Guardar.Location = new Point(187, 186);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(123, 39);
            Guardar.TabIndex = 39;
            Guardar.Text = "Eliminar";
            Guardar.UseVisualStyleBackColor = false;
            Guardar.Click += Aceptar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(Guardar);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(SeleccionEstudio);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 246);
            panel1.TabIndex = 41;
            // 
            // DeleteEstudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 263);
            Controls.Add(panel1);
            Name = "DeleteEstudio";
            Text = "DeleteEstudio";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Label label1;
        private ComboBox SeleccionEstudio;
        private Button button1;
        private Button Guardar;
        private Panel panel1;
    }
}
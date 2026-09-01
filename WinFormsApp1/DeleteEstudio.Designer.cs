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
            Cancelar = new Button();
            Aceptar = new Button();
            SeleccionEstudio = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ActiveCaption;
            Cancelar.Font = new Font("Segoe UI", 15.75F);
            Cancelar.Location = new Point(35, 268);
            Cancelar.Margin = new Padding(3, 4, 3, 4);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(152, 45);
            Cancelar.TabIndex = 9;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // Aceptar
            // 
            Aceptar.Font = new Font("Segoe UI", 15.75F);
            Aceptar.Location = new Point(242, 268);
            Aceptar.Margin = new Padding(3, 4, 3, 4);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(152, 45);
            Aceptar.TabIndex = 8;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // SeleccionEstudio
            // 
            SeleccionEstudio.FormattingEnabled = true;
            SeleccionEstudio.Location = new Point(107, 175);
            SeleccionEstudio.Margin = new Padding(3, 4, 3, 4);
            SeleccionEstudio.Name = "SeleccionEstudio";
            SeleccionEstudio.Size = new Size(230, 28);
            SeleccionEstudio.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(131, 116);
            label2.Name = "label2";
            label2.Size = new Size(201, 28);
            label2.TabIndex = 6;
            label2.Text = "Selecciona un Estudio";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(109, 36);
            label1.Name = "label1";
            label1.Size = new Size(238, 32);
            label1.TabIndex = 5;
            label1.Text = "ELIMINAR ESTUDIO";
            // 
            // DeleteEstudio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 351);
            Controls.Add(Cancelar);
            Controls.Add(Aceptar);
            Controls.Add(SeleccionEstudio);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DeleteEstudio";
            Text = "DeleteEstudio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Cancelar;
        private Button Aceptar;
        private ComboBox SeleccionVet;
        private Label label2;
        private Label label1;
        private ComboBox SeleccionEstudio;
    }
}
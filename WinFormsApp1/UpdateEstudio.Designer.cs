namespace WinFormsApp1
{
    partial class UpdateEstudio
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
            descripcionEstudio = new TextBox();
            nombreEstudio = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label3 = new Label();
            label2 = new Label();
            SeleccionEstudio = new ComboBox();
            label1 = new Label();
            Cancelar = new Button();
            Guardar = new Button();
            SuspendLayout();
            // 
            // descripcionEstudio
            // 
            descripcionEstudio.Location = new Point(115, 198);
            descripcionEstudio.Name = "descripcionEstudio";
            descripcionEstudio.Size = new Size(228, 23);
            descripcionEstudio.TabIndex = 36;
            // 
            // nombreEstudio
            // 
            nombreEstudio.Location = new Point(115, 163);
            nombreEstudio.Name = "nombreEstudio";
            nombreEstudio.Size = new Size(228, 23);
            nombreEstudio.TabIndex = 35;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(34, 201);
            label10.Name = "label10";
            label10.Size = new Size(72, 15);
            label10.TabIndex = 34;
            label10.Text = "Descripción:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(34, 166);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 33;
            label11.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 120);
            label3.Name = "label3";
            label3.Size = new Size(357, 20);
            label3.TabIndex = 32;
            label3.Text = "----------------------------------------------------------";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 84);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 31;
            label2.Text = "Estudio:";
            // 
            // SeleccionEstudio
            // 
            SeleccionEstudio.FormattingEnabled = true;
            SeleccionEstudio.Location = new Point(115, 85);
            SeleccionEstudio.Name = "SeleccionEstudio";
            SeleccionEstudio.Size = new Size(212, 23);
            SeleccionEstudio.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 24);
            label1.Name = "label1";
            label1.Size = new Size(225, 30);
            label1.TabIndex = 29;
            label1.Text = "MODIFICAR ESTUDIO";
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ControlLight;
            Cancelar.Cursor = Cursors.Hand;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(52, 260);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(123, 39);
            Cancelar.TabIndex = 38;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // Guardar
            // 
            Guardar.BackColor = SystemColors.ActiveCaption;
            Guardar.Cursor = Cursors.Hand;
            Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Guardar.ForeColor = SystemColors.ControlText;
            Guardar.Location = new Point(204, 260);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(123, 39);
            Guardar.TabIndex = 37;
            Guardar.Text = "Guardar";
            Guardar.UseVisualStyleBackColor = false;
            Guardar.Click += Guardar_Click;
            // 
            // UpdateEstudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 321);
            Controls.Add(Cancelar);
            Controls.Add(Guardar);
            Controls.Add(descripcionEstudio);
            Controls.Add(nombreEstudio);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(SeleccionEstudio);
            Controls.Add(label1);
            Name = "UpdateEstudio";
            Text = "UpdateEstudio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private Label label11;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button Cancelar;
        private Button Guardar;
        private ComboBox SeleccionEstudio;
        private TextBox nombreEstudio;
        private TextBox descripcionEstudio;
    }
}
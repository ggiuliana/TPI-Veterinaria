namespace WinFormsApp1
{
    partial class CreateEstudio
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Cancelar = new Button();
            Guardar = new Button();
            SuspendLayout();
            // 
            // descripcionEstudio
            // 
            descripcionEstudio.Location = new Point(114, 110);
            descripcionEstudio.Name = "descripcionEstudio";
            descripcionEstudio.Size = new Size(228, 23);
            descripcionEstudio.TabIndex = 19;
            // 
            // nombreEstudio
            // 
            nombreEstudio.Location = new Point(114, 75);
            nombreEstudio.Name = "nombreEstudio";
            nombreEstudio.Size = new Size(228, 23);
            nombreEstudio.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 113);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 16;
            label3.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 78);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 15;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(97, 24);
            label1.Name = "label1";
            label1.Size = new Size(180, 30);
            label1.TabIndex = 14;
            label1.Text = "NUEVO ESTUDIO";
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ControlLight;
            Cancelar.Cursor = Cursors.Hand;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(50, 173);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(123, 39);
            Cancelar.TabIndex = 40;
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
            Guardar.Location = new Point(202, 173);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(123, 39);
            Guardar.TabIndex = 39;
            Guardar.Text = "Guardar";
            Guardar.UseVisualStyleBackColor = false;
            Guardar.Click += Guardar_Click;
            // 
            // CreateEstudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 240);
            Controls.Add(Cancelar);
            Controls.Add(Guardar);
            Controls.Add(descripcionEstudio);
            Controls.Add(nombreEstudio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateEstudio";
            Text = "CreateEstudio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox telefonoVeterinario;
        private TextBox apellidoVeterinario;
        private TextBox nombreVeterinario;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox descripcionEstudio;
        private TextBox nombreEstudio;
        private Button Cancelar;
        private Button Guardar;
    }
}
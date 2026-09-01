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
            cancelar = new Button();
            guardar = new Button();
            SuspendLayout();
            // 
            // descripcionEstudio
            // 
            descripcionEstudio.Location = new Point(130, 147);
            descripcionEstudio.Margin = new Padding(3, 4, 3, 4);
            descripcionEstudio.Name = "descripcionEstudio";
            descripcionEstudio.Size = new Size(260, 27);
            descripcionEstudio.TabIndex = 19;
            // 
            // nombreEstudio
            // 
            nombreEstudio.Location = new Point(130, 100);
            nombreEstudio.Margin = new Padding(3, 4, 3, 4);
            nombreEstudio.Name = "nombreEstudio";
            nombreEstudio.Size = new Size(260, 27);
            nombreEstudio.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 151);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 16;
            label3.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 104);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 15;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(125, 32);
            label1.Name = "label1";
            label1.Size = new Size(203, 37);
            label1.TabIndex = 14;
            label1.Text = "Nuevo Estudio";
            // 
            // cancelar
            // 
            cancelar.BackColor = SystemColors.ActiveCaption;
            cancelar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelar.Location = new Point(67, 225);
            cancelar.Margin = new Padding(3, 4, 3, 4);
            cancelar.Name = "cancelar";
            cancelar.Size = new Size(141, 59);
            cancelar.TabIndex = 22;
            cancelar.Text = "Cancelar";
            cancelar.UseVisualStyleBackColor = false;
            cancelar.Click += Cancelar_Click;
            // 
            // guardar
            // 
            guardar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guardar.Location = new Point(235, 225);
            guardar.Margin = new Padding(3, 4, 3, 4);
            guardar.Name = "guardar";
            guardar.Size = new Size(126, 59);
            guardar.TabIndex = 21;
            guardar.Text = "Guardar";
            guardar.UseVisualStyleBackColor = true;
            guardar.Click += Guardar_Click;
            // 
            // CreateEstudio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 320);
            Controls.Add(cancelar);
            Controls.Add(guardar);
            Controls.Add(descripcionEstudio);
            Controls.Add(nombreEstudio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button cancelar;
        private Button guardar;
        private TextBox descripcionEstudio;
        private TextBox nombreEstudio;
    }
}
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
            label1.Location = new Point(109, 24);
            label1.Name = "label1";
            label1.Size = new Size(157, 30);
            label1.TabIndex = 14;
            label1.Text = "Nuevo Estudio";
            // 
            // cancelar
            // 
            cancelar.BackColor = SystemColors.AppWorkspace;
            cancelar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelar.Location = new Point(59, 169);
            cancelar.Name = "cancelar";
            cancelar.Size = new Size(110, 44);
            cancelar.TabIndex = 22;
            cancelar.Text = "Cancelar";
            cancelar.UseVisualStyleBackColor = false;
            // 
            // guardar
            // 
            guardar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guardar.Location = new Point(206, 169);
            guardar.Name = "guardar";
            guardar.Size = new Size(110, 44);
            guardar.TabIndex = 21;
            guardar.Text = "Guardar";
            guardar.UseVisualStyleBackColor = true;
            guardar.Click += guardar_Click_1;
            // 
            // CreateEstudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 240);
            Controls.Add(cancelar);
            Controls.Add(guardar);
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
        private Button cancelar;
        private Button guardar;
        private TextBox descripcionEstudio;
        private TextBox nombreEstudio;
    }
}
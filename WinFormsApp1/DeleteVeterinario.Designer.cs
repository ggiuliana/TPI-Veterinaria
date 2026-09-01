namespace WinFormsApp1
{
    partial class DeleteVeterinario
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
            label1 = new Label();
            label2 = new Label();
            SeleccionVet = new ComboBox();
            Aceptar = new Button();
            Cancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(85, 36);
            label1.Name = "label1";
            label1.Size = new Size(295, 32);
            label1.TabIndex = 0;
            label1.Text = "ELIMINAR VETERINARIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(107, 116);
            label2.Name = "label2";
            label2.Size = new Size(231, 28);
            label2.TabIndex = 1;
            label2.Text = "Selecciona un Veterinario";
            // 
            // SeleccionVet
            // 
            SeleccionVet.FormattingEnabled = true;
            SeleccionVet.Location = new Point(107, 175);
            SeleccionVet.Margin = new Padding(3, 4, 3, 4);
            SeleccionVet.Name = "SeleccionVet";
            SeleccionVet.Size = new Size(230, 28);
            SeleccionVet.TabIndex = 2;
            // 
            // Aceptar
            // 
            Aceptar.Font = new Font("Segoe UI", 15.75F);
            Aceptar.Location = new Point(242, 268);
            Aceptar.Margin = new Padding(3, 4, 3, 4);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(152, 45);
            Aceptar.TabIndex = 3;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ActiveCaption;
            Cancelar.Font = new Font("Segoe UI", 15.75F);
            Cancelar.Location = new Point(35, 268);
            Cancelar.Margin = new Padding(3, 4, 3, 4);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(152, 45);
            Cancelar.TabIndex = 4;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // DeleteVeterinario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 351);
            Controls.Add(Cancelar);
            Controls.Add(Aceptar);
            Controls.Add(SeleccionVet);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DeleteVeterinario";
            Text = "Form1";
            Load += DeleteVeterinario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox SeleccionVet;
        private Button Aceptar;
        private Button Cancelar;
    }
}
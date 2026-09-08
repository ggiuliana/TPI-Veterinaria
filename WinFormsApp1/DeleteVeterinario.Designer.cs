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
            Cancelar = new Button();
            Guardar = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.Location = new Point(55, 12);
            label1.Name = "label1";
            label1.Size = new Size(259, 30);
            label1.TabIndex = 0;
            label1.Text = "ELIMINAR VETERINARIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(90, 72);
            label2.Name = "label2";
            label2.Size = new Size(185, 21);
            label2.TabIndex = 1;
            label2.Text = "Selecciona un Veterinario";
            // 
            // SeleccionVet
            // 
            SeleccionVet.FormattingEnabled = true;
            SeleccionVet.Location = new Point(90, 116);
            SeleccionVet.Name = "SeleccionVet";
            SeleccionVet.Size = new Size(202, 23);
            SeleccionVet.TabIndex = 2;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ControlLight;
            Cancelar.Cursor = Cursors.Hand;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(47, 177);
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
            Guardar.Location = new Point(199, 177);
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
            panel1.Controls.Add(Cancelar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(SeleccionVet);
            panel1.Location = new Point(12, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(378, 230);
            panel1.TabIndex = 41;
            // 
            // DeleteVeterinario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 263);
            Controls.Add(panel1);
            Name = "DeleteVeterinario";
            Text = "Form1";
            Load += DeleteVeterinario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox SeleccionVet;
        private Button Cancelar;
        private Button Guardar;
        private Panel panel1;
    }
}
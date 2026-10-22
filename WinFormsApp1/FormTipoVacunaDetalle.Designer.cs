namespace WinFormsApp1
{
    partial class FormTipoVacunaDetalle
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
            panel1 = new Panel();
            Guardar = new Button();
            Cancelar = new Button();
            lblTitulo = new Label();
            label2 = new Label();
            descripcionTipoVacuna = new TextBox();
            label3 = new Label();
            nombreTipoVacuna = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(Guardar);
            panel1.Controls.Add(Cancelar);
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(descripcionTipoVacuna);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nombreTipoVacuna);
            panel1.Location = new Point(13, 29);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(440, 288);
            panel1.TabIndex = 42;
            // 
            // Guardar
            // 
            Guardar.BackColor = SystemColors.ActiveCaption;
            Guardar.Cursor = Cursors.Hand;
            Guardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Guardar.ForeColor = SystemColors.ControlText;
            Guardar.Location = new Point(239, 215);
            Guardar.Margin = new Padding(3, 4, 3, 4);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(141, 52);
            Guardar.TabIndex = 39;
            Guardar.Text = "Guardar";
            Guardar.UseVisualStyleBackColor = false;
            Guardar.Click += Guardar_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = SystemColors.ControlLight;
            Cancelar.Cursor = Cursors.Hand;
            Cancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cancelar.Location = new Point(65, 215);
            Cancelar.Margin = new Padding(3, 4, 3, 4);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(141, 52);
            Cancelar.TabIndex = 40;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += Cancelar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(119, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(0, 37);
            lblTitulo.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 88);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 15;
            label2.Text = "Nombre:";
            // 
            // descripcionTipoVacuna
            // 
            descripcionTipoVacuna.Location = new Point(138, 131);
            descripcionTipoVacuna.Margin = new Padding(3, 4, 3, 4);
            descripcionTipoVacuna.Name = "descripcionTipoVacuna";
            descripcionTipoVacuna.Size = new Size(260, 27);
            descripcionTipoVacuna.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 135);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 16;
            label3.Text = "Descripción:";
            // 
            // nombreTipoVacuna
            // 
            nombreTipoVacuna.Location = new Point(138, 84);
            nombreTipoVacuna.Margin = new Padding(3, 4, 3, 4);
            nombreTipoVacuna.Name = "nombreTipoVacuna";
            nombreTipoVacuna.Size = new Size(260, 27);
            nombreTipoVacuna.TabIndex = 18;
            // 
            // FormTipoVacunaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 347);
            Controls.Add(panel1);
            Name = "FormTipoVacunaDetalle";
            Text = "FormTipoVacunaDetalle";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Guardar;
        private Button Cancelar;
        private Label lblTitulo;
        private Label label2;
        private TextBox descripcionTipoVacuna;
        private Label label3;
        private TextBox nombreTipoVacuna;
    }
}
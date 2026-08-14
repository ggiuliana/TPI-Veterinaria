namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Título = new Label();
            label1 = new Label();
            label2 = new Label();
            nombreusuario = new TextBox();
            contrasenia = new TextBox();
            ingreso = new Button();
            SuspendLayout();
            // 
            // Título
            // 
            Título.AutoSize = true;
            Título.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Título.Location = new Point(81, 40);
            Título.Name = "Título";
            Título.Size = new Size(238, 47);
            Título.TabIndex = 0;
            Título.Text = "Iniciar Sesión";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 127);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 1;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(57, 222);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 2;
            label2.Text = "Contraseña";
            // 
            // nombreusuario
            // 
            nombreusuario.Location = new Point(57, 151);
            nombreusuario.Name = "nombreusuario";
            nombreusuario.Size = new Size(281, 23);
            nombreusuario.TabIndex = 3;
            // 
            // contrasenia
            // 
            contrasenia.Location = new Point(57, 246);
            contrasenia.Name = "contrasenia";
            contrasenia.PasswordChar = '*';
            contrasenia.Size = new Size(281, 23);
            contrasenia.TabIndex = 4;
            // 
            // ingreso
            // 
            ingreso.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ingreso.Location = new Point(139, 332);
            ingreso.Name = "ingreso";
            ingreso.Size = new Size(117, 46);
            ingreso.TabIndex = 5;
            ingreso.Text = "Ingresar";
            ingreso.UseVisualStyleBackColor = true;
            ingreso.Click += IngresoClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 450);
            Controls.Add(ingreso);
            Controls.Add(contrasenia);
            Controls.Add(nombreusuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Título);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Título;
        private Label label1;
        private Label label2;
        private TextBox nombreusuario;
        private TextBox contrasenia;
        private Button ingreso;        
    }
}

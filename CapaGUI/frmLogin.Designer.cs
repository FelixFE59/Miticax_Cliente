namespace CapaGUI
{
    partial class frmLogin
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
            pictureLogin = new PictureBox();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnRegistrar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureLogin).BeginInit();
            SuspendLayout();
            // 
            // pictureLogin
            // 
            pictureLogin.Image = Properties.Resources.login;
            pictureLogin.InitialImage = Properties.Resources.login;
            pictureLogin.Location = new Point(-8, 1);
            pictureLogin.Name = "pictureLogin";
            pictureLogin.Size = new Size(1051, 550);
            pictureLogin.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLogin.TabIndex = 1;
            pictureLogin.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(152, 25);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(219, 23);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(152, 66);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(219, 23);
            txtContraseña.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 27);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 4;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(40, 68);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 5;
            label2.Text = "Contraseña";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(92, 122);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(175, 57);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(92, 200);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(175, 57);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 521);
            Controls.Add(btnRegistrar);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(pictureLogin);
            Name = "frmLogin";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureLogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private PictureBox pictureLogin;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Label label1;
        private Label label2;
        private Button btnRegistrar;
    }
}
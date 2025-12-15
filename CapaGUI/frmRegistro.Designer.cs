namespace CapaGUI
{
    partial class frmRegistro
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
            pictureBox1 = new PictureBox();
            btnRegistrar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUsuario = new TextBox();
            txtNombre = new TextBox();
            txtContraseña = new TextBox();
            dtpFecha = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 287);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(89, 194);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(177, 64);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 96);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 4;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 139);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 5;
            label4.Text = "Fecha de nacimiento";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(143, 49);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(223, 23);
            txtUsuario.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(143, 11);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(223, 23);
            txtNombre.TabIndex = 7;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(143, 88);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(223, 23);
            txtContraseña.TabIndex = 8;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(143, 131);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(223, 23);
            dtpFecha.TabIndex = 9;
            // 
            // frmRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 284);
            Controls.Add(dtpFecha);
            Controls.Add(txtContraseña);
            Controls.Add(txtNombre);
            Controls.Add(txtUsuario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegistrar);
            Controls.Add(pictureBox1);
            Name = "frmRegistro";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnRegistrar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtUsuario;
        private TextBox txtNombre;
        private TextBox txtContraseña;
        private DateTimePicker dtpFecha;
    }
}
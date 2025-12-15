namespace CapaGUI
{
    partial class frmEquipo
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
            label2 = new Label();
            label1 = new Label();
            btnRegistrar = new Button();
            dgvEquipos = new DataGridView();
            label5 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnAtras = new Button();
            cmbCriatura1 = new ComboBox();
            cmbCriatura2 = new ComboBox();
            cmbCriatura3 = new ComboBox();
            txtNombre = new TextBox();
            label4 = new Label();
            txtJugador = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 243);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 54;
            label2.Text = "ID de la primera criatura";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 30);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 53;
            label1.Text = " Jugador";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(119, 343);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(284, 92);
            btnRegistrar.TabIndex = 52;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // dgvEquipos
            // 
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.AllowUserToDeleteRows = false;
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(531, 22);
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.ReadOnly = true;
            dgvEquipos.Size = new Size(566, 539);
            dgvEquipos.TabIndex = 51;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(213, 180);
            label5.Name = "label5";
            label5.Size = new Size(132, 15);
            label5.TabIndex = 67;
            label5.Text = "Criaturas para el equipo";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(89, 273);
            label8.Name = "label8";
            label8.Size = new Size(137, 15);
            label8.TabIndex = 68;
            label8.Text = "ID de la segunda criatura";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(89, 305);
            label9.Name = "label9";
            label9.Size = new Size(128, 15);
            label9.TabIndex = 69;
            label9.Text = "ID de la tercera criatura";
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(12, 529);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(152, 42);
            btnAtras.TabIndex = 72;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // cmbCriatura1
            // 
            cmbCriatura1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriatura1.FormattingEnabled = true;
            cmbCriatura1.Location = new Point(253, 235);
            cmbCriatura1.Name = "cmbCriatura1";
            cmbCriatura1.Size = new Size(229, 23);
            cmbCriatura1.TabIndex = 76;
            // 
            // cmbCriatura2
            // 
            cmbCriatura2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriatura2.FormattingEnabled = true;
            cmbCriatura2.Location = new Point(253, 265);
            cmbCriatura2.Name = "cmbCriatura2";
            cmbCriatura2.Size = new Size(229, 23);
            cmbCriatura2.TabIndex = 77;
            // 
            // cmbCriatura3
            // 
            cmbCriatura3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriatura3.FormattingEnabled = true;
            cmbCriatura3.Location = new Point(253, 297);
            cmbCriatura3.Name = "cmbCriatura3";
            cmbCriatura3.Size = new Size(229, 23);
            cmbCriatura3.TabIndex = 78;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(259, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(229, 23);
            txtNombre.TabIndex = 80;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 80);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 79;
            label4.Text = "Nombre del equipo";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txtJugador
            // 
            txtJugador.Location = new Point(259, 27);
            txtJugador.Name = "txtJugador";
            txtJugador.ReadOnly = true;
            txtJugador.Size = new Size(229, 23);
            txtJugador.TabIndex = 81;
            // 
            // frmEquipo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 583);
            Controls.Add(txtJugador);
            Controls.Add(txtNombre);
            Controls.Add(label4);
            Controls.Add(cmbCriatura3);
            Controls.Add(cmbCriatura2);
            Controls.Add(cmbCriatura1);
            Controls.Add(btnAtras);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegistrar);
            Controls.Add(dgvEquipos);
            Name = "frmEquipo";
            Text = "Gestion de equipos";
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Button btnRegistrar;
        private DataGridView dgvEquipos;
        private Label label5;
        private Label label8;
        private Label label9;
        private Button btnAtras;
        private ComboBox cmbCriatura1;
        private ComboBox cmbCriatura2;
        private ComboBox cmbCriatura3;
        private TextBox txtNombre;
        private Label label4;
        private TextBox txtJugador;
    }
}
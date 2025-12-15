namespace CapaGUI
{
    partial class frmBatallas
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
            dgvBatallas = new DataGridView();
            label3 = new Label();
            btnRegistrar = new Button();
            btnAtras = new Button();
            cmbEquipos = new ComboBox();
            btnCancelar = new Button();
            lblEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBatallas).BeginInit();
            SuspendLayout();
            // 
            // dgvBatallas
            // 
            dgvBatallas.AllowUserToAddRows = false;
            dgvBatallas.AllowUserToDeleteRows = false;
            dgvBatallas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBatallas.Location = new Point(440, 2);
            dgvBatallas.Name = "dgvBatallas";
            dgvBatallas.ReadOnly = true;
            dgvBatallas.Size = new Size(867, 530);
            dgvBatallas.TabIndex = 44;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 97);
            label3.Name = "label3";
            label3.Size = new Size(149, 15);
            label3.TabIndex = 49;
            label3.Text = "ID del equipo del jugador 1";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(112, 168);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(198, 63);
            btnRegistrar.TabIndex = 55;
            btnRegistrar.Text = "Buscar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(12, 490);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(152, 42);
            btnAtras.TabIndex = 60;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // cmbEquipos
            // 
            cmbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquipos.FormattingEnabled = true;
            cmbEquipos.Location = new Point(137, 129);
            cmbEquipos.Name = "cmbEquipos";
            cmbEquipos.Size = new Size(145, 23);
            cmbEquipos.TabIndex = 62;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(112, 237);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(198, 63);
            btnCancelar.TabIndex = 63;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(185, 49);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 64;
            lblEstado.Text = "Estado";
            // 
            // frmBatallas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 536);
            Controls.Add(lblEstado);
            Controls.Add(btnCancelar);
            Controls.Add(cmbEquipos);
            Controls.Add(btnAtras);
            Controls.Add(btnRegistrar);
            Controls.Add(label3);
            Controls.Add(dgvBatallas);
            Name = "frmBatallas";
            Text = "Interfaz de gestion de batallas";
            ((System.ComponentModel.ISupportInitialize)dgvBatallas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvBatallas;
        private Label label3;
        private Button btnRegistrar;
        private Button btnAtras;
        private ComboBox cmbEquipos;
        private Button btnCancelar;
        private Label lblEstado;
    }
}
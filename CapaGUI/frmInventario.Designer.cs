namespace CapaGUI
{
    partial class frmInventario
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
            dgvInventario = new DataGridView();
            txtPoder = new TextBox();
            label = new Label();
            txtCosto = new TextBox();
            txtCristales = new TextBox();
            txtNivel = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblJugador = new Label();
            btnComprar = new Button();
            txtResistencia = new TextBox();
            label6 = new Label();
            btnAtras = new Button();
            cmbCriaturas = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(487, 3);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.Size = new Size(566, 539);
            dgvInventario.TabIndex = 0;
            // 
            // txtPoder
            // 
            txtPoder.Location = new Point(244, 243);
            txtPoder.Name = "txtPoder";
            txtPoder.ReadOnly = true;
            txtPoder.Size = new Size(146, 23);
            txtPoder.TabIndex = 48;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(102, 251);
            label.Name = "label";
            label.Size = new Size(109, 15);
            label.TabIndex = 47;
            label.Text = "Poder de la criatura";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(233, 153);
            txtCosto.Name = "txtCosto";
            txtCosto.ReadOnly = true;
            txtCosto.Size = new Size(229, 23);
            txtCosto.TabIndex = 46;
            // 
            // txtCristales
            // 
            txtCristales.Location = new Point(18, 153);
            txtCristales.Name = "txtCristales";
            txtCristales.ReadOnly = true;
            txtCristales.Size = new Size(182, 23);
            txtCristales.TabIndex = 45;
            // 
            // txtNivel
            // 
            txtNivel.Location = new Point(216, 218);
            txtNivel.Name = "txtNivel";
            txtNivel.ReadOnly = true;
            txtNivel.Size = new Size(146, 23);
            txtNivel.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(303, 135);
            label7.Name = "label7";
            label7.Size = new Size(109, 15);
            label7.TabIndex = 42;
            label7.Text = "Costo de la criatura";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 226);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 40;
            label4.Text = "Nivel de la criatura";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 135);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 39;
            label3.Text = "Cristales totales";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 70);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 38;
            label2.Text = "Criatura";
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.Location = new Point(186, 22);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(81, 15);
            lblJugador.TabIndex = 37;
            lblJugador.Text = "ID del jugador";
            lblJugador.TextAlign = ContentAlignment.TopRight;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(78, 317);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(284, 92);
            btnComprar.TabIndex = 36;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // txtResistencia
            // 
            txtResistencia.Location = new Point(244, 270);
            txtResistencia.Name = "txtResistencia";
            txtResistencia.ReadOnly = true;
            txtResistencia.Size = new Size(146, 23);
            txtResistencia.TabIndex = 50;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 278);
            label6.Name = "label6";
            label6.Size = new Size(136, 15);
            label6.TabIndex = 49;
            label6.Text = "Resistencia de la criatura";
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(12, 491);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(152, 42);
            btnAtras.TabIndex = 51;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // cmbCriaturas
            // 
            cmbCriaturas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriaturas.FormattingEnabled = true;
            cmbCriaturas.Location = new Point(215, 72);
            cmbCriaturas.Name = "cmbCriaturas";
            cmbCriaturas.Size = new Size(229, 23);
            cmbCriaturas.TabIndex = 52;
            cmbCriaturas.SelectedIndexChanged += cmbCriaturas_SelectedIndexChanged;
            // 
            // frmInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 545);
            Controls.Add(cmbCriaturas);
            Controls.Add(btnAtras);
            Controls.Add(txtResistencia);
            Controls.Add(label6);
            Controls.Add(txtPoder);
            Controls.Add(label);
            Controls.Add(txtCosto);
            Controls.Add(txtCristales);
            Controls.Add(txtNivel);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblJugador);
            Controls.Add(btnComprar);
            Controls.Add(dgvInventario);
            Name = "frmInventario";
            Text = "Gestion de inventarios";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvInventario;
        private TextBox txtPoder;
        private Label label;
        private TextBox txtCosto;
        private TextBox txtCristales;
        private TextBox txtNivel;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnComprar;
        private TextBox txtResistencia;
        private Label label6;
        private Button btnAtras;
        private ComboBox cmbCriaturas;
        private TextBox txtJugador;
        private Label lblJugador;
    }
}
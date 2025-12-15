namespace CapaGUI
{
    partial class frmRondas
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
            btnSiguiente = new Button();
            dgvRondas = new DataGridView();
            txtIDBatalla = new TextBox();
            lblTitulo = new Label();
            lblEstado = new Label();
            lblResultado = new Label();
            lblDefensor = new Label();
            lblAtacante = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRondas).BeginInit();
            SuspendLayout();
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(398, 377);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(256, 102);
            btnSiguiente.TabIndex = 0;
            btnSiguiente.Text = "Siguiente ronda";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // dgvRondas
            // 
            dgvRondas.AllowUserToAddRows = false;
            dgvRondas.AllowUserToDeleteRows = false;
            dgvRondas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRondas.Location = new Point(1, 6);
            dgvRondas.Name = "dgvRondas";
            dgvRondas.ReadOnly = true;
            dgvRondas.Size = new Size(374, 482);
            dgvRondas.TabIndex = 1;
            // 
            // txtIDBatalla
            // 
            txtIDBatalla.Location = new Point(523, 26);
            txtIDBatalla.Name = "txtIDBatalla";
            txtIDBatalla.Size = new Size(131, 23);
            txtIDBatalla.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(404, 29);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(38, 15);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Titulo";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(404, 59);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Estado";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(404, 93);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(59, 15);
            lblResultado.TabIndex = 6;
            lblResultado.Text = "Resultado";
            // 
            // lblDefensor
            // 
            lblDefensor.AutoSize = true;
            lblDefensor.Location = new Point(404, 320);
            lblDefensor.Name = "lblDefensor";
            lblDefensor.Size = new Size(54, 15);
            lblDefensor.TabIndex = 7;
            lblDefensor.Text = "Defensor";
            // 
            // lblAtacante
            // 
            lblAtacante.AutoSize = true;
            lblAtacante.Location = new Point(567, 320);
            lblAtacante.Name = "lblAtacante";
            lblAtacante.Size = new Size(54, 15);
            lblAtacante.TabIndex = 8;
            lblAtacante.Text = "Atacante";
            // 
            // frmRondas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 491);
            Controls.Add(lblAtacante);
            Controls.Add(lblDefensor);
            Controls.Add(lblResultado);
            Controls.Add(lblEstado);
            Controls.Add(lblTitulo);
            Controls.Add(txtIDBatalla);
            Controls.Add(dgvRondas);
            Controls.Add(btnSiguiente);
            Name = "frmRondas";
            Text = "Gestion de rondas";
            ((System.ComponentModel.ISupportInitialize)dgvRondas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSiguiente;
        private DataGridView dgvRondas;
        private TextBox txtIDBatalla;
        private Label lblTitulo;
        private Label lblEstado;
        private Label lblResultado;
        private Label lblDefensor;
        private Label lblAtacante;
    }
}
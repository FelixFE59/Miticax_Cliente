namespace CapaGUI
{
    partial class frmPrincipal
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
            btnInventario = new Button();
            btnEquipo = new Button();
            btnBatallas = new Button();
            btnTOP = new Button();
            lblJugador = new Label();
            SuspendLayout();
            // 
            // btnInventario
            // 
            btnInventario.Location = new Point(86, 66);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(622, 94);
            btnInventario.TabIndex = 2;
            btnInventario.Text = "Registro de inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnEquipo
            // 
            btnEquipo.Location = new Point(86, 202);
            btnEquipo.Name = "btnEquipo";
            btnEquipo.Size = new Size(622, 94);
            btnEquipo.TabIndex = 3;
            btnEquipo.Text = "Registro de Equipos";
            btnEquipo.UseVisualStyleBackColor = true;
            btnEquipo.Click += btnEquipo_Click;
            // 
            // btnBatallas
            // 
            btnBatallas.Location = new Point(89, 350);
            btnBatallas.Name = "btnBatallas";
            btnBatallas.Size = new Size(622, 94);
            btnBatallas.TabIndex = 4;
            btnBatallas.Text = "Registro de batallas y rondas";
            btnBatallas.UseVisualStyleBackColor = true;
            btnBatallas.Click += btnBatallas_Click;
            // 
            // btnTOP
            // 
            btnTOP.Location = new Point(89, 504);
            btnTOP.Name = "btnTOP";
            btnTOP.Size = new Size(622, 94);
            btnTOP.TabIndex = 5;
            btnTOP.Text = "Top ganadores";
            btnTOP.UseVisualStyleBackColor = true;
            btnTOP.Click += btnTOP_Click;
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.Location = new Point(20, 20);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(49, 15);
            lblJugador.TabIndex = 6;
            lblJugador.Text = "Jugador";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 610);
            Controls.Add(lblJugador);
            Controls.Add(btnTOP);
            Controls.Add(btnBatallas);
            Controls.Add(btnEquipo);
            Controls.Add(btnInventario);
            Name = "frmPrincipal";
            Text = "Interfaz Principal";
            Load += frmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnInventario;
        private Button btnEquipo;
        private Button btnBatallas;
        private Button btnTOP;
        private Label lblJugador;
    }
}
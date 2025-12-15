namespace CapaGUI
{
    partial class frmTopGanadores
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
            dgvTop = new DataGridView();
            btnAtras = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTop).BeginInit();
            SuspendLayout();
            // 
            // dgvTop
            // 
            dgvTop.AllowUserToAddRows = false;
            dgvTop.AllowUserToDeleteRows = false;
            dgvTop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop.Location = new Point(12, 12);
            dgvTop.Name = "dgvTop";
            dgvTop.ReadOnly = true;
            dgvTop.Size = new Size(776, 373);
            dgvTop.TabIndex = 0;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(287, 391);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(206, 50);
            btnAtras.TabIndex = 1;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // frmTopGanadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAtras);
            Controls.Add(dgvTop);
            Name = "frmTopGanadores";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTop;
        private Button btnAtras;
    }
}
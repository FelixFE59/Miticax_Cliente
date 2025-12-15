/*
 * Universidad Estatal a Distancia (UNED)
 * II Cuatrimestre
 * Proyecto 2 - MITICAX Juego
 * Como continuación del anterior proyecto, esta entrega consiste en un programa basado en la comunicación cliente servidor
 * donde se implementan sockets para permitir a los jugadores conectarse a un servidor centralizado y así poder mantener
 * controlado todo el ambiente.
 * Félix Rios Prado
 * 6/10/2025
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener y validar entradas de usuario
                string Nombre = txtNombre.Text.Trim();
                string Usuario = txtUsuario.Text.Trim();
                string Contraseña = txtContraseña.Text.Trim();
                DateTime Fecha = dtpFecha.Value;
                if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Contraseña))
                {
                    throw new ArgumentException("Por favor, complete todos los campos.", "Advertencia");
                }

                // Registrar nuevo jugador en la base de datos
                CapaAccesoDatos.JugadorDAL.RegistrarJugador(Nombre, Usuario, Contraseña, Fecha);
                MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Volver al formulario de login
                var frm = new frmLogin();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

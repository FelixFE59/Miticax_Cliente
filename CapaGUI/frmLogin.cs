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

using CapaAccesoDatos;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener y validar entradas de usuario
                string Usuario = txtUsuario.Text.Trim();
                string Password = txtContraseña.Text.Trim();

                if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Password))
                {
                    throw new ArgumentException("Por favor, complete todos los campos.", "Advertencia");
                }

                // Autenticar jugador con sus credenciales
                var Jugador = CapaAccesoDatos.JugadorDAL.AutenticarJugador(Usuario, Password);

                // Verificar si la autenticación fue exitosa
                if (Jugador == null)
                {
                    throw new ArgumentException("Usuario o contraseña incorrectos.", "Error de autenticación");
                }

                // Establecer la sesión actual con los datos del jugador autenticado
                SesionActual.IDJugador = Jugador.IDJugador;
                SesionActual.NombreJugador = Jugador.Nombre;
                SesionActual.Usuario = Jugador.Usuario;
                SesionActual.Nivel = Jugador.Nivel;
                

                MessageBox.Show($"Bienvenido, {Jugador.Nombre}!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario principal y ocultar el de login
                var frm = new frmPrincipal();
                frm.Show();
                this.Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var frm = new frmRegistro();
            frm.Show();
            this.Hide();
        }
    }
}

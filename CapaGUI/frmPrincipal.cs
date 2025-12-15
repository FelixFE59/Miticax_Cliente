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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

            lblJugador.Text = $"Jugador: {SesionActual.NombreJugador}... Nivel: {SesionActual.Nivel}";
        }

        // Botones para navegar entre formularios

        // Ir a registro de inventarios
        private void btnInventario_Click(object sender, EventArgs e)
        {
            var frm = new frmInventario();
            frm.Show();
            this.Hide();
        }

        // Ir a registro de equipos
        private void btnEquipo_Click(object sender, EventArgs e)
        {

            var frm = new frmEquipo();
            frm.Show();
            this.Hide();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }


        // Ir a registro de batallas
        private void btnBatallas_Click(object sender, EventArgs e)
        {

            var frm = new frmBatallas();
            frm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTOP_Click(object sender, EventArgs e)
        {
            var frm = new frmTopGanadores();
            frm.Show();
            this.Hide();
        }
    }




}

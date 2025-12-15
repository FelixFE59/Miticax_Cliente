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
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//======================FALLANDO=========================

namespace CapaGUI
{
    public partial class frmRondas : Form
    {
        private int IDBatalla;
        private int IDEquipo1;
        private int IDEquipo2;
        private string NombreOponente;
        private int RondaActual = 0;

        //Argumentos cargados desde frmBatallas
        public frmRondas(int IDBatalla, int IDEquipo1, int IDEquipo2, string NombreOponente)
        {
            InitializeComponent();

            // Verificar que el oponente no sea el mismo jugador
            if (NombreOponente == SesionActual.NombreJugador)
            {
                MessageBox.Show(
                    "Error: No puedes jugar contra ti mismo. Cerrando batalla.",
                    "Error de Emparejamiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                // Cerrar inmediatamente
                this.Close();
                return;
            }

            // Asignar valores a variables de instancia
            this.IDBatalla = IDBatalla;
            this.IDEquipo1 = IDEquipo1;
            this.IDEquipo2 = IDEquipo2;
            this.NombreOponente = NombreOponente;

            // Configurar la interfaz del formulario
            lblTitulo.Text = $"Batalla #{IDBatalla}";
            lblDefensor.Text = $"👤 {SesionActual.NombreJugador}";
            lblAtacante.Text = $"🧝 {NombreOponente}";

            // Configurar columnas del DataGridView
            dgvRondas.Columns.Add("Ronda", "Ronda");
            dgvRondas.Columns.Add("CriaturaJ1", "Criatura Jugador");
            dgvRondas.Columns.Add("CriaturaJ2", "Criatura Oponente");
            dgvRondas.Columns.Add("Ganador", "Ganador");
            dgvRondas.Columns.Add("Estado", "Estado");

            lblEstado.Text = "Listo para iniciar la batalla...";
            lblResultado.Text = "";

            dgvRondas.ReadOnly = true;
            dgvRondas.AllowUserToAddRows = false;
            dgvRondas.RowHeadersVisible = false;
            dgvRondas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        // Método para actualizar rondas

        private void btnAtras_Click(object sender, EventArgs e)
        {
            var frm = new frmBatallas();
            frm.Show();
            this.Hide();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                // Ejecutar la siguiente ronda
                RondaActual++;
                lblEstado.Text = $"Ejecutando ronda {RondaActual}...";

                // Llamar al método DAL para registrar la ronda y obtener el resultado
                var resultado = RondaDAL.RegistrarRonda(IDBatalla, IDEquipo1, IDEquipo2);

                // Actualizar la tabla con los resultados de la ronda
                dgvRondas.Rows.Add(
                    RondaActual,
                    resultado.CriaturaAtacante,
                    resultado.CriaturaDefensora,
                    resultado.NombreGanador,
                    resultado.FinBatalla ? "Finalizada" : "En curso"
                );

                // Actualizar etiquetas con el resultado
                lblResultado.Text = $"Ganador de la ronda: {resultado.NombreGanador}";

                // Verificar si la batalla ha finalizado
                if (resultado.FinBatalla)
                {
                    // Deshabilitar el botón para evitar más rondas
                    lblEstado.Text = $"🏆 Batalla finalizada — Ganador: {resultado.GanadorFinal}";
                    btnSiguiente.Enabled = false;
                    MessageBox.Show($"La batalla ha finalizado. El ganador es: {resultado.GanadorFinal}", "Batalla Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var frm = new frmBatallas();
                    frm.Show();
                    this.Close();

                }
                else
                {
                    lblEstado.Text = "Listo para siguiente ronda...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al simular ronda: " + ex.Message);
            }
        }
    
    }
}

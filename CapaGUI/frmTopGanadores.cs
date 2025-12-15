/*
 * Universidad Estatal a Distancia (UNED)
 * II Cuatrimestre
 * Proyecto 1 - MITICAX Juego
 * El proyecto se basa en la creación de un juego, muy simple, en el cual se enfrentan jugadores haciendo uso de sus criaturas, con el fin de ganar
 * batallas y asi conseguir recursos y mejoras para sus equipos. Con este proyecto tambiénm se ponen en practica el uso de excepciones, arreglos, clases 
 * y objetos y diseño de GUI.
 * Félix Rios Prado
 * 23/09/2025
*/
using CapaAccesoDatos;
using Newtonsoft.Json;
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
    public partial class frmTopGanadores : Form
    {
        public frmTopGanadores()
        {
            InitializeComponent();
            
            // Llama al metodo de Top10Ganadores para actualizar la tabla.
            Repositorio.Top10Ganadores();

            //Actualiza la tabla tras cada entrada a la ventana
            CargarTop();
            
        }

        private void CargarTop()
        {
            try
            {
                var tcp = new ClienteTcp();
                var msg = new MensajeSocket<object>
                {
                    Metodo = "TopGanadores",
                    Cliente = SesionActual.NombreJugador,
                    Entidad = null
                };

                string respuesta = tcp.Enviar(msg);
                tcp.Cerrar();

                // 🧠 Deserializar respuesta JSON
                dynamic resp = JsonConvert.DeserializeObject(respuesta);

                if (resp.ok != true)
                {
                    MessageBox.Show("Error al cargar el top: " + (string)resp.error,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir los datos a una tabla
                var data = ((Newtonsoft.Json.Linq.JArray)resp.data)
                    .Select(j => new
                    {
                        NombreJugador = (string)j["Item1"],
                        Victorias = (int)(j["Item2"] ?? 0),
                        Nivel = (int)(j["Item3"] ?? 0)
                    }).ToList();

                dgvTop.DataSource = data;

                // 🎨 Ajustar visual
                dgvTop.Columns["NombreJugador"].HeaderText = "Jugador";
                dgvTop.Columns["Victorias"].HeaderText = "Batallas Ganadas";
                dgvTop.Columns["Nivel"].HeaderText = "Nivel";

                dgvTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el top: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTopGanadores_Load(object sender, EventArgs e)
        {
            dgvTop.Columns.Add("Jugador", "Jugador");
            dgvTop.Columns.Add("Ganadas", "Batallas Ganadas");
            dgvTop.Columns.Add("Nivel", "Nivel");
            dgvTop.ReadOnly = true;
            dgvTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            var frm = new frmPrincipal();
            frm.Show();
            this.Hide();
        }
    }
}
        
    

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
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class frmBatallas : Form
    {
        // Variables para almacenar el ID de la batalla actual y el equipo seleccionado.
        private int IDBatalla = 0;
        private int IDEquipo = 0;

        public frmBatallas()
        {
            InitializeComponent();

            try
            {
                // Limpiar columnas y filas previas
                dgvBatallas.Columns.Clear();
                dgvBatallas.Rows.Clear();

                // Definir columnas (en el mismo formato que tu ejemplo)
                dgvBatallas.Columns.Add("IDBatalla", "ID Batalla");
                dgvBatallas.Columns.Add("Jugador1", "Jugador 1");
                dgvBatallas.Columns.Add("Jugador2", "Jugador 2");
                dgvBatallas.Columns.Add("Fecha", "Fecha");
                dgvBatallas.Columns.Add("Estado", "Estado");
                dgvBatallas.Columns.Add("Ganador", "Ganador");

                // Obtener datos desde la capa DAL
                var lista = CapaAccesoDatos.BatallaDAL.ObtenerBatallasJugador(SesionActual.IDJugador);

                // Cargar filas en el DataGridView
                foreach (var b in lista)
                {
                    dgvBatallas.Rows.Add(
                        b.IDBatalla,
                        b.Jugador1,
                        b.Jugador2,
                        b.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        b.Estado,
                        b.Ganador
                    );
                }

                // Ajuste visual básico
                dgvBatallas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBatallas.ReadOnly = true;
                dgvBatallas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Colorear por estado
                foreach (DataGridViewRow row in dgvBatallas.Rows)
                {
                    string estado = row.Cells["Estado"].Value?.ToString() ?? "";
                    if (estado.Equals("FINALIZADA", StringComparison.OrdinalIgnoreCase))
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    else if (estado.Equals("EN_PROGRESO", StringComparison.OrdinalIgnoreCase))
                        row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar batallas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Configurar propiedades del DataGridView
            dgvBatallas.ReadOnly = true;
            dgvBatallas.AllowUserToAddRows = false;
            dgvBatallas.RowHeadersVisible = false;
            dgvBatallas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBatallas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ajustar ancho de columnas
            dgvBatallas.Columns[0].Width = 150;
            dgvBatallas.Columns[1].Width = 200;
            dgvBatallas.Columns[2].Width = 100;
            dgvBatallas.Columns[3].Width = 120;
            dgvBatallas.Columns[4].Width = 100;

            btnRegistrar.Enabled = true;
            btnCancelar.Enabled = false;

            //Metodo para cargar equipos en el combobox
            CargarEquipos();

            // Cargar batallas al abrir el formulario
            //ActualizarTablaBatallas();
        }


        // Método para cargar los equipos del jugador actual en el ComboBox.
        // Permite al jugador seleccionar qué equipo usará en la batalla.
        private void CargarEquipos()
        {
            try
            {
                // Obtener equipos del jugador y asignar al ComboBox
                var equipos = EquipoDAL.ObtenerEquipos(SesionActual.IDJugador);

                // Se asigna la lista de equipos como fuente de datos del ComboBox.
                cmbEquipos.DataSource = equipos;

                // Se especifica qué propiedad de los objetos EquipoEntidad se mostrará en el ComboBox.
                cmbEquipos.DisplayMember = "NombreEquipo";
                cmbEquipos.ValueMember = "IDEquipo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message);
            }
        }

       

        // Volver al formulario principal
        private void btnAtras_Click(object sender, EventArgs e)
        {
            var frm = new frmPrincipal();
            frm.Show();
            this.Hide();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Se crea una nueva instancia del formulario principal.
                BatallaDAL.CancelarBusqueda(SesionActual.IDJugador);

                // Actualizar la interfaz
                lblEstado.Text = "Búsqueda cancelada.";
                btnRegistrar.Enabled = true;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cancelar la búsqueda: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Registrar batalla y buscar oponente
        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se llama al método de la capa de acceso a datos para cancelar la búsqueda.
                // Se pasa el ID del jugador actual para identificarlo en la lista de espera.
                IDEquipo = ((EquipoEntidad)cmbEquipos.SelectedItem).IDEquipo;

                // Se actualiza la etiqueta de estado para informar al usuario.
                lblEstado.Text = "Buscando oponente...";

                // Se ejecuta la búsqueda de batalla en un hilo separado para no bloquear la interfaz.
                // Task.Run mueve la operación a un hilo del pool de hilos.
                var resp = await System.Threading.Tasks.Task.Run(() =>
                    BatallaDAL.BuscarBatalla(SesionActual.IDJugador, IDEquipo, SesionActual.NombreJugador));

                if (resp.Estado == "ESPERA")
                {
                    lblEstado.Text = "Esperando oponente...";
                    btnRegistrar.Enabled = false;
                    btnCancelar.Enabled = true;
                }

                else if (resp.Estado == "ENCONTRADO")
                {
                    btnRegistrar.Enabled = true;
                    // Si el estado es "ENCONTRADO", significa que se encontró un oponente.
                    // Se actualiza la etiqueta con el nombre del oponente encontrado.
                    lblEstado.Text = $"Batalla encontrada contra {resp.Oponente}";

                    // Se guarda el ID de la batalla creada para usar en las rondas.
                    IDBatalla = resp.IDBatalla;

                    // Se crea y muestra el formulario de rondas para comenzar la batalla.
                    // Se pasan los parámetros necesarios: ID de batalla, equipo propio, equipo rival y nombre del oponente.
                    var frm = new frmRondas(IDBatalla, IDEquipo, resp.IDOponente, resp.Oponente);
                    this.Close();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar batalla: " + ex.Message);
            }
        }
    }
}

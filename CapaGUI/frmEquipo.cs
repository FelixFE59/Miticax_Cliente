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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class frmEquipo : Form
    {
        public frmEquipo()
        {
            InitializeComponent();


            // Cargar los datos iniciales como las combo box de las criaturas y la tabla de equipos
            CargarComboBoxes();
            ActualizarTabla();

            // Mostrar el nombre del jugador en el formulario
            txtJugador.Text = SesionActual.NombreJugador;
        }

        // Método para actualizar la tabla de equipos
        private void ActualizarTabla()
        {
            // Obtener la lista de equipos del jugador actual
            List<EquipoEntidad> Equipos = EquipoDAL.ObtenerEquipos(SesionActual.IDJugador);

            // Limpiar las filas existentes en el DataGridView para ingresar las nuevas y evitar duplicados
            dgvEquipos.Rows.Clear();

            // Configurar las columnas del DataGridView
            dgvEquipos.Columns.Add("IDJugador", "ID Jugador"); 
            dgvEquipos.Columns.Add("Nombre", "Nombre del equipo");
            dgvEquipos.Columns.Add("IDC1", "Criatura 1");
            dgvEquipos.Columns.Add("IDC2", "Criatura 2");
            dgvEquipos.Columns.Add("IDC3", "Criatura 3");

            // Agregar cada equipo a la tabla
            for (int i = 0; i<Equipos.Count; i++)
            {
                var e = Equipos[i];
                dgvEquipos.Rows.Add(e.IDJugador.IDJugador, e.NombreEquipo, e.IDCriatura1.IDCriatura, e.IDCriatura2.IDCriatura, e.IDCriatura3.IDCriatura);
            }
        }

        // Método para cargar las criaturas del inventario en los ComboBoxes
        private void CargarComboBoxes()
        {
            // Limpiar las fuentes de datos existentes para evitar duplicados
            cmbCriatura1.DataSource = null;
            cmbCriatura2.DataSource = null;
            cmbCriatura3.DataSource = null;
            var ListaInventario = InventarioDAL.ObtenerInventario(SesionActual.IDJugador);

            // Seleccionar el IDInventario y el Nombre de la criatura para mostrar en los ComboBoxes
            var NombreCriatura = from inv in ListaInventario
                select new
                {
                    inv.IDInventario,
                    NombreCriatura = inv.Criatura.Nombre
                };

            // Asignar las fuentes de datos a los ComboBoxes y su apariencia
            cmbCriatura1.DisplayMember = "NombreCriatura";
            cmbCriatura1.ValueMember = "IDInventario";
            cmbCriatura1.DataSource = NombreCriatura.ToList();

            cmbCriatura2.DisplayMember = "NombreCriatura";
            cmbCriatura2.ValueMember = "IDInventario";
            cmbCriatura2.DataSource = NombreCriatura.ToList();

            cmbCriatura3.DisplayMember = "NombreCriatura";
            cmbCriatura3.ValueMember = "IDInventario";
            cmbCriatura3.DataSource = NombreCriatura.ToList();
        }


        


        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener los datos del formulario
                string Nombre = txtNombre.Text.Trim();
                int c1 = (int)cmbCriatura1.SelectedValue;
                int c2 = (int)cmbCriatura2.SelectedValue;
                int c3 = (int)cmbCriatura3.SelectedValue;

                if (string.IsNullOrWhiteSpace(Nombre))
                {
                    throw new Exception("El nombre del equipo no puede estar vacío.");
                }

                if (c1 == c2 || c1 == c3 || c2 == c3)
                {
                    throw new Exception("Las criaturas seleccionadas deben ser diferentes entre sí.");
                }

                //Llamada al metodo par registrar equipos con los datos del formulario
                string msg = EquipoDAL.RegistrarEquipo(SesionActual.IDJugador, Nombre, c1, c2, c3);
                MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualizar la tabla de equipos despues de registrar uno nuevo
                ActualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        // Volver al formulario principal
        private void btnAtras_Click(object sender, EventArgs e)
        {
            var frm = new frmPrincipal();
            frm.Show();
            this.Hide();
        }
    }
}

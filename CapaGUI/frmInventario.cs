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
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();

            // Muestra la tabla de inventario cada que se abre el formulario
            ActualizarTablaInventario();

            //cargar criaturas combo box
            CargarComboBoxes();


            // Mostrar el nombre del jugador y sus cristales en el formulario
            var jugadorActualizado = JugadorDAL.ObtenerJugadores().FirstOrDefault(j => j.IDJugador == SesionActual.IDJugador);
            if (jugadorActualizado != null)
            {
                SesionActual.Cristales = jugadorActualizado.Cristales;
                lblJugador.Text = SesionActual.NombreJugador;
                txtCristales.Text = $"Jugador: {SesionActual.NombreJugador} (Cristales: {SesionActual.Cristales})";
            }

        }

        //Método para cargar las criaturas disponibles en el ComboBox
        private void CargarComboBoxes()
        {
            //mismo procedimiento que los demas
            cmbCriaturas.Items.Clear();
            var ListaCriaturas = CapaAccesoDatos.CriaturaDAL.ObtenerCriaturas();

            cmbCriaturas.DisplayMember = "Nombre";
            cmbCriaturas.ValueMember = "IDCriatura";
            cmbCriaturas.DataSource = ListaCriaturas;
            
           
        }
            

        // Método para actualizar la tabla de inventario
        public void ActualizarTablaInventario()
        {
            try
            {
                // Limpiar las filas existentes en el DataGridView para ingresar las nuevas y evitar duplicados
                dgvInventario.Rows.Clear();
                int IDJugador = int.Parse(SesionActual.IDJugador.ToString());
                // Obtener inventario solo del jugador actual
                var ListaInventario = CapaAccesoDatos.InventarioDAL.ObtenerInventario(IDJugador);

                // Si el inventario está vacío, mostrar mensaje y salir
                if (ListaInventario.Count == 0)
                {
                    dgvInventario.DataSource = null;
                    MessageBox.Show("El jugador aún no posee criaturas en su inventario.",
                                    "Inventario vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar en el DataGridView solo las criaturas del jugador
                dgvInventario.AutoGenerateColumns = true;
                
                dgvInventario.Columns.Add("IDJugador", "ID Jugador");
                dgvInventario.Columns.Add("IDCriatura", "ID Criatura");
                dgvInventario.Columns.Add("IDInventario", "ID Inventario");
                dgvInventario.Columns.Add("Nivel", "Nivel");
                dgvInventario.Columns.Add("Poder", "Poder");
                dgvInventario.Columns.Add("Resistencia", "Resistencia");

                // Agregar cada inventario del jugador a la tabla
                for (int i = 0; i < ListaInventario.Count; i++)
                {
                    var l = ListaInventario[i];
                    dgvInventario.Rows.Add(l.Jugador.IDJugador, l.Criatura.IDCriatura, l.IDInventario, l.Nivel, l.Poder, l.Resistencia);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla de inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualiza los TextBox con los datos de la criatura seleccionada
        private static void ActualizarTxT(TextBox txtCosto, TextBox txtPoder, TextBox txtNivel, TextBox txtResistencia, int ID)
        {
            // Obtener la lista de criaturas
            var Criaturas = CapaAccesoDatos.CriaturaDAL.ObtenerCriaturas();
            CapaEntidades.CriaturaEntidad C = null;

            // Buscar la criatura en la lista
            for (int i = 0; i < Criaturas.Count; i++)
            {
                // Buscar la criatura por su ID 
                if (Criaturas[i] != null && Criaturas[i].IDCriatura == ID)
                {
                    C = Criaturas[i];
                    break;
                }
            }
            // Si se encontró la criatura, actualizar los TextBox con sus datos
            if (C != null)
            {
                txtCosto.Text = C.Costo.ToString();
                txtPoder.Text = C.Poder.ToString();
                txtNivel.Text = C.Nivel.ToString();
                txtResistencia.Text = C.Resistencia.ToString();
            }
            // Si no se encontró la criatura, limpiar los TextBox
            else
            {
                txtCosto.Text = "";
                txtPoder.Text = "";
                txtNivel.Text = "";
                txtResistencia.Text = "";

            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                var Jugadores = CapaAccesoDatos.JugadorDAL.ObtenerJugadores();

                CapaEntidades.JugadorEntidad J = null;

                // Buscar Jugador
                for (int i = 0; i < Jugadores.Count; i++)
                {
                    // Si el jugador en la posición i no es nulo y su ID coincide con el ID buscado, se asigna a J
                    if (Jugadores[i] != null && Jugadores[i].IDJugador == SesionActual.IDJugador)
                    {
                        J = Jugadores[i];
                        break;
                    }
                }
                
                var Criaturas = CapaAccesoDatos.CriaturaDAL.ObtenerCriaturas();

                CapaEntidades.CriaturaEntidad c = null;

                int IDCriatura = (int)cmbCriaturas.SelectedValue;


                // Buscar criatura
                for (int i = 0; i < Criaturas.Count; i++)
                {
                    // Si la criatura en la posición i no es nulo y su ID coincide con el ID buscado, se asigna a c
                    if (Criaturas[i] != null && Criaturas[i].IDCriatura == IDCriatura)
                    {
                        c = CapaAccesoDatos.Repositorio.Criaturas[i];
                        break;
                    }
                }

                // Crear el inventario y registrarlo
                var inv = new CapaEntidades.InventarioEntidad
                {
                    Jugador = J,
                    Criatura = c,
                    Nivel = int.Parse(txtNivel.Text),
                    Poder = int.Parse(txtPoder.Text),
                    Resistencia = int.Parse(txtResistencia.Text)
                };

                // Registrar el inventario al jugador con la criatura adquirida
                InventarioDAL.RegistrarInventario(SesionActual.IDJugador, IDCriatura);

                MessageBox.Show("Inventario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la tabla de inventario para reflejar el nuevo registro
                ActualizarTablaInventario();

                // Actualizar los cristales del jugador en la sesión actual y en el formulario
                var jugadorActualizado = JugadorDAL.ObtenerJugadores()
                     .FirstOrDefault(j => j.IDJugador == SesionActual.IDJugador);
                if (jugadorActualizado != null)
                {
                    SesionActual.Cristales = jugadorActualizado.Cristales;
                    txtCristales.Text = $"Jugador: {SesionActual.NombreJugador} (Cristales: {SesionActual.Cristales})";
                }
            }
            catch (ArgumentException ex) // Datos inválidos, duplicados, no existe, etc.
            {
                MessageBox.Show(ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (FormatException ex) // Por si algún int.Parse quedó suelto
            {
                MessageBox.Show("Formato inválido. " + ex.Message,
                    "Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) // Si algo mas falla, recoge la excepcion y evita que el programa se crashee
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Volver al formulario principal
        private void btnAtras_Click(object sender, EventArgs e)
        {
            var frm = new frmPrincipal();
            frm.Show();
            this.Hide();
        }

       
        private void cmbCriaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbCriaturas.SelectedIndex == -1)
                {
                    return;
                }


                // Obtener el ID de la criatura seleccionada
                int ID = (int)cmbCriaturas.SelectedValue;
                ActualizarTxT(txtCosto, txtPoder, txtNivel, txtResistencia, ID);


            }
            catch (ArgumentException ex) // Datos inválidos, duplicados, no existe, etc.
            {
                MessageBox.Show(ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (FormatException ex) // Por si algún int.Parse quedó suelto
            {
                MessageBox.Show("Formato inválido. " + ex.Message,
                    "Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) // Si algo mas falla, recoge la excepcion y evita que el programa se crashee
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}

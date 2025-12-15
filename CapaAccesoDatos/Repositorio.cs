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
using CapaEntidades;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public static class Repositorio
    {
        //Arreglos para almacenar las entidades
        public static readonly CriaturaEntidad[] Criaturas = new CriaturaEntidad[20];
        public static readonly JugadorEntidad[] Jugadores = new JugadorEntidad[20];
        public static readonly InventarioEntidad[] Inventarios = new InventarioEntidad[30];
        public static readonly EquipoEntidad[] Equipos = new EquipoEntidad[40];
        public static readonly BatallaEntidad[] Batallas = new BatallaEntidad[50];
        public static readonly RondasEntidad[] Rondas = new RondasEntidad[100];
        public static readonly JugadorEntidad[] IDGanadores = new JugadorEntidad[10];

        //Contadores para llevar la cuenta de las entidades agregadas
        public static int cCriaturas = 1;
        public static int cJugadores = 1;
        public static int cInventarios = 1;
        public static int cEquipos = 1;
        public static int cBatallas = 1;
        public static int cRondas = 1;
        public static int cIDGanadores = 1;

        public static SqlConnection ObtenerConexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["ConexionBatallas"].ConnectionString;
            SqlConnection conexion = new SqlConnection(cadena);
            return conexion;
        }

        /*
        //Métodos para agregar y obtener entidades
        public static void AgregarCriatura(CriaturaEntidad c)
        {
            //Si el contador es menor que la longitud del arreglo, se agrega la criatura, si no, se lanza una excepción.
            if (cCriaturas < Criaturas.Length)
            {
                // Agregar la criatura al arreglo en el indice actual del contador y aumenta el contador
                Criaturas[cCriaturas] = c;
                cCriaturas++;
            }
            else
            {
                throw new Exception("No se pueden agregar más criaturas. Capacidad máxima alcanzada.");
            }
        }
        
        public static CriaturaEntidad[] ObtenerCriatura()
        {
            return Criaturas;
        }
        */



        /*
        public static void AgregarJugador(JugadorEntidad j)
        {
            if (cJugadores < Jugadores.Length)
            {
                Jugadores[cJugadores] = j;
                cJugadores++;
            }
            else
            {
                throw new Exception("No se pueden agregar más jugadores. Capacidad máxima alcanzada.");
            }
        }

        public static JugadorEntidad[] ObtenerJugador()
        {
            return Jugadores;
        }
        */

       

        /*
        public static void AgregarInventario(InventarioEntidad i)
        {
            if (cInventarios < Inventarios.Length)
            {
                Inventarios[cInventarios] = i;
                cInventarios++;
            }
            else
            {
                throw new Exception("No se pueden agregar más inventarios. Capacidad máxima alcanzada.");
            }
        }

        public static InventarioEntidad[] ObtenerInventario()
        {
            return Inventarios;
        }
        */

        

        /*
        public static void AgregarEquipo(EquipoEntidad e)
        {
            if (cEquipos < Equipos.Length)
            {
                Equipos[cEquipos] = e;
                cEquipos++;
            }
            else
            {
                throw new Exception("No se pueden agregar más equipos. Capacidad máxima alcanzada.");
            }
        }

        public static EquipoEntidad[] ObtenerEquipo()
        {
            return Equipos;
        } 
        */

        
        /*
        public static void AgregarBatalla(BatallaEntidad b)
        {
            if (cBatallas < Batallas.Length)
            {
                Batallas[cBatallas] = b;
                cBatallas++;
            }
            else
            {
                throw new Exception("No se pueden agregar más batallas. Capacidad máxima alcanzada.");
            }
        }
        */

        


        /*
        public static void AgregarRondas(RondasEntidad r)
        {
            if (cRondas < Rondas.Length)
            {
                Rondas[cRondas] = r;
                cRondas++;
            }
            else
            {
                throw new Exception("No se pueden agregar más rondas. Capacidad máxima alcanzada.");
            }
        }
        */

        
        public static void Top10Ganadores ()
        {

            if (cJugadores <= 0)
            {
                for (int i = 0; i < IDGanadores.Length; i++) 
                { 
                    IDGanadores[i] = null;
                }
                cIDGanadores = 0;
                return;
            }


            CapaEntidades.JugadorEntidad[] Ganadores = new CapaEntidades.JugadorEntidad[Jugadores.Length];
            int Contador = 0;

            for (int i = 0; i < Jugadores.Length; i++)
            {
                if (Jugadores[i] != null)
                {
                    Ganadores[Contador] = Jugadores[i];
                    Contador++;
                }
            }


            //Por estudiar, generado por el IDE.

            // Ordenar el arreglo temporal por batallas ganadas en orden descendente
            /*  //      Arreglo a ordenar, índice inicial, número de elementos a ordenar, comparador personalizado con jugadores x e y.
             Array.Sort(Ganadores, 0, contador, Comparer<CapaEntidades.JugadorEntidad>.Create((x, y) => y.BatallasGanadas.CompareTo(x.BatallasGanadas)));
            */



            // Ordenar por Batallas Ganadas descendentemente con Inserción (Materia: Estructuras de Datos)
            for (int i = 1; i < Contador; i++)
            {
                CapaEntidades.JugadorEntidad actual = Ganadores[i];
                int j = i - 1;

                // Desplazar mientras el anterior tenga menos batallas ganadas que el actual
                while (j >= 0 && Ganadores[j].BatallasGanadas < actual.BatallasGanadas)
                {
                    Ganadores[j + 1] = Ganadores[j];
                    j--;
                }

                Ganadores[j + 1] = actual;
            }

            // 3) Copiar el top N (N = min(10, Contador, IDGanadores.Length))
            int top = Contador;
            if (top > 10) top = 10;
            if (top > IDGanadores.Length) top = IDGanadores.Length;

            for (int i = 0; i < top; i++)
            {
                IDGanadores[i] = Ganadores[i];
            }

            // 4) Limpiar el resto para que el grid no muestre datos viejos
            for (int i = top; i < IDGanadores.Length; i++)
            {
                IDGanadores[i] = null;
            }

            // 5) Actualiza el contador del Top (opcional, si lo usas en la GUI) 
            cIDGanadores = top;

        }

    } 
        


}

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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaAccesoDatos.ClienteTcp;

namespace CapaAccesoDatos
{
    public class EquipoDAL
    {

        // Método para obtener la lista de equipos de un jugador específico
        public static List<EquipoEntidad> ObtenerEquipos(int idJugador)
        {
            // Crear una instancia del cliente TCP para la comunicación con el servidor...
            //Método con el mismo procedimiento que el resto
            var tcp = SesionActual.Conexion;
            //Verificar que la conexión TCP siga activa, si no, reabrirla
            if (tcp == null || !tcp.EstaConectado())
            {
                SesionActual.Conexion = new ClienteTcp();
                tcp = SesionActual.Conexion;
            }
            var entidad = new JObject { ["IdJugador"] = idJugador };
            var msg = new MensajeSocket<JObject>
            {
                Metodo = "ObtenerEquipos",
                Cliente = SesionActual.NombreJugador,
                Entidad = entidad
            };

            string respuesta = tcp.Enviar(msg);
            dynamic resp = JsonConvert.DeserializeObject(respuesta);

            if (resp.ok == true)
                return ((JArray)resp.data).ToObject<List<EquipoEntidad>>();
            else
                throw new Exception((string)resp.error);
        }
    
        public static string RegistrarEquipo(int idJugador, string NombreEquipo, int c1, int c2, int c3)
        {
            var tcp = SesionActual.Conexion;
            //Verificar que la conexión TCP siga activa, si no, reabrirla
            if (tcp == null || !tcp.EstaConectado())
            {
                SesionActual.Conexion = new ClienteTcp();
                tcp = SesionActual.Conexion;
            }
            var entidad = new JObject
            {
                ["IdJugador"] = idJugador,
                ["NombreEquipo"] = NombreEquipo,
                ["IdInventarioCriatura1"] = c1,
                ["IdInventarioCriatura2"] = c2,
                ["IdInventarioCriatura3"] = c3
            };
            var msg = new MensajeSocket<JObject>
            {
                Metodo = "RegistrarEquipo",
                Cliente = SesionActual.Usuario,
                Entidad = entidad
            };
            string respuesta = tcp.Enviar(msg);
            dynamic resp = JsonConvert.DeserializeObject(respuesta);
            if (resp.ok == true)
            {
                return (string)resp.msg;
            }
            else
            {
                throw new Exception((string)resp.error);
            }
        }
    }
}

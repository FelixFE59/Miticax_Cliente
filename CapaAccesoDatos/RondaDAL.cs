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
    public class RondaDAL
    {
        // Método para registrar una nueva ronda de batalla en el servidor.
        // Se comunica con el servidor via TCP para procesar la lógica de la ronda.
        public static ResultadoRonda RegistrarRonda(int IDBatalla, int IDEquipo1, int IDEquipo2)
        {
            // Crear el cliente TCP para comunicarse con el servidor
            var tcp = SesionActual.Conexion;
            //Verificar que la conexión TCP siga activa, si no, reabrirla
            if (tcp == null || !tcp.EstaConectado())
            {
                SesionActual.Conexion = new ClienteTcp();
                tcp = SesionActual.Conexion;
            }

            // Se crea un objeto JSON que contiene los datos necesarios para registrar la ronda.
            // Este objeto será enviado al servidor como parte del mensaje.
            var entidad = new JObject
            {
                ["IDBatalla"] = IDBatalla,
                ["IDAtacante"] = IDEquipo1,
                ["IDDefensor"] = IDEquipo2
            };

            // Se crea el mensaje completo que se enviará al servidor.
            // Contiene el método a ejecutar, información del cliente y los datos de la entidad.
            var msg = new MensajeSocket<JObject>
            {
                Metodo = "ResultadoRonda",
                Cliente = SesionActual.NombreJugador,
                Entidad = entidad
            };

            // Se envía el mensaje al servidor y se espera la respuesta.
            string respuesta = tcp.Enviar(msg);

            // Se deserializa la respuesta del servidor como un objeto dinámico.
            // Esto permite acceder a las propiedades sin necesidad de una clase específica.
            dynamic resp = JsonConvert.DeserializeObject(respuesta);

            // Si fue exitosa, se crea y retorna un objeto ResultadoRonda con los datos recibidos.
            if (resp.ok == true)
            {
                return new ResultadoRonda
                {
                    IDGanador = (int)resp.ganador,
                    NombreGanador = ((string)resp.msg).Replace("Ganador de la ronda: ", ""),
                    FinBatalla = (bool)resp.finBatalla,
                    GanadorFinal = resp.ganadorBatalla != null ? (string)resp.ganadorBatalla : "",
                    CriaturaAtacante = (string)(resp.criaturaAtacante ?? "???"),
                    CriaturaDefensora = (string)(resp.criaturaDefensora ?? "???")
                };
            }
            else
            {
                throw new Exception((string)resp.error);
            }
        }


    }
}

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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static CapaAccesoDatos.ClienteTcp;

namespace CapaAccesoDatos
{
    public class JugadorDAL
    {
        //Metodo para registrar jugadores
        public static string RegistrarJugador(string nombre, string usuario, string password, DateTime fechaNac)
        {
            // Crear el cliente TCP para comunicarse con el servidor
            var tcp = new ClienteTcp();

            // Se crea un objeto JSON que contiene los datos necesarios para registrar la ronda.
            var entidad = new JObject
            {
                ["Nombre"] = nombre,
                ["Usuario"] = usuario,
                ["Password"] = password,
                ["FechaNac"] = fechaNac
            };

            // Se crea el mensaje completo que se enviará al servidor.
            var msg = new MensajeSocket<JObject> { Metodo = "RegistrarJugador", Cliente = usuario, Entidad = entidad };
            // Se envía el mensaje al servidor y se espera la respuesta.
            string respuesta = tcp.Enviar(msg);
            // Se deserializa la respuesta del servidor como un objeto dinámico.
            dynamic resp = JsonConvert.DeserializeObject(respuesta);

            // Responde si fue exitosa o no la operación
            if (resp.ok == true)
                return (string)resp.msg;
            else
                throw new Exception((string)resp.error);
        }

        //Metodos para obtener las listas de jugadores
        public static List<JugadorEntidad> ObtenerJugadores()
        {
            // Crear el cliente TCP para comunicarse con el servidor
            var tcp = SesionActual.Conexion;
            //Verificar que la conexión TCP siga activa, si no, reabrirla
            if (tcp == null || !tcp.EstaConectado())
            {
                SesionActual.Conexion = new ClienteTcp();
                tcp = SesionActual.Conexion;
            }

            // Se crea el mensaje completo que se enviará al servidor.
            var msg = new MensajeSocket<string>
            {
                Metodo = "ObtenerJugadores",
                Cliente = SesionActual.NombreJugador,
                Entidad = ""
            };

            // Se envía el mensaje al servidor y se espera la respuesta.
            string respuesta = tcp.Enviar(msg);
            dynamic jugadores = JsonConvert.DeserializeObject(respuesta);
            if (jugadores.ok == true)
            {
                return ((JArray)jugadores.data).ToObject<List<JugadorEntidad>>();   
            } else {                 
                throw new Exception((string)jugadores.error); 
            }
        }

        //Metodo para autenticar jugadores, muy parecido a obtener jugadores, sin embar
        // se encarga de verificar las credenciales.
        public static JugadorEntidad AutenticarJugador(string Usuario, string Password)
        {
            var tcp = new ClienteTcp();

            var entidad = new JObject
            {
                ["Usuario"] = Usuario,
                ["Password"] = Password
            };
            var msg = new MensajeSocket<JObject> { Metodo = "Conectar", Cliente = SesionActual.NombreJugador, Entidad = entidad };
            string respuesta = tcp.Enviar(msg);
            dynamic resp = JsonConvert.DeserializeObject(respuesta);
            if (resp.ok == true)
            {
                SesionActual.Conexion = tcp;
                return ((JObject)resp.data).ToObject<JugadorEntidad>();
            }
            else
                throw new Exception((string)resp.error);
        }
    }
}

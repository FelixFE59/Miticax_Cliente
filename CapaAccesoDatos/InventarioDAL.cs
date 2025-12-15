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
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaAccesoDatos.ClienteTcp;

namespace CapaAccesoDatos
{
    public class InventarioDAL
    {
        //Mismo procedimiento
        public static string RegistrarInventario(int IDJugador, int IDCriatura)
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
            var entidad = new JObject
            {
                ["IDJugador"] = IDJugador,
                ["IDCriatura"] = IDCriatura
            };

            // Se crea el mensaje completo que se enviará al servidor.
            var msg = new MensajeSocket<JObject> { Metodo = "RegistrarInventario", Cliente = SesionActual.NombreJugador, Entidad = entidad };
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

        public static List<InventarioEntidad> ObtenerInventario(int IDJugador)
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
            var entidad = new JObject
            {
                ["IDJugador"] = IDJugador
            };

            // Se crea el mensaje completo que se enviará al servidor.
            var msg = new MensajeSocket<JObject>
            {
                Metodo = "ObtenerInventario",
                Cliente = SesionActual.NombreJugador,
                Entidad = entidad
            };
            // Se envía el mensaje al servidor y se espera la respuesta.
            string respuesta = tcp.Enviar(msg);

            // Se deserializa la respuesta del servidor como un objeto dinámico.
            dynamic Inventario = JsonConvert.DeserializeObject(respuesta);

            if (Inventario.ok == true)
            {
                // Data se convierte en un array
                var dataArray = (JArray)Inventario.data;

                // Convertimos el array JSON a una lista.
                var lista = dataArray.ToObject<List<InventarioEntidad>>();

                // Si por alguna razón viene null, devuelve lista vacía
                return lista ?? new List<InventarioEntidad>();

            }
            else
            {
                throw new Exception((string)Inventario.error);
            }
        } 

    }
}

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
    public class BatallaDAL
    {

        public static ResultadoBatalla BuscarBatalla(int IDJugador, int IDEquipo, string NombreJugador)
        {
            try
            {
                var entidad = new JObject
                {
                    ["IDJugador"] = IDJugador,
                    ["IDEquipo"] = IDEquipo,
                    ["Cliente"] = NombreJugador
                };

                var msg = new MensajeSocket<JObject>
                {
                    Metodo = "RegistrarBatalla",
                    Cliente = NombreJugador,
                    Entidad = entidad
                };

                var tcp = SesionActual.Conexion;
                //Verificar que la conexión TCP siga activa, si no, reabrirla
                if (tcp == null || !tcp.EstaConectado())
                {
                    SesionActual.Conexion = new ClienteTcp();
                    tcp = SesionActual.Conexion;
                }
                string respuesta = tcp.Enviar(msg);
                dynamic resp = JsonConvert.DeserializeObject(respuesta);

                if (resp.ok != true)
                    throw new Exception((string)resp.error);

                return new ResultadoBatalla
                {
                    Estado = (string)(resp.Estado ?? ""),
                    Oponente = (string)(resp.Oponente ?? "Esperando..."),
                    IDBatalla = (int)(resp.IDBatalla ?? 0),
                    IDOponente = (int)(resp.IDOponente ?? 0)
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar batalla: " + ex.Message);
            }
        }

        public static void CancelarBusqueda(int idJugador)
        {
            try
            {
                var tcp = SesionActual.Conexion;
                var entidad = new JObject
                {
                    ["IdJugador"] = idJugador
                };

                var msg = new MensajeSocket<JObject>
                {
                    Metodo = "CancelarBusqueda",
                    Cliente = SesionActual.NombreJugador,
                    Entidad = entidad
                };

                string respuesta = tcp.Enviar(msg);

                //Verificar que la conexión TCP siga activa, si no, reabrirla
                if (tcp == null || !tcp.EstaConectado())
                {
                    SesionActual.Conexion = new ClienteTcp();
                    tcp = SesionActual.Conexion;
                }


                if (string.IsNullOrWhiteSpace(respuesta)) return;

                dynamic resp = JsonConvert.DeserializeObject(respuesta);
                if (resp.ok != true)
                    throw new Exception((string)resp.error);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cancelar búsqueda: " + ex.Message);
            }
        }
        public static List<BatallaResumen> ObtenerBatallasJugador(int idJugador)
        {
            try
            {

                var entidad = new JObject
                {
                    ["IDJugador"] = idJugador
                };

                var msg = new MensajeSocket<JObject>
                {
                    Metodo = "ObtenerBatallasJugador",
                    Cliente = SesionActual.NombreJugador,
                    Entidad = entidad
                };

                var tcp = SesionActual.Conexion;

                //Verificar que la conexión TCP siga activa, si no, reabrirla
                if (tcp == null || !tcp.EstaConectado())
                {
                    SesionActual.Conexion = new ClienteTcp();
                    tcp = SesionActual.Conexion;
                }


                string respuesta = tcp.Enviar(msg);
                
                dynamic resp = JsonConvert.DeserializeObject(respuesta);

                if (resp == null)
                {
                    throw new Exception("No se recibió respuesta del servidor.");
                }

                if (resp.ok == true)
                {
                    return ((JArray)resp.data).ToObject<List<BatallaResumen>>();

                }
                else
                {
                    throw new Exception((string)resp.error);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener batallas del jugador: " + ex.Message);
            }
        }

        public static List<ResumenRondas> ObtenerRondasBatalla(int idBatalla)
        {
            try
            {
                var entidad = new JObject
                {
                    ["IDBatalla"] = idBatalla
                };

                var msg = new MensajeSocket<JObject>
                {
                    Metodo = "ObtenerRondasBatalla",
                    Cliente = SesionActual.NombreJugador,
                    Entidad = entidad
                };

                var tcp = SesionActual.Conexion;
                string respuesta = tcp.Enviar(msg);
                dynamic resp = JsonConvert.DeserializeObject(respuesta);

                if (resp.ok == true)
                {
                    return ((JArray)resp.data).ToObject<List<ResumenRondas>>();
                }
                else
                {
                    throw new Exception((string)resp.error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener rondas de batalla: " + ex.Message);
            }
        }

    }
}

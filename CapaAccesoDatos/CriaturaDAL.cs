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
    public class CriaturaDAL
    {
        //No se utiliza, pero lleva la mismma logica que le resto
        public static string RegistrarCriatura(string Nombre, string Tipo, int Nivel, int Poder, int Resistencia, int Costo)
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
                ["Nombre"] = Nombre,
                ["Tipo"] = Tipo,
                ["Nivel"] = Nivel,
                ["Poder"] = Poder,
                ["Resistencia"] = Resistencia,
                ["Costo"] = Costo
            };

            var msg = new MensajeSocket<JObject> { Metodo = "RegistrarCriatura", Cliente = SesionActual.NombreJugador, Entidad = entidad };
            string respuesta = tcp.Enviar(msg);

            dynamic resp = JsonConvert.DeserializeObject(respuesta);
            if (resp.ok == true)
                return (string)resp.msg;
            else
                throw new Exception((string)resp.error);
        }

        //Metodo para obtener la lista de criaturas de la tienda y poder comprar en inventario
        //Mismo procedimiento que los demas
        public static List<CriaturaEntidad> ObtenerCriaturas()
        {
            var tcp = SesionActual.Conexion;
            //Verificar que la conexión TCP siga activa, si no, reabrirla
            if (tcp == null || !tcp.EstaConectado())
            {
                SesionActual.Conexion = new ClienteTcp();
                tcp = SesionActual.Conexion;
            }
            var msg = new MensajeSocket<string>
            {
                Metodo = "ObtenerCriaturas",
                Cliente = SesionActual.NombreJugador,
                Entidad = ""
            };
            string respuesta = tcp.Enviar(msg);
            dynamic resp = JsonConvert.DeserializeObject(respuesta);

            if (resp.ok == true)
            {
                return ((JArray)resp.data).ToObject<List<CriaturaEntidad>>();
            }
            else
            {
                throw new Exception((string)resp.error);
            }
        }
    }
}

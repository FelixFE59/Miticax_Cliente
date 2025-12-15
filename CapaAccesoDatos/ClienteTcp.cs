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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ClienteTcp : IDisposable
    {
        // Configuración de conexión al servidor
        private readonly string ip = "127.0.0.1";
        private readonly int puerto = 14100;

        // Componentes para la comunicación TCP
        private TcpClient cliente;     // Cliente TCP para la conexión
        private NetworkStream ns;      // Stream de red para la comunicación
        private StreamReader lector;   // Lector para recibir datos
        private StreamWriter escritor; // Escritor para enviar datos

        public ClienteTcp()
        {
            // Establece conexión con el servidor
            cliente = new TcpClient(ip, puerto);
            // Obtiene el stream de red para comunicación
            ns = cliente.GetStream();
            // Inicializa lector y escritor con codificación UTF-8
            lector = new StreamReader(ns, Encoding.UTF8);
            escritor = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };
        }

        public string Enviar(object objeto)
        {
            // Serializa el objeto a formato JSON
            string json = JsonConvert.SerializeObject(objeto);
            // Envía el JSON al servidor
            escritor.WriteLine(json);
            // Lee y retorna la respuesta del servidor
            return lector.ReadLine();
        }

        public void Cerrar()
        {
            // Cierra y libera recursos en orden 
            lector?.Close();
            escritor?.Close();
            cliente?.Close();
        }

        public void Dispose() => Cerrar();

        //verificar que la conexión siga viva
        public bool EstaConectado()
        {
            try
            {
                return cliente != null && cliente.Connected && ns != null;
            }
            catch
            {
                return false;
            }
        }

    }
}

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaAccesoDatos
{
    //Almacenar la información de la sesión
    public static class SesionActual
    {
        public static string NombreJugador { get; set; }
        public static int IDJugador { get; set; }
        public static string Usuario { get; set; }
        public static int Nivel { get; set; }
        public static int Cristales { get; set; }
        public static ClienteTcp Conexion { get; set; }
        public static void CerrarSesion()
        {
            IDJugador = 0;
            NombreJugador = string.Empty;
            Usuario = string.Empty;
            Nivel = 0;
            Cristales = 0;
        }

    }
}

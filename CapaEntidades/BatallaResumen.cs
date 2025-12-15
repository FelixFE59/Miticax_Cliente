
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

namespace CapaEntidades
{
    public class BatallaResumen
    {
        public int IDBatalla { get; set; }
        public string Jugador1 { get; set; }
        public string Jugador2 { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Ganador { get; set; }
    }
}

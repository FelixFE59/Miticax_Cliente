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
    public class JugadorEntidad{

        //Atributos de la entidad Jugador
        public int IDJugador { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nivel { get; set; }
        public string TipoNivel { get; set; }
        public int Cristales { get; set; }
        public int BatallasGanadas { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

    }
}

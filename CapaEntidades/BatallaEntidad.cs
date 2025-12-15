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
    public class BatallaEntidad
    {
        //Atributos de la entidad Batalla
        public int IDBatalla { get; set; }

        public JugadorEntidad Jugador1 { get; set; }
        public EquipoEntidad Equipo1 { get; set; }

        public JugadorEntidad Jugador2 { get; set; }
        public EquipoEntidad Equipo2 { get; set; }

        public int IDGanador { get; set; } 
        public DateTime Fecha { get; set; }

    }
}

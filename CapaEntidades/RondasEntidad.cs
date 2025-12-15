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
    public class RondasEntidad
    {

        //Atributos de la entidad Rondas
        public int IDBatalla { get; set; }
        public int IDRonda { get; set; }
        public int NumeroRonda { get; set; }
        public int IdInventarioAtacante { get; set; }
        public int IdInventarioDefensor { get; set; }
        public int GanadorRonda { get; set; }

    }
}

using System;
using System.Collections.Generic;
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

using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ResultadoRonda
    {
        public int IDGanador { get; set; }
        public string NombreGanador { get; set; }
        public bool FinBatalla { get; set; }
        public string GanadorFinal { get; set; }
        public string CriaturaAtacante { get; set; }
        public string CriaturaDefensora { get; set; }


    }
}

using Ejeercicio08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejeercicio08
{
    public class Nodo
    {
        public DispositivoIoT Datos;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(DispositivoIoT dispositivo)
        {
            Datos = dispositivo;
            Izquierdo = null;
            Derecho = null;
        }
    }
}

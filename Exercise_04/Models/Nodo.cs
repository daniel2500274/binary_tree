using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_04.Models
{
    public class Nodo
    {
        public CitaMedica Datos;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(CitaMedica cita)
        {
            Datos = cita;
            Izquierdo = null;
            Derecho = null;
        }
    }
}

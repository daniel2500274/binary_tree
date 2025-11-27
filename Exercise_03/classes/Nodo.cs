using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_03.classes
{ 
    public class Nodo
    {
        public Libro Datos;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(Libro libro)
        {
            Datos = libro;
            Izquierdo = null;
            Derecho = null;
        }
    }
}

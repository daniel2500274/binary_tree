using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05.Models
{
    public class Nodo
    {
        public Producto Datos;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(Producto producto)
        {
            Datos = producto;
            Izquierdo = null;
            Derecho = null;
        }
    }
}

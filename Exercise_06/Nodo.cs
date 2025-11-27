using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_06
{
    public class Nodo
    {
        public int Key;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int key)
        {
            Key = key;
            Izquierdo = null;
            Derecho = null;
        }
    }
}

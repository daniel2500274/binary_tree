using Exercise_07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_07
{
    public class Nodo
    {
        public Usuario Usuario;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(Usuario usuario)
        {
            Usuario = usuario;
            Izquierdo = null;
            Derecho = null;
        }
    }
}

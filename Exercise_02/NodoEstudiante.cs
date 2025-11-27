using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_02
{
    public class NodoEstudiante
    {
        public int Carnet;       // Key
        public string Nombre;    // Value
        public NodoEstudiante Izquierdo, Derecho;

        public NodoEstudiante(int carnet, string nombre)
        {
            Carnet = carnet;
            Nombre = nombre;
            Izquierdo = Derecho = null;
        }
    }
}

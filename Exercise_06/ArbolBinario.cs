using Exercise_06.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_06
{
    public class ArbolBinario : IArbolAnalisis
    {
        private Nodo raiz;

        public void Insertar(int key)
        {
            raiz = InsertarRec(raiz, key);
        }

        private Nodo InsertarRec(Nodo actual, int key)
        {
            if (actual == null) return new Nodo(key);

            if (key < actual.Key)
                actual.Izquierdo = InsertarRec(actual.Izquierdo, key);
            else if (key > actual.Key)
                actual.Derecho = InsertarRec(actual.Derecho, key);

            return actual;
        }

        // Calculamos la altura  
        public int ObtenerAltura()
        {
            return CalcularAlturaRec(raiz);
        }

        private int CalcularAlturaRec(Nodo nodo)
        {
            if (nodo == null) return 0; // Árbol vacío
                                        // Si contamos por niveles de nodos, sumamos 1. Si fuera aristas, se ajusta. 
            return 1 + Math.Max(CalcularAlturaRec(nodo.Izquierdo), CalcularAlturaRec(nodo.Derecho));
        }

        // Cuenta cuántos nodos visitamos para encontrar el valor
        public int ContarComparaciones(int keyBuscada)
        {
            int comparaciones = 0;
            Nodo actual = raiz;

            while (actual != null)
            {
                comparaciones++;  
                if (keyBuscada == actual.Key) return comparaciones; 

                if (keyBuscada < actual.Key)
                    actual = actual.Izquierdo;
                else
                    actual = actual.Derecho;
            }
            return comparaciones; 
        }

        public void Dibujar()
        {
            DibujarRec(raiz, "", true);
        }

        private void DibujarRec(Nodo nodo, string indent, bool last)
        {
            if (nodo != null)
            {
                Console.Write(indent);
                if (last) { Console.Write("└─"); indent += "  "; }
                else { Console.Write("├─"); indent += "| "; }
                Console.WriteLine(nodo.Key);
                DibujarRec(nodo.Izquierdo, indent, false);
                DibujarRec(nodo.Derecho, indent, true);
            }
        }
    }
}

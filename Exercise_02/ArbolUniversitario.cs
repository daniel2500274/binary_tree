using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_02
{
    public class ArbolUniversitario
    {
        public NodoEstudiante Raiz;
         
        public void Insertar(int carnet, string nombre)
        {
            Raiz = InsertarRec(Raiz, carnet, nombre);
        }

        private NodoEstudiante InsertarRec(NodoEstudiante raiz, int carnet, string nombre)
        {
            if (raiz == null) return new NodoEstudiante(carnet, nombre);

            if (carnet < raiz.Carnet)
                raiz.Izquierdo = InsertarRec(raiz.Izquierdo, carnet, nombre);
            else if (carnet > raiz.Carnet)
                raiz.Derecho = InsertarRec(raiz.Derecho, carnet, nombre); 

            return raiz;
        }

        //  Búsqueda  
        public bool Contiene(int carnet)
        {
            return BuscarRec(Raiz, carnet);
        }

        private bool BuscarRec(NodoEstudiante raiz, int carnet)
        { 
            if (raiz == null) return false;
             
            if (raiz.Carnet == carnet) return true;
             
            if (carnet < raiz.Carnet)
                return BuscarRec(raiz.Izquierdo, carnet);
            else
                return BuscarRec(raiz.Derecho, carnet);
        }

        //  Eliminación 
        public void Eliminar(int carnet)
        {
            Raiz = EliminarRec(Raiz, carnet);
        }

        private NodoEstudiante EliminarRec(NodoEstudiante raiz, int carnet)
        {
            if (raiz == null) return null;

            if (carnet < raiz.Carnet)
                raiz.Izquierdo = EliminarRec(raiz.Izquierdo, carnet);
            else if (carnet > raiz.Carnet)
                raiz.Derecho = EliminarRec(raiz.Derecho, carnet);
            else
            { 
                if (raiz.Izquierdo == null) return raiz.Derecho;
                if (raiz.Derecho == null) return raiz.Izquierdo;
                 
                NodoEstudiante sucesor = ObtenerMinimo(raiz.Derecho);
                 
                raiz.Carnet = sucesor.Carnet;
                raiz.Nombre = sucesor.Nombre;
                 
                raiz.Derecho = EliminarRec(raiz.Derecho, sucesor.Carnet);
            }
            return raiz;
        }

        private NodoEstudiante ObtenerMinimo(NodoEstudiante raiz)
        {
            while (raiz.Izquierdo != null) raiz = raiz.Izquierdo;
            return raiz;
        }

        // Calcular Altura 
        public int ObtenerAltura()
        {
            return CalcularAlturaRec(Raiz);
        }

        private int CalcularAlturaRec(NodoEstudiante nodo)
        {
            if (nodo == null) return 0;  

            int alturaIzq = CalcularAlturaRec(nodo.Izquierdo);
            int alturaDer = CalcularAlturaRec(nodo.Derecho);
             
            return Math.Max(alturaIzq, alturaDer) + 1;
        }

        //Imprimir arbol
        public void ImprimirArbol(NodoEstudiante nodo, string indent, bool last)
        {
            if (nodo != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└─");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─");
                    indent += "| ";
                }
                Console.WriteLine($"{nodo.Carnet} ({nodo.Nombre})");
                ImprimirArbol(nodo.Izquierdo, indent, false);
                ImprimirArbol(nodo.Derecho, indent, true);
            }
        }
    }

}

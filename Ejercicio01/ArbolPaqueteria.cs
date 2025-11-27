using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class ArbolPaqueteria
    {
        public Nodo Raiz;

        // TAREA 1: Insertar manejando duplicados  
        public void Insertar(int orden, Paquete datos)
        {
            Raiz = InsertarRec(Raiz, orden, datos);
        }

        private Nodo InsertarRec(Nodo raiz, int orden, Paquete datos)
        {
            // Si el nodo es nulo, creamos uno nuevo
            if (raiz == null)
            {
                return new Nodo(orden, datos);
            }

            // Lógica de navegación
            if (orden < raiz.NumeroOrden)
            {
                raiz.Izquierdo = InsertarRec(raiz.Izquierdo, orden, datos);
            }
            else if (orden > raiz.NumeroOrden)
            {
                raiz.Derecho = InsertarRec(raiz.Derecho, orden, datos);
            }
            else
            { 
                Console.WriteLine($"-> Orden {orden} ya existe. Actualizando datos...");
                raiz.Datos = datos; // Actualizamos el Value
            }

            return raiz;
        }

        // Recorrido Inorden
        public void InOrden()
        {
            Console.WriteLine("--- Reporte de Paquetes (Inorden) ---");
            InOrdenRec(Raiz);
            Console.WriteLine("\n-------------------------------------");
        }

        private void InOrdenRec(Nodo raiz)
        {
            if (raiz != null)
            {
                InOrdenRec(raiz.Izquierdo);
                Console.WriteLine($"Orden #{raiz.NumeroOrden}: {raiz.Datos}");
                InOrdenRec(raiz.Derecho);
            }
        }

        // Método de Búsqueda para obtener un nodo específico
        public Nodo Buscar(int orden)
        {
            return BuscarRec(Raiz, orden);
        }

        private Nodo BuscarRec(Nodo raiz, int orden)
        {
            if (raiz == null || raiz.NumeroOrden == orden) return raiz;
            if (orden < raiz.NumeroOrden) return BuscarRec(raiz.Izquierdo, orden);
            return BuscarRec(raiz.Derecho, orden);
        }

        // Eliminación 
        public void Eliminar(int orden)
        {
            Raiz = EliminarRec(Raiz, orden);
        }

        private Nodo EliminarRec(Nodo raiz, int orden)
        {
            if (raiz == null) return null;

            if (orden < raiz.NumeroOrden)
                raiz.Izquierdo = EliminarRec(raiz.Izquierdo, orden);
            else if (orden > raiz.NumeroOrden)
                raiz.Derecho = EliminarRec(raiz.Derecho, orden);
            else
            {
                // Nodo encontrado 
                if (raiz.Izquierdo == null) return raiz.Derecho;
                if (raiz.Derecho == null) return raiz.Izquierdo;

                // Dos hijos -> Buscar sucesor (mínimo del subárbol derecho)
                Nodo sucesor = ValorMinimo(raiz.Derecho);

                // Reemplazamos datos
                raiz.NumeroOrden = sucesor.NumeroOrden;
                raiz.Datos = sucesor.Datos;

                // Eliminamos el sucesor antiguo
                raiz.Derecho = EliminarRec(raiz.Derecho, sucesor.NumeroOrden);
            }
            return raiz;
        }

        private Nodo ValorMinimo(Nodo raiz)
        {
            Nodo actual = raiz;
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;
            return actual;
        }

        // Arbol en consola
        public void ImprimirArbol(Nodo nodo, string indent, bool last)
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
                Console.WriteLine($"{nodo.NumeroOrden}");
                ImprimirArbol(nodo.Izquierdo, indent, false);
                ImprimirArbol(nodo.Derecho, indent, true);
            }
        }
    }

}

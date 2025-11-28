using Ejeercicio08.Interfases;
using Ejeercicio08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejeercicio08
{
    public class RedSensoresBST : IGestorIoT
    {
        private Nodo raiz;

        // Inserción
        public void RegistrarDispositivo(int id, string nombre, string firmware)
        {
            raiz = InsertarRec(raiz, new DispositivoIoT(id, nombre, firmware));
        }

        private Nodo InsertarRec(Nodo actual, DispositivoIoT dispositivo)
        {
            if (actual == null) return new Nodo(dispositivo);

            if (dispositivo.Id < actual.Datos.Id)
                actual.Izquierdo = InsertarRec(actual.Izquierdo, dispositivo);
            else if (dispositivo.Id > actual.Datos.Id)
                actual.Derecho = InsertarRec(actual.Derecho, dispositivo);

            return actual;
        }

        // Existencia y Camino
        public bool ExisteDispositivo(int id)
        {
            Console.WriteLine($"\n--- Rastreando dispositivo {id} ---");
            return BuscarRec(raiz, id) != null;
        }

        private Nodo BuscarRec(Nodo actual, int id)
        {
            if (actual == null)
            {
                Console.WriteLine("-> Fin del camino: No encontrado.");
                return null;
            }

            Console.Write($"-> Visitando Nodo {actual.Datos.Id} ");

            if (id == actual.Datos.Id)
            {
                Console.WriteLine("(¡ENCONTRADO!)");
                return actual;
            }

            if (id < actual.Datos.Id)
            {
                Console.WriteLine("(Buscando a la Izquierda)");
                return BuscarRec(actual.Izquierdo, id);
            }
            else
            {
                Console.WriteLine("(Buscando a la Derecha)");
                return BuscarRec(actual.Derecho, id);
            }
        }

        // Actualización
        public void ActualizarFirmware(int id, string nuevoFirmware)
        {
            Console.WriteLine($"\n--- Actualizando firmware de ID {id} ---"); 
            Nodo nodo = ObtenerNodo(raiz, id);
            if (nodo != null)
            {
                Console.WriteLine($"Versión anterior: {nodo.Datos.Firmware}");
                nodo.Datos.Firmware = nuevoFirmware;
                Console.WriteLine($"Versión nueva: {nodo.Datos.Firmware}");
            }
        }

        private Nodo ObtenerNodo(Nodo actual, int id)
        {
            if (actual == null || actual.Datos.Id == id) return actual;
            if (id < actual.Datos.Id) return ObtenerNodo(actual.Izquierdo, id);
            return ObtenerNodo(actual.Derecho, id);
        }

        // Eliminación
        public void EliminarDispositivo(int id)
        {
            Console.WriteLine($"\n--- Eliminando Dispositivo {id} ---");
            raiz = EliminarRec(raiz, id);
        }

        private Nodo EliminarRec(Nodo actual, int id)
        {
            if (actual == null) return null;

            if (id < actual.Datos.Id)
                actual.Izquierdo = EliminarRec(actual.Izquierdo, id);
            else if (id > actual.Datos.Id)
                actual.Derecho = EliminarRec(actual.Derecho, id);
            else
            {
                // Caso 1: Hoja o 1 hijo
                if (actual.Izquierdo == null) return actual.Derecho;
                if (actual.Derecho == null) return actual.Izquierdo;

                // Caso 2: Dos hijos (Caso del 40)
                // Sucesor Inorden: Mínimo del subárbol DERECHO
                Nodo sucesor = ObtenerMinimo(actual.Derecho);

                // Reemplazo de datos
                Console.WriteLine($"   * Reemplazando nodo {actual.Datos.Id} con su sucesor {sucesor.Datos.Id}");
                actual.Datos = sucesor.Datos;

                // Eliminar sucesor antiguo
                actual.Derecho = EliminarRec(actual.Derecho, sucesor.Datos.Id);
            }
            return actual;
        }

        private Nodo ObtenerMinimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null) nodo = nodo.Izquierdo;
            return nodo;
        }
         
        public void MostrarTopologia()
        {
            Console.WriteLine("\nTopología de Red IoT:");
            DibujarRec(raiz, "", true);
        }

        private void DibujarRec(Nodo nodo, string indent, bool last)
        {
            if (nodo != null)
            {
                Console.Write(indent);
                if (last) { Console.Write("└─"); indent += "  "; }
                else { Console.Write("├─"); indent += "| "; }
                Console.WriteLine(nodo.Datos.Id);
                DibujarRec(nodo.Izquierdo, indent, false);
                DibujarRec(nodo.Derecho, indent, true);
            }
        }
    }
}

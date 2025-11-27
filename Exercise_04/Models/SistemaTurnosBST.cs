using Exercise_04.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_04.Models
{
    public class SistemaTurnosBST : IGestorTurnos
    {
        private Nodo raiz;

        // Insertar y Actualizar duplicados
        public void AgendarCita(int turno, string paciente, string especialidad, string hora)
        {
            raiz = InsertarRec(raiz, new CitaMedica(turno, paciente, especialidad, hora));
        }

        private Nodo InsertarRec(Nodo actual, CitaMedica cita)
        {
            if (actual == null) return new Nodo(cita);

            if (cita.NumeroTurno < actual.Datos.NumeroTurno)
            {
                actual.Izquierdo = InsertarRec(actual.Izquierdo, cita);
            }
            else if (cita.NumeroTurno > actual.Datos.NumeroTurno)
            {
                actual.Derecho = InsertarRec(actual.Derecho, cita);
            }
            else
            {
                // Detectar duplicado y actualizar
                Console.WriteLine($"[AVISO] El turno {cita.NumeroTurno} ya existe. Actualizando datos a la versión más reciente...");
                actual.Datos = cita;  
            }
            return actual;
        }

        // Eliminar cita
        public void CancelarCita(int turno)
        {
            Console.WriteLine($"\n--- Cancelando Cita #{turno} ---");
            raiz = EliminarRec(raiz, turno);
        }

        private Nodo EliminarRec(Nodo actual, int turno)
        {
            if (actual == null) return null;

            if (turno < actual.Datos.NumeroTurno)
                actual.Izquierdo = EliminarRec(actual.Izquierdo, turno);
            else if (turno > actual.Datos.NumeroTurno)
                actual.Derecho = EliminarRec(actual.Derecho, turno);
            else
            {
                // Nodo encontrado 
                if (actual.Izquierdo == null) return actual.Derecho;
                if (actual.Derecho == null) return actual.Izquierdo;

                // Dos hijos -> Usaremos el Sucesor Inorden (Mínimo de la derecha)
                Nodo sucesor = ObtenerMinimo(actual.Derecho);

                // Reemplazamos datos
                actual.Datos = sucesor.Datos; 

                // Eliminamos el sucesor original
                actual.Derecho = EliminarRec(actual.Derecho, sucesor.Datos.NumeroTurno);
            }
            return actual;
        }

        private Nodo ObtenerMinimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null) nodo = nodo.Izquierdo;
            return nodo;
        }

        // Recorrido Preorden
        public void MostrarPreorden()
        {
            Console.WriteLine("\n--- Recorrido Preorden (Raíz -> Izq -> Der) ---");
            PreordenRec(raiz);
            Console.WriteLine();
        }

        private void PreordenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.WriteLine(nodo.Datos);  
                PreordenRec(nodo.Izquierdo);    
                PreordenRec(nodo.Derecho);     
            }
        }
         
        public void DibujarArbol()
        {
            Console.WriteLine("\nEstado actual del árbol de turnos:");
            DibujarRec(raiz, "", true);
        }

        private void DibujarRec(Nodo nodo, string indent, bool last)
        {
            if (nodo != null)
            {
                Console.Write(indent);
                if (last) { Console.Write("└─"); indent += "  "; }
                else { Console.Write("├─"); indent += "| "; }
                Console.WriteLine(nodo.Datos.NumeroTurno);
                DibujarRec(nodo.Izquierdo, indent, false);
                DibujarRec(nodo.Derecho, indent, true);
            }
        }
    }
}

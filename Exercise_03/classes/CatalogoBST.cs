using Exercise_03.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_03.classes
{
    public class CatalogoBST : ICatalogo
    {
        private Nodo raiz;

        public void AgregarLibro(int codigo, string titulo)
        {
            raiz = InsertarRec(raiz, new Libro(codigo, titulo));
        }

        private Nodo InsertarRec(Nodo actual, Libro libro)
        {
            if (actual == null) return new Nodo(libro);

            if (libro.Codigo < actual.Datos.Codigo)
                actual.Izquierdo = InsertarRec(actual.Izquierdo, libro);
            else if (libro.Codigo > actual.Datos.Codigo)
                actual.Derecho = InsertarRec(actual.Derecho, libro);

            return actual;
        }

        //Búsqueda con traza explicativa
        public void BuscarLibro(int codigo)
        {
            Console.WriteLine($"\n--- Buscando libro código {codigo} ---");
            Nodo encontrado = BuscarRec(raiz, codigo);
            if (encontrado == null)
                Console.WriteLine("Resultado: El libro NO existe en el catálogo.");
            else
                Console.WriteLine($"Resultado: Encontrado -> {encontrado.Datos.Titulo}");
        }

        private Nodo BuscarRec(Nodo actual, int codigo)
        {
            if (actual == null) return null;

            Console.WriteLine($"Comparando {codigo} con nodo actual [{actual.Datos.Codigo}]...");

            if (codigo == actual.Datos.Codigo) return actual;

            if (codigo < actual.Datos.Codigo)
            {
                Console.WriteLine("-> Ir a la Izquierda");
                return BuscarRec(actual.Izquierdo, codigo);
            }
            else
            {
                Console.WriteLine("-> Ir a la Derecha");
                return BuscarRec(actual.Derecho, codigo);
            }
        }

        public Libro ObtenerMinimo()
        {
            if (raiz == null) return null;
            Nodo actual = raiz;
            while (actual.Izquierdo != null) actual = actual.Izquierdo;
            return actual.Datos;
        }

        public Libro ObtenerMaximo()
        {
            if (raiz == null) return null;
            Nodo actual = raiz;
            while (actual.Derecho != null) actual = actual.Derecho;
            return actual.Datos;
        }
         
        public void MostrarPostOrden()
        {
            Console.WriteLine("\n--- Recorrido PostOrden ---");
            PostOrdenRec(raiz);
            Console.WriteLine();
        }

        private void PostOrdenRec(Nodo actual)
        {
            if (actual != null)
            {
                PostOrdenRec(actual.Izquierdo); 
                PostOrdenRec(actual.Derecho);  
                Console.Write(actual.Datos.Codigo + " "); // Raíz
            }
        }
         
        public void EliminarLibro(int codigo)
        {
            raiz = EliminarRec(raiz, codigo);
        }

        private Nodo EliminarRec(Nodo actual, int codigo)
        {
            if (actual == null) return null;

            if (codigo < actual.Datos.Codigo)
                actual.Izquierdo = EliminarRec(actual.Izquierdo, codigo);
            else if (codigo > actual.Datos.Codigo)
                actual.Derecho = EliminarRec(actual.Derecho, codigo);
            else
            {
                // Nodo encontrado 
                if (actual.Izquierdo == null) return actual.Derecho;
                if (actual.Derecho == null) return actual.Izquierdo;

                // Dos hijos. Buscar sucesor Inorden 
                Nodo sucesor = ObtenerNodoMinimo(actual.Derecho);

                // Reemplazar datos
                actual.Datos = sucesor.Datos;

                // Eliminar sucesor antiguo
                actual.Derecho = EliminarRec(actual.Derecho, sucesor.Datos.Codigo);
            }
            return actual;
        }

        private Nodo ObtenerNodoMinimo(Nodo nodo)
        {
            Nodo actual = nodo;
            while (actual.Izquierdo != null) actual = actual.Izquierdo;
            return actual;
        }
         
        public void Dibujar()
        {
            Console.WriteLine("\nEstado actual del árbol:");
            DibujarRec(raiz, "", true);
        }

        private void DibujarRec(Nodo nodo, string indent, bool last)
        {
            if (nodo != null)
            {
                Console.Write(indent);
                if (last) { Console.Write("└─"); indent += "  "; }
                else { Console.Write("├─"); indent += "| "; }
                Console.WriteLine(nodo.Datos.Codigo);
                DibujarRec(nodo.Izquierdo, indent, false);
                DibujarRec(nodo.Derecho, indent, true);
            }
        }
    }
}

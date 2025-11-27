using Exercise_05.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05.Models
{
    public class InventarioBST : IGestorInventario
    {
        private Nodo raiz;

        //Construcción del árbol
        public void RegistrarProducto(int codigo, string nombre, string categoria, int stock)
        {
            raiz = InsertarRec(raiz, new Producto(codigo, nombre, categoria, stock));
        }

        private Nodo InsertarRec(Nodo actual, Producto producto)
        {
            if (actual == null) return new Nodo(producto);

            if (producto.Codigo < actual.Datos.Codigo)
                actual.Izquierdo = InsertarRec(actual.Izquierdo, producto);
            else if (producto.Codigo > actual.Datos.Codigo)
                actual.Derecho = InsertarRec(actual.Derecho, producto);

            return actual;
        }

        //Actualizar existencia
        public void ActualizarStock(int codigo, int nuevoStock)
        {
            Console.WriteLine($"\n--- Buscando producto {codigo} para ajuste de inventario ---");
            Nodo nodo = BuscarRec(raiz, codigo);
            if (nodo != null)
            {
                Console.WriteLine($"Producto encontrado: {nodo.Datos.Nombre}. Stock anterior: {nodo.Datos.Existencia}");
                nodo.Datos.Existencia = nuevoStock;
                Console.WriteLine($">> Stock actualizado a: {nodo.Datos.Existencia}");
            }
            else
            {
                Console.WriteLine("Error: Producto no encontrado.");
            }
        }

        private Nodo BuscarRec(Nodo actual, int codigo)
        {
            if (actual == null || actual.Datos.Codigo == codigo) return actual;

            if (codigo < actual.Datos.Codigo)
                return BuscarRec(actual.Izquierdo, codigo);

            return BuscarRec(actual.Derecho, codigo);
        }

        //Eliminar producto (Descontinuar)
        public void DescontinuarProducto(int codigo)
        {
            Console.WriteLine($"\n--- Descontinuando producto {codigo} ---");
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
                if (actual.Izquierdo == null && actual.Derecho == null)
                { 
                    return null;
                }
                 
                if (actual.Izquierdo == null) return actual.Derecho;
                if (actual.Derecho == null) return actual.Izquierdo;
                 
                Nodo sucesor = ObtenerMinimo(actual.Derecho);
                actual.Datos = sucesor.Datos;
                actual.Derecho = EliminarRec(actual.Derecho, sucesor.Datos.Codigo);
            }
            return actual;
        }

        private Nodo ObtenerMinimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null) nodo = nodo.Izquierdo;
            return nodo;
        }

        //Recorrido Inorden 
        public void GenerarReporteExcel()
        {
            Console.WriteLine("\n--- Generando Listado para Excel (Orden Ascendente) ---");
            InOrdenRec(raiz);
            Console.WriteLine("-------------------------------------------------------");
        }

        private void InOrdenRec(Nodo actual)
        {
            if (actual != null)
            {
                InOrdenRec(actual.Izquierdo);
                Console.WriteLine(actual.Datos); 
                InOrdenRec(actual.Derecho);
            }
        }
         
        public void DibujarMapaBodega()
        {
            Console.WriteLine("\nMapa actual de la Bodega (Estructura BST):");
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

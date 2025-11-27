using Exercise_07.Interfases;
using Exercise_07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_07
{
    public class ServidorBST : IMigrador
    {
        private Nodo raiz;

        public void InsertarUsuario(int id)
        {
            raiz = InsertarRec(raiz, new Usuario(id));
        }

        private Nodo InsertarRec(Nodo actual, Usuario user)
        {
            if (actual == null) return new Nodo(user);

            if (user.Id < actual.Usuario.Id)
                actual.Izquierdo = InsertarRec(actual.Izquierdo, user);
            else if (user.Id > actual.Usuario.Id)
                actual.Derecho = InsertarRec(actual.Derecho, user);

            return actual;
        }

        // Recorrido para exportar en orden
        public List<Usuario> ExportarDatosAscendentes()
        {
            List<Usuario> listaExportacion = new List<Usuario>();
            InOrdenRec(raiz, listaExportacion);
            return listaExportacion;
        }

        private void InOrdenRec(Nodo actual, List<Usuario> lista)
        {
            if (actual != null)
            {
                InOrdenRec(actual.Izquierdo, lista); // 1. Izquierda (Menores)
                lista.Add(actual.Usuario);           // 2. Raíz (Actual)
                InOrdenRec(actual.Derecho, lista);   // 3. Derecha (Mayores)
            }
        }

        //Eliminar nodo 900
        public void EliminarUsuario(int id)
        {
            Console.WriteLine($"\n--- Dando de baja al usuario {id} ---");
            raiz = EliminarRec(raiz, id);
        }

        private Nodo EliminarRec(Nodo actual, int id)
        {
            if (actual == null) return null;

            if (id < actual.Usuario.Id)
                actual.Izquierdo = EliminarRec(actual.Izquierdo, id);
            else if (id > actual.Usuario.Id)
                actual.Derecho = EliminarRec(actual.Derecho, id);
            else
            {
                // Nodo encontrado 
                if (actual.Izquierdo == null) return actual.Derecho;
                if (actual.Derecho == null) return actual.Izquierdo;

                //  Reemplazar por el Sucesor Inorden 
                Nodo sucesor = ObtenerMinimo(actual.Derecho);

                // Copiamos datos del sucesor
                actual.Usuario = sucesor.Usuario;

                // Eliminamos el sucesor original
                actual.Derecho = EliminarRec(actual.Derecho, sucesor.Usuario.Id);
            }
            return actual;
        }

        private Nodo ObtenerMinimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null) nodo = nodo.Izquierdo;
            return nodo;
        }
         
        public void MostrarArbol()
        {
            Console.WriteLine("\nEstructura actual del Servidor:");
            DibujarRec(raiz, "", true);
        }

        private void DibujarRec(Nodo nodo, string indent, bool last)
        {
            if (nodo != null)
            {
                Console.Write(indent);
                if (last) { Console.Write("└─"); indent += "  "; }
                else { Console.Write("├─"); indent += "| "; }
                Console.WriteLine(nodo.Usuario.Id);
                DibujarRec(nodo.Izquierdo, indent, false);
                DibujarRec(nodo.Derecho, indent, true);
            }
        }
    }
}

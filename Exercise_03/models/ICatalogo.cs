using Exercise_03.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_03.models
{ 
    public interface ICatalogo
    {
        void AgregarLibro(int codigo, string titulo);
        void BuscarLibro(int codigo);
        Libro ObtenerMinimo();
        Libro ObtenerMaximo();
        void MostrarPostOrden();
        void EliminarLibro(int codigo);
    }
}

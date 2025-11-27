using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05.Interfases
{
    public interface IGestorInventario
    {
        void RegistrarProducto(int codigo, string nombre, string categoria, int stock);
        void ActualizarStock(int codigo, int nuevoStock);
        void DescontinuarProducto(int codigo);
        void GenerarReporteExcel();  
        void DibujarMapaBodega();  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_06.Interfases
{
    public interface IArbolAnalisis
    {
        void Insertar(int key);
        int ObtenerAltura();
        int ContarComparaciones(int keyBuscada); // Retorna el número de pasos
        void Dibujar();
    }
}

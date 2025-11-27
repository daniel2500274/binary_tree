using Exercise_07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_07.Interfases
{
    public interface IMigrador
    {
        void InsertarUsuario(int id);
        void EliminarUsuario(int id); 
        List<Usuario> ExportarDatosAscendentes();  
        void MostrarArbol(); 
    }
}

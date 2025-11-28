using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejeercicio08.Interfases
{
    public interface IGestorIoT
    {
        void RegistrarDispositivo(int id, string nombre, string firmware);
        bool ExisteDispositivo(int id);
        void ActualizarFirmware(int id, string nuevoFirmware);
        void EliminarDispositivo(int id);
        void MostrarTopologia();
    }
}

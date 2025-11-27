using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_04.Interfases
{
    public interface IGestorTurnos
    {
        void AgendarCita(int turno, string paciente, string especialidad, string hora);
        void CancelarCita(int turno);
        void MostrarPreorden();
        void DibujarArbol(); 
    }
}

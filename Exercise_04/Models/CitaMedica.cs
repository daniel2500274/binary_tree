using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_04.Models
{
    public class CitaMedica
    {
        public int NumeroTurno { get; set; }  
        public string Paciente { get; set; }
        public string Especialidad { get; set; }
        public string Hora { get; set; }

        public CitaMedica(int turno, string paciente, string especialidad, string hora)
        {
            NumeroTurno = turno;
            Paciente = paciente;
            Especialidad = especialidad;
            Hora = hora;
        }

        public override string ToString()
        {
            return $"[Turno {NumeroTurno}] {Paciente} ({Especialidad} - {Hora})";
        }
    }
}

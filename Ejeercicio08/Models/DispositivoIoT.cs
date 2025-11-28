using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejeercicio08.Models
{
    public class DispositivoIoT
    {
        public int Id { get; set; } // Key
        public string Nombre { get; set; }
        public string Firmware { get; set; } // Value actualizable

        public DispositivoIoT(int id, string nombre, string firmware)
        {
            Id = id;
            Nombre = nombre;
            Firmware = firmware;
        }

        public override string ToString()
        {
            return $"[ID: {Id}] {Nombre} (v.{Firmware})";
        }
    }
}

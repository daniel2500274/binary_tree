using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_07.Models
{
    public class Usuario
    {
        public int Id { get; set; } // Key (1000, 900...)
        public string Datos { get; set; } // Value dummy

        public Usuario(int id)
        {
            Id = id;
            Datos = $"DatosUser_{id}";
        }

        public override string ToString()
        {
            return $"[ID: {Id}]";
        }
    }
}

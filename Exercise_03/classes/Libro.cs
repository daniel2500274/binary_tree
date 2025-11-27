using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_03.classes
{ 
    public class Libro
    {
        public int Codigo { get; set; } // Key
        public string Titulo { get; set; } // Value

        public Libro(int codigo, string titulo)
        {
            Codigo = codigo;
            Titulo = titulo;
        }

        public override string ToString()
        {
            return $"[{Codigo}] {Titulo}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Paquete
    {
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public double Peso { get; set; }

        public Paquete(string cliente, string direccion, double peso)
        {
            Cliente = cliente;
            Direccion = direccion;
            Peso = peso;
        }

        public override string ToString()
        {
            return $"[Cliente: {Cliente}, Dir: {Direccion}, Peso: {Peso}kg]";
        }
    }

}

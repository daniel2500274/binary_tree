using Ejeercicio08;
using Ejeercicio08.Interfases;
using System;

class Program
{
    static void Main(string[] args)
    {
        IGestorIoT red = new RedSensoresBST();

        // Insertar claves: 40, 10, 20, 5, 50, 45, 60, 42
        Console.WriteLine("1. Configurando red de sensores...");
        int[] ids = { 40, 10, 20, 5, 50, 45, 60, 42 };
        foreach (int id in ids)
            red.RegistrarDispositivo(id, $"Sensor-{id}", "1.0");

        red.MostrarTopologia();

        // Buscar 42 y explicar camino
        bool existe = red.ExisteDispositivo(42);
        // La consola mostrará el camino paso a paso gracias a la lógica en RedSensoresBST

        // Actualizar firmware del 10
        red.ActualizarFirmware(10, "2.5-BETA");

        // Eliminar dispositivo 40 (Raíz)
        red.EliminarDispositivo(40);
        red.MostrarTopologia(); 
    }
}
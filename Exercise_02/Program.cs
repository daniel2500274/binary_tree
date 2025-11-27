using System;
using Exercise_02; 
class Program
{
    static void Main(string[] args)
    {
        ArbolUniversitario system = new ArbolUniversitario();

        //Carga inicial de datos [1050, 1020, 1100, 1010, 1030, 1080, 1150]
        Console.WriteLine("--- Inicializando Sistema Universitario ---");
        system.Insertar(1050, "Carlos (Raíz)");
        system.Insertar(1020, "Ana");
        system.Insertar(1100, "Luis");
        system.Insertar(1010, "Sofia");
        system.Insertar(1030, "Jorge");
        system.Insertar(1080, "Lucia");
        system.Insertar(1150, "Mario");

        system.ImprimirArbol(system.Raiz, "", true);

        // Existencia de carnets
        Console.WriteLine("\n1. Verificando existencia de estudiantes:");
        Console.WriteLine($"   - ¿Existe 1020? {system.Contiene(1020)}");
        Console.WriteLine($"   - ¿Existe 1050? {system.Contiene(1050)}");
        Console.WriteLine($"   - ¿Existe 1100? {system.Contiene(1100)}");

        // Eliminar carnet 1050 
        Console.WriteLine("\n2. Eliminando carnet 1050 ");
        system.Eliminar(1050);

        Console.WriteLine("   Árbol resultante:");
        system.ImprimirArbol(system.Raiz, "", true);

        // Determinar altura
        int altura = system.ObtenerAltura();
        Console.WriteLine($"\n3. Altura del árbol actual: {altura}"); 
    }
}
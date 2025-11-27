using System;
using Ejercicio01;
class Program
{
    static void Main(string[] args)
    {
        ArbolPaqueteria bst = new ArbolPaqueteria();

        // Insertar paquetes [50, 20, 80, 10, 30, 25, 70, 90]
        Console.WriteLine("1. Insertando paquetes...");
        bst.Insertar(50, new Paquete("Juan", "Zona 1", 1.5));
        bst.Insertar(20, new Paquete("Maria", "Zona 10", 2.0));
        bst.Insertar(80, new Paquete("Pedro", "Zona 4", 5.0));
        bst.Insertar(10, new Paquete("Luis", "Zona 5", 0.5));
        bst.Insertar(30, new Paquete("Ana", "Zona 9", 1.2));
        bst.Insertar(25, new Paquete("Sofia", "Carretera", 3.0));  
        bst.Insertar(70, new Paquete("Carlos", "Mixco", 2.5));
        bst.Insertar(90, new Paquete("Diana", "Xela", 4.0));

        // Dibujar árbol resultante
        Console.WriteLine("\n2. Árbol Resultante:");
        bst.ImprimirArbol(bst.Raiz, "", true);

        //  Recorrido Inorden 
        bst.InOrden();

        // Cliente orden 30 cambia dirección
        Console.WriteLine("3. Actualizando Orden 30...");
        Nodo orden30 = bst.Buscar(30);
        if (orden30 != null)
        {
            Console.WriteLine($"   Antes: {orden30.Datos.Direccion}");
            orden30.Datos.Direccion = "NUEVA DIRECCIÓN ZONA 15"; 
            Console.WriteLine($"   Ahora: {orden30.Datos.Direccion}");
        }

        // Eliminar la orden 20
        Console.WriteLine("\n4. Eliminando Orden 20 y mostrando árbol final...");
        bst.Eliminar(20);
        bst.ImprimirArbol(bst.Raiz, "", true);
    }
}
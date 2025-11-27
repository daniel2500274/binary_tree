using Exercise_03.classes;
using Exercise_03.models;

class Program
{
    static void Main(string[] args)
    { 
        ICatalogo biblioteca = new CatalogoBST();

        //Insertar libros [40, 20, 60, 10, 30, 50, 70, 65, 80]
        Console.WriteLine("        1. Insertando libros...");
        Console.WriteLine(" [40, 20, 60, 10, 30, 50, 70, 65, 80]");
        int[] codigos = { 40, 20, 60, 10, 30, 50, 70, 65, 80 };
        foreach (int c in codigos) biblioteca.AgregarLibro(c, $"Libro {c}");

        ((CatalogoBST)biblioteca).Dibujar(); 

        //Buscar código 33  
        biblioteca.BuscarLibro(33);

        //Mínimo y Máximo
        Console.WriteLine($"\n3. Código Mínimo: {biblioteca.ObtenerMinimo()?.Codigo}");
        Console.WriteLine($"   Código Máximo: {biblioteca.ObtenerMaximo()?.Codigo}");

        //Recorrido PostOrden 
        biblioteca.MostrarPostOrden();

        //Eliminar libro 60
        Console.WriteLine("\n\n5. Eliminando libro 60...");
        biblioteca.EliminarLibro(60);
        ((CatalogoBST)biblioteca).Dibujar();
    }
}
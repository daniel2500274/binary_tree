using Exercise_05.Interfases;
using Exercise_05.Models;

class Program
{
    static void Main(string[] args)
    {
        IGestorInventario bodega = new InventarioBST();

        // Construir el árbol con los códigos dados
        // 500, 250, 750, 125, 375, 625, 900, 100, 130, 620, 630
        Console.WriteLine("1. Inicializando inventario tras cambio de proveedor...");
        Console.WriteLine("[500, 250, 750, 125, 375, 625, 900, 100, 130, 620, 630]");
        int[] codigos = { 500, 250, 750, 125, 375, 625, 900, 100, 130, 620, 630 };

        foreach (int c in codigos)
            bodega.RegistrarProducto(c, $"Prod-{c}", "General", 100);  

        bodega.DibujarMapaBodega();

        // Indicar recorrido Inorden 
        bodega.GenerarReporteExcel();

        // Localizar producto 620 y actualizar existencia a "0"
        bodega.ActualizarStock(620, 0);

        // Descontinuar producto 375 
        bodega.DescontinuarProducto(375);
        bodega.DibujarMapaBodega();    
        // Listado completo ordenado ascendente (Explicación abajo)
        bodega.GenerarReporteExcel();
    }
}
using Exercise_06;
using Exercise_06.Interfases;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ANÁLISIS DE DESEMPEÑO BST ===\n");

        // Inserción Secuencial (1, 2, 3, 4, 5, 6, 7)
        IArbolAnalisis arbolA = new ArbolBinario();
        int[] datosA = { 1, 2, 3, 4, 5, 6, 7 };
        foreach (int k in datosA) arbolA.Insertar(k);

        Console.WriteLine("--- CASO A: Inserción Ordenada (1 al 7) ---");
        arbolA.Dibujar();
        int alturaA = arbolA.ObtenerAltura();
        int compA = arbolA.ContarComparaciones(7);
        Console.WriteLine($"\n-> Altura (Niveles): {alturaA}");
        Console.WriteLine($"-> Comparaciones para buscar el 7: {compA} pasos");

        Console.WriteLine("\n" + new string('-', 40) + "\n");

        // Inserción Balanceada (4, 2, 6, 1, 3, 5, 7)
        IArbolAnalisis arbolB = new ArbolBinario();
        int[] datosB = { 4, 2, 6, 1, 3, 5, 7 };
        foreach (int k in datosB) arbolB.Insertar(k);

        Console.WriteLine("--- CASO B: Inserción Estratégica (4, 2, 6...) ---");
        arbolB.Dibujar();
        int alturaB = arbolB.ObtenerAltura();
        int compB = arbolB.ContarComparaciones(7);
        Console.WriteLine($"\n-> Altura (Niveles): {alturaB}");
        Console.WriteLine($"-> Comparaciones para buscar el 7: {compB} pasos");

        // Conclusión Automática
        Console.WriteLine("\n=== CONCLUSIÓN ===");
        if (compA > compB)
        {
            Console.WriteLine($"El Caso B es {Math.Round((double)compA / compB, 1)} veces más rápido.");
            Console.WriteLine("El orden de inserción determina la forma del árbol.");
        }
    }
}
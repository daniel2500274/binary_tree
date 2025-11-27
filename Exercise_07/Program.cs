using Exercise_07;
using Exercise_07.Interfases;
using Exercise_07.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IMigrador servidorViejo = new ServidorBST();

        //Carga inicial de datos 
        int[] ids = { 1000, 900, 1100, 850, 950, 1050, 1200, 930, 960 };
        foreach (int id in ids) servidorViejo.InsertarUsuario(id);

        servidorViejo.MostrarArbol();

        //Exportar en orden ascendente
        Console.WriteLine("\n=== INICIANDO MIGRACIÓN ===");
        List<Usuario> datosExportados = servidorViejo.ExportarDatosAscendentes();

        Console.WriteLine("Datos exportados (Orden exacto):");
        Console.WriteLine(string.Join(" -> ", datosExportados));

        //Eliminar nodo 900
        servidorViejo.EliminarUsuario(900);
        servidorViejo.MostrarArbol(); 
    }
}
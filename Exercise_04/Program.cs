using Exercise_04.Interfases;
using Exercise_04.Models;
class Program
{
    static void Main(string[] args)
    {
        IGestorTurnos hospital = new SistemaTurnosBST();

        // Insertar claves: 15, 10, 25, 5, 12, 20, 30, 11, 13
        Console.WriteLine("   1. Generando turnos médicos...");
        Console.WriteLine(" [15, 10, 25, 5, 12, 20, 30, 11, 13]");
        int[] turnos = { 15, 10, 25, 5, 12, 20, 30, 11, 13 };

        foreach (int t in turnos)
            hospital.AgendarCita(t, $"Paciente {t}", "General", "08:00");

        hospital.DibujarArbol();

        // Cita 10 duplicada  
        Console.WriteLine("\n2. Intentando duplicar la Cita 10...");
        hospital.AgendarCita(10, "Juan Perez (ACTUALIZADO)", "Cardiología", "09:30");
        hospital.DibujarArbol();

        // Cancelar cita 25
        hospital.CancelarCita(25);
        hospital.DibujarArbol();
        hospital.DibujarArbol();

        // Recorrido Preorden
        hospital.MostrarPreorden();
    }
}
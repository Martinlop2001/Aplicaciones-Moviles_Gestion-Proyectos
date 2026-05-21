using System;
class Ejercicio05
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== CALCULADORA DE PROPINA ===\n");
        Console.Write("Monto de la cuenta: $");
        double cuenta = double.Parse(Console.ReadLine());
        Console.Write("Porcentaje de propina (10, 15 o 20): ");
        int porcentaje = int.Parse(Console.ReadLine());
        Console.Write("¿Entre cuántas personas se divide?: ");
        int personas = int.Parse(Console.ReadLine());
        // Calcular
        double propina = cuenta * porcentaje / 100;
        double total = cuenta + propina;
        double porPersona = total / personas;
        // Mostrar resultados
        Console.WriteLine($"\nPropina: ${propina:F2}");
        Console.WriteLine($"Total: ${total:F2}");
        Console.WriteLine($"Por persona: ${porPersona:F2}");
    }
}
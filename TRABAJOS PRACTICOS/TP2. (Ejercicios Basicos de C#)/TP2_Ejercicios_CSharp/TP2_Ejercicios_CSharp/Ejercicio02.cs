

using System;
class Ejercicio02
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== CONVERSOR DE TEMPERATURA ===\n");
        Console.Write("Ingresa temperatura en Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        // Conversiones
        double fahrenheit = celsius * 9 / 5 + 32;
        double kelvin = celsius + 273.15;
        // Mostrar resultados
        Console.WriteLine($"\n{celsius}°C equivale a:");
        Console.WriteLine($"- {fahrenheit:F2}°F (Fahrenheit)");
        Console.WriteLine($"- {kelvin:F2} K (Kelvin)");
    }
}
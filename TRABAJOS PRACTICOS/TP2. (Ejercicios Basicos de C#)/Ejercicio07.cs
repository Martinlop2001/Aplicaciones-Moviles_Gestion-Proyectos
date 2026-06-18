using System;
class Ejercicio07
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== TABLA DE MULTIPLICAR ===\n");
        Console.Write("Ingresa un número: ");
        int numero = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nTabla del {numero}:");
        for (int i = 1; i <= 10; i++)
        {
            int resultado = numero * i;

            Console.WriteLine($"{numero} × {i} = {resultado}");
        }
    }
}
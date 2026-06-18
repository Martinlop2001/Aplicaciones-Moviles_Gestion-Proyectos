using System;
class Ejercicio08
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== NÚMEROS PARES E IMPARES ===\n");
        for (int i = 1; i <= 50; i++)
        {
            string tipo = (i % 2 == 0) ? "Par" : "Impar";
            Console.WriteLine($"{i} - {tipo}");
        }
    }
}



using System;
class Ejercicio04
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== CALCULADORA DE EDAD ===\n");
        Console.Write("Ingresa tu año de nacimiento: ");
        int añoNacimiento = int.Parse(Console.ReadLine());
        int añoActual = DateTime.Now.Year;
        int edad = añoActual - añoNacimiento;
        Console.WriteLine($"\nTienes {edad} años");
        if (edad >= 18)
            Console.WriteLine("Eres mayor de edad");
        else
            Console.WriteLine($"Eres menor de edad (te faltan {18 - edad} años)");
    }
}
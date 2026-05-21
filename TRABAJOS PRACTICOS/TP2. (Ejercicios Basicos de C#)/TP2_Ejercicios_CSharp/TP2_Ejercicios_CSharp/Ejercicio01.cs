

using System;
class Ejercicio01
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== CALCULADORA BÁSICA ===\n");
        // Pedir números
        Console.Write("Ingresa el primer número: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Ingresa el segundo número: ");
        double num2 = double.Parse(Console.ReadLine());
        // Realizar operaciones
        double suma = num1 + num2;
        double resta = num1 - num2;
        double multiplicacion = num1 * num2;
        double division = num1 / num2;
        double modulo = num1 % num2;
        // Mostrar resultados
        Console.WriteLine("\nResultados:");
        Console.WriteLine($"{num1} + {num2} = {suma}");
        Console.WriteLine($"{num1} - {num2} = {resta}");
        Console.WriteLine($"{num1} × {num2} = {multiplicacion}");
        Console.WriteLine($"{num1} ÷ {num2} = {division:F2}");
        Console.WriteLine($"{num1} % {num2} = {modulo}");
    }
}
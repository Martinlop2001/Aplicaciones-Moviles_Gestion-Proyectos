using System;
class Ejercicio12
{
    static double Sumar(double a, double b) => a + b;
    static double Restar(double a, double b) => a - b;
    static double Multiplicar(double a, double b) => a * b;
    static double Dividir(double a, double b) => b != 0 ? a / b : 0;
    static void MostrarResultado(string operacion, double resultado)
    {
        Console.WriteLine($"\nResultado de {operacion}: {resultado}");
    }
    public static void Ejecutar()
    {
        Console.WriteLine("=== CALCULADORA CON MÉTODOS ===\n");
        Console.Write("Primer número: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Segundo número: ");
        double num2 = double.Parse(Console.ReadLine());
        MostrarResultado("suma", Sumar(num1, num2));
        MostrarResultado("resta", Restar(num1, num2));
        MostrarResultado("multiplicación", Multiplicar(num1, num2));
        if (num2 != 0)
            MostrarResultado("división", Dividir(num1, num2));
        else
            Console.WriteLine("\nNo se puede dividir por cero");
    }
}
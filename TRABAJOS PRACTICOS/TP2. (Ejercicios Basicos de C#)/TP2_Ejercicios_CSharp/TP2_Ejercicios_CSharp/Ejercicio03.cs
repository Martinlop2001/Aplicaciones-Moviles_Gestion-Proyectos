using System;
class Ejercicio03
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== CALCULADORA DE IMC ===\n");
        Console.Write("Ingresa tu peso (kg): ");
        double peso = double.Parse(Console.ReadLine());
        Console.Write("Ingresa tu altura (m): ");
        double altura = double.Parse(Console.ReadLine());
        // Calcular IMC
        double imc = peso / (altura * altura);
        // Determinar clasificación
        string clasificacion;
        if (imc < 18.5)
            clasificacion = "Bajo peso";
        else if (imc < 25)
            clasificacion = "Normal";
        else if (imc < 30)
            clasificacion = "Sobrepeso";
        else
            clasificacion = "Obesidad";
        // Mostrar resultado
        Console.WriteLine($"\nTu IMC es: {imc:F2}");
        Console.WriteLine($"Clasificación: {clasificacion}");
    }
}
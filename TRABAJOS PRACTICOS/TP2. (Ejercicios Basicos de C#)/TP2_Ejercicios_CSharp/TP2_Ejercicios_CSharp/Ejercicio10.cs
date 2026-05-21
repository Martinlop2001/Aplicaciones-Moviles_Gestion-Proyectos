using System;
using System.Runtime.ConstrainedExecution;
class Ejercicio10
{
    public static void Ejecutar()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== CALCULADORA ===");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Potencia");
            Console.WriteLine("6. Salir");
            Console.Write("\nElige una opción: ");
            int opcion = int.Parse(Console.ReadLine());
            if (opcion == 6)
            {
                continuar = false;
                Console.WriteLine("¡Hasta luego!");
                continue;
            }
            if (opcion < 1 || opcion > 6)
            {
                Console.WriteLine("Opción inválida");
                Console.ReadLine();
                continue;
            }
            Console.Write("Primer número: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Segundo número: ");
            double num2 = double.Parse(Console.ReadLine());
            double resultado = 0;
            string operacion = "";
            switch (opcion)
            {
                case 1:
                    resultado = num1 + num2;
                    operacion = "suma";
                    break;
                case 2:
                    resultado = num1 - num2;
                    operacion = "resta";
                    break;
                case 3:
                    resultado = num1 * num2;
                    operacion = "multiplicación";
                    break;
                case 4:
                    if (num2 != 0)
                    {
                        resultado = num1 / num2;
                        operacion = "división";
                    }
                    else
                    {
                        Console.WriteLine("\nError: No se puede dividir por cero");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                case 5:
                    resultado = Math.Pow(num1, num2);
                    operacion = "potencia";
                    break;
            }
            Console.WriteLine($"\nResultado de la {operacion}:{ resultado}");
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();
        }
    }
}
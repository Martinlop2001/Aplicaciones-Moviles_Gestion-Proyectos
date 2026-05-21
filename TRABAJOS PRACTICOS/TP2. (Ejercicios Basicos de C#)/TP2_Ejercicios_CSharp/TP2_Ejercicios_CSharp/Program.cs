using System;
class Program
{
    static void Main()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== TRABAJO PRÁCTICO 2 ===");
            Console.WriteLine("\nPARTE 1: Variables y Operadores");
            Console.WriteLine("1. Calculadora Básica");
            Console.WriteLine("2. Conversor de Temperatura");
            Console.WriteLine("3. Calculadora de IMC");
            Console.WriteLine("4. Calculadora de Edad");
            Console.WriteLine("5. Calculadora de Propina");

            Console.WriteLine("\nPARTE 2: Estructuras de Control");
            Console.WriteLine("6. Día de la Semana");
            Console.WriteLine("7. Tabla de Multiplicar");
            Console.WriteLine("8. Números Pares e Impares");
            Console.WriteLine("9. Adivina el Número");

            Console.WriteLine("10. Menú de Calculadora");
            Console.WriteLine("\nPARTE 3: Métodos");
            Console.WriteLine("11. Métodos de Validación");
            Console.WriteLine("12. Calculadora con Métodos");
            Console.WriteLine("13. Generador de Contraseñas");
            Console.WriteLine("\n0. Salir");

            Console.Write("\nElige un ejercicio: ");
            int opcion = int.Parse(Console.ReadLine());

            Console.Clear();
            switch (opcion)
            {
                case 1: Ejercicio01.Ejecutar(); break;
                case 2: Ejercicio02.Ejecutar(); break;
                case 3: Ejercicio03.Ejecutar(); break;
                case 4: Ejercicio04.Ejecutar(); break;
                case 5: Ejercicio05.Ejecutar(); break;
                case 6: Ejercicio06.Ejecutar(); break;
                case 7: Ejercicio07.Ejecutar(); break;
                case 8: Ejercicio08.Ejecutar(); break;
                case 9: Ejercicio09.Ejecutar(); break;
                case 10: Ejercicio10.Ejecutar(); break;
                case 11: Ejercicio11.Ejecutar(); break;
                case 12: Ejercicio12.Ejecutar(); break;
                case 13: Ejercicio13.Ejecutar(); break;
                case 0:
                    continuar = false;
                    Console.WriteLine("¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
            if (continuar)
            {
                Console.WriteLine("\n\nPresiona Enter para volver al menú...");
                Console.ReadLine();
            }
        }
    }
}
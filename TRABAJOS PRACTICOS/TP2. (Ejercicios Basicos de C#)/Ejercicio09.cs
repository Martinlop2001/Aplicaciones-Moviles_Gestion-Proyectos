using System;
class Ejercicio09
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== ADIVINA EL NÚMERO ===\n");
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int intentos = 7;
        bool adivinado = false;
        Console.WriteLine("Adivina el número entre 1 y 100");
        Console.WriteLine($"Tienes {intentos} intentos\n");
        for (int i = 1; i <= intentos; i++)
        {
            Console.Write($"Intento {i}/{intentos}: ");
            int intento = int.Parse(Console.ReadLine());
            if (intento == numeroSecreto)
            {

                Console.WriteLine($"\n¡Correcto! El número era {numeroSecreto}");
                Console.WriteLine($"Lo adivinaste en {i} intentos");
                adivinado = true;
                break;
            }
            else
            {
                int diferencia = Math.Abs(intento - numeroSecreto);
                if (intento < numeroSecreto)
                {
                    if (diferencia > 20)
                        Console.WriteLine("Muy bajo");
                    else
                        Console.WriteLine("Bajo");
                }
                else
                {
                    if (diferencia > 20)
                        Console.WriteLine("Muy alto");
                    else
                        Console.WriteLine("Alto");
                }
            }
        }
        if (!adivinado)
        {
            Console.WriteLine($"\n¡Perdiste! El número era {numeroSecreto}");
        }
    }
}
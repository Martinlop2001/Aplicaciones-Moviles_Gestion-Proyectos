using System;
class Ejercicio06
{
    public static void Ejecutar()
    {
        Console.WriteLine("=== DÍA DE LA SEMANA ===\n");
        Console.Write("Ingresa un número (1-7): ");
        int dia = int.Parse(Console.ReadLine());
        string nombreDia;
        switch (dia)
        {
            case 1:
                nombreDia = "Lunes";
                break;

            case 2:
                nombreDia = "Martes";
                break;

            case 3:
                nombreDia = "Miércoles";
                break;

            case 4:
                nombreDia = "Jueves";
                break;

            case 5:
                nombreDia = "Viernes";
                break;

            case 6:
                nombreDia = "Sábado";
                break;

            case 7:
                nombreDia = "Domingo";
                break;

            default:
                nombreDia = "Número inválido";
                break;
        }
        Console.WriteLine($"\nEl día es: {nombreDia}");
    }
}
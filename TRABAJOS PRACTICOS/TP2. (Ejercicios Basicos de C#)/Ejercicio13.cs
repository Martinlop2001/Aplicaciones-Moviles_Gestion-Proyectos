using System;
class Ejercicio13
{
    static string GenerarContraseña(int longitud)
    {
        const string caracteres =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        string contraseña = "";
        for (int i = 0; i < longitud; i++)
        {
            int indice = random.Next(caracteres.Length);

            contraseña += caracteres[indice];
        }
        return contraseña;
    }
    public static void Ejecutar()
    {
        Console.WriteLine("=== GENERADOR DE CONTRASEÑAS ===\n");
        Console.Write("¿Cuántos caracteres debe tener la contraseña?: ");
        int longitud = int.Parse(Console.ReadLine());
        string contraseña = GenerarContraseña(longitud);
        Console.WriteLine($"\nTu contraseña generada es: {contraseña}");
    }
}
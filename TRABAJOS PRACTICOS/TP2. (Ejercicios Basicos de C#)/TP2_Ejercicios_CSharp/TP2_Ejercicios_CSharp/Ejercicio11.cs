using System;
class Ejercicio11
{
    static bool ValidarEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
    static bool ValidarEdad(int edad)
    {
        return edad >= 0 && edad <= 120;
    }
    static bool ValidarContraseña(string contraseña)
    {
        return contraseña.Length >= 8;
    }
    public static void Ejecutar()
    {
        Console.WriteLine("=== VALIDADOR ===\n");
        // Validar email
        Console.Write("Ingresa tu email: ");
        string email = Console.ReadLine();
        Console.WriteLine(ValidarEmail(email) ? "✓ Email válido" : "✗ Email inválido");
        // Validar edad
        Console.Write("\nIngresa tu edad: ");
        int edad = int.Parse(Console.ReadLine());
        Console.WriteLine(ValidarEdad(edad) ? "✓ Edad válida" : "✗ Edad inválida");
        // Validar contraseña
        Console.Write("\nIngresa tu contraseña: ");
      string contraseña = Console.ReadLine();
        Console.WriteLine(ValidarContraseña(contraseña) ? "✓ Contraseña válida" : "✗ Contraseña muy corta");
    }
}
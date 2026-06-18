using System;
using System.Collections.Generic;

class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public List<Prestamo> HistorialPrestamos { get; set; }

    public Usuario(int id, string nombre, string email)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
        HistorialPrestamos = new List<Prestamo>();
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"\n=== USUARIO ===");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Préstamos activos: {HistorialPrestamos.Count(p => p.FechaDevolucion == null)}");
    }

    public void MostrarHistorial()
    {
        Console.WriteLine($"\nHistorial de préstamos de {Nombre}:");
        if (HistorialPrestamos.Count == 0)
        {
            Console.WriteLine("Sin préstamos registrados.");
            return;
        }
        foreach (var p in HistorialPrestamos)
        {
            string estado = p.FechaDevolucion == null ? "ACTIVO" : "Devuelto";
            Console.WriteLine($"  [{estado}] Libro: {p.Libro.Titulo} | Inicio: {p.FechaPrestamo:dd/MM/yyyy}" +
                $"{(p.FechaDevolucion != null ? $" | Fin: {p.FechaDevolucion:dd/MM/yyyy}" : "")}");
        }
    }
}

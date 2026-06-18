using System;

class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AñoPublicacion { get; set; }
    public string ISBN { get; set; }
    public bool Disponible { get; set; }

    public Libro(int id, string titulo, string autor, int año, string isbn)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        AñoPublicacion = año;
        ISBN = isbn;
        Disponible = true;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"\n=== LIBRO ===");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Año: {AñoPublicacion}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Estado: {(Disponible ? "Disponible" : "Prestado")}");
    }

    public int CalcularAntiguedad()
    {
        return DateTime.Now.Year - AñoPublicacion;
    }
}

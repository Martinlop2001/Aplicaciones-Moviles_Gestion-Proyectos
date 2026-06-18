using System;
using System.Collections.Generic;
using System.Linq;

class Biblioteca
{
    private List<Libro> libros;
    public string Nombre { get; set; }

    public Biblioteca(string nombre)
    {
        Nombre = nombre;
        libros = new List<Libro>();
    }

    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
        Console.WriteLine($"Libro '{libro.Titulo}' agregado exitosamente");
    }

    public void MostrarTodosLosLibros()
    {
        Console.WriteLine($"\n=== BIBLIOTECA {Nombre.ToUpper()} ===");
        Console.WriteLine($"Total de libros: {libros.Count}\n");
        foreach (var libro in libros)
        {
            Console.WriteLine($"{libro.Id}. {libro.Titulo} - {libro.Autor} ({libro.AñoPublicacion})");
            Console.WriteLine($"   Estado: {(libro.Disponible ? "Disponible" : "Prestado")}");
        }
    }

    public Libro BuscarPorId(int id)
    {
        return libros.FirstOrDefault(l => l.Id == id);
    }

    public List<Libro> BuscarPorAutor(string autor)
    {
        return libros.Where(l => l.Autor.ToLower().Contains(autor.ToLower())).ToList();
    }

    public List<Libro> LibrosDisponibles()
    {
        return libros.Where(l => l.Disponible).ToList();
    }

    public bool PrestarLibro(int id)
    {
        var libro = BuscarPorId(id);
        if (libro != null && libro.Disponible)
        {
            libro.Disponible = false;
            Console.WriteLine($"Libro '{libro.Titulo}' prestado exitosamente");
            return true;
        }
        Console.WriteLine("Libro no disponible o no encontrado");
        return false;
    }

    public bool DevolverLibro(int id)
    {
        var libro = BuscarPorId(id);
        if (libro != null && !libro.Disponible)
        {
            libro.Disponible = true;
            Console.WriteLine($"Libro '{libro.Titulo}' devuelto exitosamente");
            return true;
        }
        Console.WriteLine("Libro no encontrado o ya estaba disponible");
        return false;
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine($"\n=== ESTADÍSTICAS ===");
        Console.WriteLine($"Total de libros: {libros.Count}");
        Console.WriteLine($"Libros disponibles: {libros.Count(l => l.Disponible)}");
        Console.WriteLine($"Libros prestados: {libros.Count(l => !l.Disponible)}");
        if (libros.Any())
        {
            var libroMasAntiguo = libros.OrderBy(l => l.AñoPublicacion).First();
            var libroMasReciente = libros.OrderByDescending(l => l.AñoPublicacion).First();
            Console.WriteLine($"Libro más antiguo: {libroMasAntiguo.Titulo} ({libroMasAntiguo.AñoPublicacion})");
            Console.WriteLine($"Libro más reciente: {libroMasReciente.Titulo} ({libroMasReciente.AñoPublicacion})");
        }
    }
}

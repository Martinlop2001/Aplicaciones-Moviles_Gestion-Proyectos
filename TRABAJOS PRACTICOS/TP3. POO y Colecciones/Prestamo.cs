using System;

class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }

    public Prestamo(int id, Libro libro, Usuario usuario)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = DateTime.Now;
        FechaDevolucion = null;
    }

    public void Devolver()
    {
        FechaDevolucion = DateTime.Now;
        Libro.Disponible = true;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"\n=== PRÉSTAMO #{Id} ===");
        Console.WriteLine($"Libro: {Libro.Titulo}");
        Console.WriteLine($"Usuario: {Usuario.Nombre}");
        Console.WriteLine($"Fecha préstamo: {FechaPrestamo:dd/MM/yyyy}");
        Console.WriteLine($"Fecha devolución: {(FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "No devuelto")}");
        Console.WriteLine($"Estado: {(FechaDevolucion == null ? "ACTIVO" : "COMPLETADO")}");
    }
}

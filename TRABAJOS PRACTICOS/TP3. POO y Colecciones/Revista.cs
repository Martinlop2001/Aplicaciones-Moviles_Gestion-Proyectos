using System;

class Revista : Publicacion
{
    public int NumeroEdicion { get; set; }
    public string Editorial { get; set; }

    public Revista(int id, string titulo, int año, int numeroEdicion, string editorial)
        : base(id, titulo, año)
    {
        NumeroEdicion = numeroEdicion;
        Editorial = editorial;
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"\n=== REVISTA ===");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Edición N°: {NumeroEdicion}");
        Console.WriteLine($"Editorial: {Editorial}");
        Console.WriteLine($"Año: {AñoPublicacion}");
        Console.WriteLine($"Estado: {(Disponible ? "Disponible" : "Prestado")}");
    }
}

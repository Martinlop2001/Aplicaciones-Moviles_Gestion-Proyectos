using System;

abstract class Publicacion
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int AñoPublicacion { get; set; }
    public bool Disponible { get; set; }

    public Publicacion(int id, string titulo, int año)
    {
        Id = id;
        Titulo = titulo;
        AñoPublicacion = año;
        Disponible = true;
    }

    public abstract void MostrarInfo();

    public int CalcularAntiguedad()
    {
        return DateTime.Now.Year - AñoPublicacion;
    }
}

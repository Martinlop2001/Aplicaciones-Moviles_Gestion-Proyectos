namespace BibliotecaApp.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Año { get; set; }
        public string Portada { get; set; }
        public string Descripcion { get; set; }
        public int Paginas { get; set; }
        public double Calificacion { get; set; }
        public bool EsFavorito { get; set; }
    }
}

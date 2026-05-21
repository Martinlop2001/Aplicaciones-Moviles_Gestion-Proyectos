using BibliotecaApp.Models;

namespace BibliotecaApp.Services
{
    public class LibroService
    {
        private List<Libro> libros;

        public LibroService()
        {
            InicializarLibros();
        }

        void InicializarLibros()
        {
            libros = new List<Libro>
            {
                new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Genero = "Ficción", Año = 1967, Portada = "libro1.jpg", Descripcion = "Una obra maestra del realismo mágico", Paginas = 417, Calificacion = 4.8, EsFavorito = false },
                new Libro { Id = 2, Titulo = "1984", Autor = "George Orwell", Genero = "Distopía", Año = 1949, Portada = "libro2.jpg", Descripcion = "Una visión oscura del futuro totalitario", Paginas = 328, Calificacion = 4.7, EsFavorito = true },
                new Libro { Id = 3, Titulo = "El principito", Autor = "Antoine de Saint-Exupéry", Genero = "Infantil", Año = 1943, Portada = "libro3.jpg", Descripcion = "Un cuento filosófico sobre la vida", Paginas = 96, Calificacion = 4.9, EsFavorito = true },
                new Libro { Id = 4, Titulo = "Don Quijote", Autor = "Miguel de Cervantes", Genero = "Clásico", Año = 1605, Portada = "libro4.jpg", Descripcion = "Las aventuras del ingenioso hidalgo", Paginas = 863, Calificacion = 4.6, EsFavorito = false },
                new Libro { Id = 5, Titulo = "Harry Potter", Autor = "J.K. Rowling", Genero = "Fantasía", Año = 1997, Portada = "libro5.jpg", Descripcion = "El niño que sobrevivió", Paginas = 309, Calificacion = 4.8, EsFavorito = true }
            };
        }

        public List<Libro> ObtenerTodos() => libros;

        public Libro ObtenerPorId(int id) => libros.FirstOrDefault(l => l.Id == id);

        public List<Libro> ObtenerFavoritos() => libros.Where(l => l.EsFavorito).ToList();

        public List<Libro> Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return libros;
            return libros.Where(l =>
                l.Titulo.Contains(termino, StringComparison.OrdinalIgnoreCase) ||
                l.Autor.Contains(termino, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public void AlternarFavorito(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro != null)
                libro.EsFavorito = !libro.EsFavorito;
        }
    }
}

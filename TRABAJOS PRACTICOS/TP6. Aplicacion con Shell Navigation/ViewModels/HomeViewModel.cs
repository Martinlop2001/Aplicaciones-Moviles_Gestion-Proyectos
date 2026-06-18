using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly LibroService libroService;

        [ObservableProperty]
        private int totalLibros;

        [ObservableProperty]
        private int totalFavoritos;

        [ObservableProperty]
        private double promedioCalificacion;

        public ObservableCollection<Libro> LibrosRecientes { get; } = new();

        public HomeViewModel()
        {
            libroService = new LibroService();
            CargarDatos();
        }

        void CargarDatos()
        {
            var libros = libroService.ObtenerTodos();
            TotalLibros = libros.Count;
            TotalFavoritos = libroService.ObtenerFavoritos().Count;
            PromedioCalificacion = libros.Average(l => l.Calificacion);

            var recientes = libros.OrderByDescending(l => l.Año).Take(3);
            LibrosRecientes.Clear();
            foreach (var libro in recientes)
                LibrosRecientes.Add(libro);
        }
    }
}

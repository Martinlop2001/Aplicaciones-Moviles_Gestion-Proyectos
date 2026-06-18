using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp.ViewModels
{
    public partial class LibrosViewModel : ObservableObject
    {
        private readonly LibroService libroService;

        [ObservableProperty]
        private string terminoBusqueda;

        public ObservableCollection<Libro> Libros { get; } = new();

        public LibrosViewModel()
        {
            libroService = new LibroService();
            CargarLibros();
        }

        void CargarLibros()
        {
            var libros = libroService.ObtenerTodos();
            Libros.Clear();
            foreach (var libro in libros)
                Libros.Add(libro);
        }

        [RelayCommand]
        private void Buscar()
        {
            var libros = libroService.Buscar(TerminoBusqueda);
            Libros.Clear();
            foreach (var libro in libros)
                Libros.Add(libro);
        }

        [RelayCommand]
        private async Task IrADetalle(Libro libro)
        {
            await Shell.Current.GoToAsync($"detalle?id={libro.Id}");
        }
    }
}

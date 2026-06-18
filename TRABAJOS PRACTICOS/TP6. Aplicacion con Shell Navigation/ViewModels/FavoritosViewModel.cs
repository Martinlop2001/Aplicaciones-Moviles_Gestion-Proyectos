using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp.ViewModels
{
    public partial class FavoritosViewModel : ObservableObject
    {
        private readonly LibroService libroService;

        public ObservableCollection<Libro> Favoritos { get; } = new();

        public FavoritosViewModel()
        {
            libroService = new LibroService();
        }

        public void CargarFavoritos()
        {
            var favoritos = libroService.ObtenerFavoritos();
            Favoritos.Clear();
            foreach (var libro in favoritos)
                Favoritos.Add(libro);
        }

        [RelayCommand]
        private async Task IrADetalle(Libro libro)
        {
            await Shell.Current.GoToAsync($"detalle?id={libro.Id}");
        }
    }
}

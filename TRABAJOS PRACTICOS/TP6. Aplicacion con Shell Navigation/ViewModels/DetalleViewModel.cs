using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp.ViewModels
{
    [QueryProperty(nameof(LibroId), "id")]
    public partial class DetalleViewModel : ObservableObject
    {
        private readonly LibroService libroService;

        [ObservableProperty]
        private Libro libro;

        private int libroId;
        public int LibroId
        {
            get => libroId;
            set
            {
                libroId = value;
                CargarLibro();
            }
        }

        public DetalleViewModel()
        {
            libroService = new LibroService();
        }

        void CargarLibro()
        {
            Libro = libroService.ObtenerPorId(LibroId);
        }

        [RelayCommand]
        private void AlternarFavorito()
        {
            libroService.AlternarFavorito(Libro.Id);
            Libro.EsFavorito = !Libro.EsFavorito;
            OnPropertyChanged(nameof(Libro));
        }

        [RelayCommand]
        private async Task Volver()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

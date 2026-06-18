using CommunityToolkit.Mvvm.ComponentModel;
using BibliotecaApp.Services;

namespace BibliotecaApp.ViewModels
{
    public partial class PerfilViewModel : ObservableObject
    {
        private readonly LibroService libroService;

        [ObservableProperty]
        private string nombreUsuario = "Martín López";

        [ObservableProperty]
        private string email = "martin@email.com";

        [ObservableProperty]
        private int totalLibrosLeidos;

        [ObservableProperty]
        private int librosFavoritos;

        public PerfilViewModel()
        {
            libroService = new LibroService();
            TotalLibrosLeidos = libroService.ObtenerTodos().Count;
            LibrosFavoritos = libroService.ObtenerFavoritos().Count;
        }
    }
}

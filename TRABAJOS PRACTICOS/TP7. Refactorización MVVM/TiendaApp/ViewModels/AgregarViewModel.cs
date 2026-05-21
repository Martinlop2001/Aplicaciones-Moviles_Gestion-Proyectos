using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TiendaApp.Models;
using TiendaApp.Services;

namespace TiendaApp.ViewModels
{
    public partial class AgregarViewModel : ObservableObject
    {
        private readonly IProductoService productoService;

        [ObservableProperty]
        private string nombre = string.Empty;

        [ObservableProperty]
        private string precio = string.Empty;

        [ObservableProperty]
        private string descripcion = string.Empty;

        [ObservableProperty]
        private string categoria = string.Empty;

        [ObservableProperty]
        private string stock = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private bool tieneError;

        public AgregarViewModel(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [RelayCommand]
        private async Task Guardar()
        {
            TieneError = false;

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                ErrorMessage = "El nombre es obligatorio";
                TieneError = true;
                return;
            }

            if (!decimal.TryParse(Precio, out decimal precioDecimal) || precioDecimal <= 0)
            {
                ErrorMessage = "Ingrese un precio válido";
                TieneError = true;
                return;
            }

            var producto = new Producto
            {
                Nombre = Nombre,
                Precio = precioDecimal,
                Descripcion = Descripcion,
                Categoria = Categoria,
                Stock = int.TryParse(Stock, out int s) ? s : 0,
                Imagen = "producto.png"
            };

            await productoService.AgregarAsync(producto);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Cancelar()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

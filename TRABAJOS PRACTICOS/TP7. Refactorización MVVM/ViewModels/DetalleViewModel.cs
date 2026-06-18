using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TiendaApp.Models;
using TiendaApp.Services;

namespace TiendaApp.ViewModels
{
    [QueryProperty(nameof(ProductoId), "id")]
    public partial class DetalleViewModel : ObservableObject
    {
        private readonly IProductoService productoService;

        [ObservableProperty]
        private int productoId;

        [ObservableProperty]
        private Producto? producto;

        [ObservableProperty]
        private bool estaCargando;

        public DetalleViewModel(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        partial void OnProductoIdChanged(int value)
        {
            _ = CargarProducto();
        }

        [RelayCommand]
        private async Task CargarProducto()
        {
            if (ProductoId <= 0) return;
            EstaCargando = true;
            try
            {
                Producto = await productoService.ObtenerPorIdAsync(ProductoId);
            }
            finally
            {
                EstaCargando = false;
            }
        }

        [RelayCommand]
        private async Task Eliminar()
        {
            if (Producto == null) return;
            bool confirmar = await Shell.Current.DisplayAlertAsync(
                "Confirmar",
                $"¿Eliminar {Producto.Nombre}?",
                "Sí",
                "No");
            if (confirmar)
            {
                await productoService.EliminarAsync(Producto.Id);
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        private async Task Volver()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

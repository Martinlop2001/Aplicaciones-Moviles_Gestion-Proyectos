using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TiendaApp.Models;
using TiendaApp.Services;

namespace TiendaApp.ViewModels
{
    public partial class ProductosViewModel : ObservableObject
    {
        private readonly IProductoService productoService;

        [ObservableProperty]
        private bool estaCargando;

        [ObservableProperty]
        private string terminoBusqueda = string.Empty;

        public ObservableCollection<Producto> Productos { get; } = new();

        public ProductosViewModel(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [RelayCommand]
        private async Task Cargar()
        {
            EstaCargando = true;
            try
            {
                var productos = await productoService.ObtenerTodosAsync();
                Productos.Clear();
                foreach (var producto in productos)
                {
                    Productos.Add(producto);
                }
            }
            finally
            {
                EstaCargando = false;
            }
        }

        [RelayCommand]
        private async Task Agregar()
        {
            await Shell.Current.GoToAsync("AgregarPage");
        }

        [RelayCommand]
        private async Task Eliminar(Producto producto)
        {
            bool confirmar = await Shell.Current.DisplayAlertAsync(
                "Confirmar",
                $"¿Eliminar {producto.Nombre}?",
                "Sí",
                "No");
            if (confirmar)
            {
                await productoService.EliminarAsync(producto.Id);
                Productos.Remove(producto);
            }
        }

        [RelayCommand]
        private async Task IrADetalle(Producto producto)
        {
            await Shell.Current.GoToAsync($"DetallePage?id={producto.Id}");
        }

        [RelayCommand]
        private async Task Buscar()
        {
            if (string.IsNullOrWhiteSpace(TerminoBusqueda))
            {
                await Cargar();
                return;
            }
            var todos = await productoService.ObtenerTodosAsync();
            var filtrados = todos.Where(p =>
                p.Nombre.Contains(TerminoBusqueda, StringComparison.OrdinalIgnoreCase)
            ).ToList();
            Productos.Clear();
            foreach (var producto in filtrados)
            {
                Productos.Add(producto);
            }
        }
    }
}

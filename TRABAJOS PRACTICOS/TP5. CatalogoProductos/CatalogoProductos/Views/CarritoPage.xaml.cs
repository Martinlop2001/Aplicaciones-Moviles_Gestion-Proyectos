using CatalogoProductos.Models;
using CatalogoProductos.Services;

namespace CatalogoProductos.Views
{
    public partial class CarritoPage : ContentPage
    {
        ProductoService productoService;

        public CarritoPage()
        {
            InitializeComponent();
            productoService = new ProductoService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarCarrito();
        }

        void CargarCarrito()
        {
            var items = productoService.ObtenerCarrito();
            collectionViewCarrito.ItemsSource = null;
            collectionViewCarrito.ItemsSource = items;
            lblTotal.Text = $"${productoService.ObtenerTotalCarrito():F2}";
        }

        void OnAumentarCantidad(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int id)
            {
                var item = productoService.ObtenerCarrito().FirstOrDefault(c => c.Producto.Id == id);
                if (item != null)
                {
                    productoService.ActualizarCantidad(id, item.Cantidad + 1);
                    CargarCarrito();
                }
            }
        }

        void OnDisminuirCantidad(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int id)
            {
                var item = productoService.ObtenerCarrito().FirstOrDefault(c => c.Producto.Id == id);
                if (item != null)
                {
                    productoService.ActualizarCantidad(id, item.Cantidad - 1);
                    CargarCarrito();
                }
            }
        }

        void OnEliminarItem(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int id)
            {
                productoService.EliminarDelCarrito(id);
                CargarCarrito();
            }
        }

        async void OnVaciarCarritoClicked(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlertAsync("Vaciar Carrito", "¿Eliminar todos los productos?", "Sí", "No");
            if (respuesta)
            {
                productoService.LimpiarCarrito();
                CargarCarrito();
            }
        }

        async void OnComprarClicked(object sender, EventArgs e)
        {
            var items = productoService.ObtenerCarrito();
            if (items.Count == 0)
            {
                await DisplayAlertAsync("Carrito vacío", "Agrega productos al carrito", "OK");
                return;
            }

            bool respuesta = await DisplayAlertAsync(
                "Comprar",
                $"Total a pagar: ${productoService.ObtenerTotalCarrito():F2}\n¿Confirmar compra?",
                "Sí", "No");
            if (respuesta)
            {
                await DisplayAlertAsync("Éxito", "Compra realizada con éxito", "OK");
                productoService.LimpiarCarrito();
                CargarCarrito();
            }
        }
    }
}

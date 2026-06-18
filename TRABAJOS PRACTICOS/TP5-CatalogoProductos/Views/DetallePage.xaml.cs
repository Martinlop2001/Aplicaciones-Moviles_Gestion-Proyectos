using CatalogoProductos.Models;
using CatalogoProductos.Services;

namespace CatalogoProductos.Views
{
    public partial class DetallePage : ContentPage
    {
        Producto producto;
        ProductoService productoService;
        int cantidad = 1;

        public DetallePage(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
            productoService = new ProductoService();
            MostrarDetalle();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ActualizarBotonFavorito();
            await contenidoDetalle.FadeToAsync(1, 500, Easing.CubicOut);
        }

        void MostrarDetalle()
        {
            imgProducto.Source = producto.Imagen;
            lblNombre.Text = producto.Nombre;
            lblPrecio.Text = $"${producto.Precio:F2}";
            lblCalificacion.Text = producto.Calificacion.ToString("F1");
            lblCategoria.Text = producto.Categoria;
            lblStock.Text = $"Stock: {producto.Stock}";
            lblDescripcion.Text = producto.Descripcion;
            lblCantidad.Text = "1";
            cantidad = 1;
            ActualizarBotonFavorito();
        }

        void ActualizarBotonFavorito()
        {
            if (producto.IsFavorito)
            {
                btnFavorito.Source = "heart_filled.png";
                lblFavorito.IsVisible = true;
            }
            else
            {
                btnFavorito.Source = "heart_empty.png";
                lblFavorito.IsVisible = false;
            }
        }

        void OnAumentarCantidad(object sender, EventArgs e)
        {
            if (cantidad < producto.Stock)
            {
                cantidad++;
                lblCantidad.Text = cantidad.ToString();
            }
        }

        void OnDisminuirCantidad(object sender, EventArgs e)
        {
            if (cantidad > 1)
            {
                cantidad--;
                lblCantidad.Text = cantidad.ToString();
            }
        }

        async void OnAgregarCarritoClicked(object sender, EventArgs e)
        {
            productoService.AgregarAlCarrito(producto, cantidad);
            await DisplayAlertAsync("Carrito", $"{producto.Nombre} agregado al carrito (x{cantidad})", "OK");
        }

        async void OnComprarClicked(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlertAsync(
                "Comprar",
                $"¿Deseas comprar {producto.Nombre} por ${producto.Precio * cantidad:F2}?",
                "Sí", "No");
            if (respuesta)
            {
                await DisplayAlertAsync("Éxito", "Compra realizada con éxito", "OK");
            }
        }

        async void OnVerCarritoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarritoPage());
        }

        async void OnToggleFavoritoClicked(object sender, EventArgs e)
        {
            productoService.AlternarFavorito(producto.Id);
            ActualizarBotonFavorito();
            if (producto.IsFavorito)
                await DisplayAlertAsync("Favoritos", $"{producto.Nombre} agregado a favoritos", "OK");
            else
                await DisplayAlertAsync("Favoritos", $"{producto.Nombre} eliminado de favoritos", "OK");
        }
    }
}

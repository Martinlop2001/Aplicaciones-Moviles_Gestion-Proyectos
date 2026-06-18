using CatalogoProductos.Models;
using CatalogoProductos.Services;

namespace CatalogoProductos.Views
{
    public partial class HomePage : ContentPage
    {
        ProductoService productoService;

        public HomePage()
        {
            InitializeComponent();
            productoService = new ProductoService();
            CargarDatos();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await contenidoHome.FadeToAsync(1, 600, Easing.CubicOut);
        }

        void CargarDatos()
        {
            collectionViewCategorias.ItemsSource = productoService.ObtenerCategorias();
            collectionViewProductos.ItemsSource = productoService.ObtenerTodosLosProductos().Take(6).ToList();
        }

        async void OnPerfilClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage());
        }

        async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string termino = ((SearchBar)sender).Text;
            await Navigation.PushAsync(new ProductosPage(termino));
        }

        async void OnCategoriaSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                Categoria categoria = (Categoria)e.CurrentSelection[0];
                await Navigation.PushAsync(new ProductosPage(categoria.Nombre));
                collectionViewCategorias.SelectedItem = null;
            }
        }

        async void OnProductoSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                Producto producto = (Producto)e.CurrentSelection[0];
                await Navigation.PushAsync(new DetallePage(producto));
                collectionViewProductos.SelectedItem = null;
            }
        }

        async void OnVerTodosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductosPage());
        }
    }
}

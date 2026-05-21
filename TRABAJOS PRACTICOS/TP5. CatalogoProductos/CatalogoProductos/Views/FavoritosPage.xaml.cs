using CatalogoProductos.Models;
using CatalogoProductos.Services;

namespace CatalogoProductos.Views
{
    public partial class FavoritosPage : ContentPage
    {
        ProductoService productoService;

        public FavoritosPage()
        {
            InitializeComponent();
            productoService = new ProductoService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            collectionViewFavoritos.ItemsSource = productoService.ObtenerFavoritos();
        }

        async void OnProductoSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                Producto producto = (Producto)e.CurrentSelection[0];
                await Navigation.PushAsync(new DetallePage(producto));
                collectionViewFavoritos.SelectedItem = null;
            }
        }
    }
}

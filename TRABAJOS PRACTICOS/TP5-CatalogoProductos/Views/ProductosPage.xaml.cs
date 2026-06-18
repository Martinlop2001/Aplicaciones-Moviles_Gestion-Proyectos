using CatalogoProductos.Models;
using CatalogoProductos.Services;

namespace CatalogoProductos.Views
{
    public partial class ProductosPage : ContentPage
    {
        ProductoService productoService;
        List<Producto> todosLosProductos;
        string? categoriaFiltro;

        public ProductosPage(string? filtro = null)
        {
            InitializeComponent();
            productoService = new ProductoService();
            categoriaFiltro = filtro;
            CargarProductos();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                searchBar.Text = filtro;
            }
        }

        void CargarProductos()
        {
            if (string.IsNullOrWhiteSpace(categoriaFiltro))
                todosLosProductos = productoService.ObtenerTodosLosProductos();
            else
                todosLosProductos = productoService.ObtenerProductosPorCategoria(categoriaFiltro);

            collectionViewProductos.ItemsSource = todosLosProductos;
        }

        void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string termino = e.NewTextValue;
            if (string.IsNullOrWhiteSpace(termino))
                collectionViewProductos.ItemsSource = todosLosProductos;
            else
            {
                var filtrados = todosLosProductos
                    .Where(p => p.Nombre.ToLower().Contains(termino.ToLower()) ||
                                p.Descripcion.ToLower().Contains(termino.ToLower()))
                    .ToList();
                collectionViewProductos.ItemsSource = filtrados;
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

        async void OnRefreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            CargarProductos();
            refreshView.IsRefreshing = false;
        }

        void OnFiltrarClicked(object sender, EventArgs e)
        {
            decimal? precioMin = null;
            decimal? precioMax = null;
            double? califMin = null;

            if (panelFiltrosMovil.IsVisible)
            {
                if (decimal.TryParse(entryPrecioMinMovil.Text, out var pmin)) precioMin = pmin;
                if (decimal.TryParse(entryPrecioMaxMovil.Text, out var pmax)) precioMax = pmax;
                if (double.TryParse(entryCalifMinMovil.Text, out var cmin)) califMin = cmin;
            }
            else
            {
                if (decimal.TryParse(entryPrecioMin.Text, out var pmin)) precioMin = pmin;
                if (decimal.TryParse(entryPrecioMax.Text, out var pmax)) precioMax = pmax;
                if (double.TryParse(entryCalifMin.Text, out var cmin)) califMin = cmin;
            }

            var termino = searchBar.Text;
            var resultados = productoService.BuscarProductosAvanzado(termino, precioMin, precioMax, califMin, categoriaFiltro);
            collectionViewProductos.ItemsSource = resultados;
        }

        void OnLimpiarFiltrosClicked(object sender, EventArgs e)
        {
            entryPrecioMin.Text = "";
            entryPrecioMax.Text = "";
            entryCalifMin.Text = "";
            entryPrecioMinMovil.Text = "";
            entryPrecioMaxMovil.Text = "";
            entryCalifMinMovil.Text = "";
            CargarProductos();
        }

        void OnToggleFiltrosMovilClicked(object sender, EventArgs e)
        {
            panelFiltrosMovil.IsVisible = !panelFiltrosMovil.IsVisible;
        }

        async void OnVerFavoritosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritosPage());
        }
    }
}

namespace CatalogoProductos.Views
{
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await contenidoPerfil.FadeToAsync(1, 600, Easing.CubicOut);
        }

        async void OnEditarPerfilTapped(object sender, EventArgs e)
        {
            await DisplayAlertAsync("Editar Perfil", "Funcionalidad de edición de perfil", "OK");
        }

        async void OnMisPedidosTapped(object sender, EventArgs e)
        {
            await DisplayAlertAsync("Mis Pedidos", "Funcionalidad de pedidos", "OK");
        }

        async void OnFavoritosTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritosPage());
        }

        async void OnCarritoTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarritoPage());
        }

        async void OnConfiguracionTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfiguracionPage());
        }

        async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlertAsync(
                "Cerrar Sesión",
                "¿Estás seguro que deseas cerrar sesión?",
                "Sí", "No");
            if (respuesta)
            {
                Application.Current!.Windows[0].Page = new NavigationPage(new LoginPage());
            }
        }
    }
}

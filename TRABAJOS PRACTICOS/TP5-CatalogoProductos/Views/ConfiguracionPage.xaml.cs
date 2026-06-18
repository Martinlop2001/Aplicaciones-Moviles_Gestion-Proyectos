namespace CatalogoProductos.Views
{
    public partial class ConfiguracionPage : ContentPage
    {
        public ConfiguracionPage()
        {
            InitializeComponent();
            CargarPreferencias();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await contenidoConfig.FadeToAsync(1, 500, Easing.CubicOut);
        }

        void CargarPreferencias()
        {
            bool temaOscuro = Preferences.Get("TemaOscuro", false);
            switchTema.IsToggled = temaOscuro;
        }

        void OnTemaToggled(object sender, ToggledEventArgs e)
        {
            Preferences.Set("TemaOscuro", e.Value);
            if (e.Value)
                Application.Current!.UserAppTheme = AppTheme.Dark;
            else
                Application.Current!.UserAppTheme = AppTheme.Light;
        }
    }
}

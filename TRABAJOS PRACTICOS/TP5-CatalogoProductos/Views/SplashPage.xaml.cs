namespace CatalogoProductos.Views
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await contenidoSplash.FadeToAsync(1, 800, Easing.CubicIn);
            await Task.Delay(2500);
            await contenidoSplash.FadeToAsync(0, 500, Easing.CubicOut);
            var window = Application.Current!.Windows[0];
            window.Page = new NavigationPage(new LoginPage());
        }
    }
}

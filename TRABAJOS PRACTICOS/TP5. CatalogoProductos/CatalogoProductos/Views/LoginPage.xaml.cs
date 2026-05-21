using CatalogoProductos.Services;

namespace CatalogoProductos.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.WhenAll(
                contenidoLogin.FadeToAsync(1, 600, Easing.CubicOut),
                contenidoLogin.TranslateToAsync(0, 0, 600, Easing.CubicOut)
            );
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryEmail.Text))
            {
                await DisplayAlertAsync("Error", "Ingresa tu email", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(entryPassword.Text))
            {
                await DisplayAlertAsync("Error", "Ingresa tu contraseña", "OK");
                return;
            }

            await DisplayAlertAsync("Éxito", "Iniciando sesión...", "OK");
            await Navigation.PushAsync(new HomePage());
        }

        async void OnRegistroClicked(object sender, EventArgs e)
        {
            await DisplayAlertAsync("Registro", "Funcionalidad de registro", "OK");
        }

        async void OnOlvidePasswordTapped(object sender, EventArgs e)
        {
            await DisplayAlertAsync("Recuperar contraseña", "Funcionalidad de recuperación", "OK");
        }
    }
}

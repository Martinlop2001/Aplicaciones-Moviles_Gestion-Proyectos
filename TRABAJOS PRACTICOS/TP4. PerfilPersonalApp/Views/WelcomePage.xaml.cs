namespace PerfilPersonalApp.Views;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void OnBeginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfileFormPage());
    }
}

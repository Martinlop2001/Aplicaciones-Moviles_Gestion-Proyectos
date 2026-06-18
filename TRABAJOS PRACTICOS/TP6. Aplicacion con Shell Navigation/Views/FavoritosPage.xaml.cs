using BibliotecaApp.ViewModels;

namespace BibliotecaApp.Views;

public partial class FavoritosPage : ContentPage
{
    private readonly FavoritosViewModel? viewModel;

    public FavoritosPage()
    {
        InitializeComponent();
        viewModel = BindingContext as FavoritosViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel?.CargarFavoritos();
    }
}

using CatalogoProductos.Views;

namespace CatalogoProductos;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        CargarTema();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new SplashPage());
    }

    void CargarTema()
    {
        bool temaOscuro = Preferences.Get("TemaOscuro", false);
        UserAppTheme = temaOscuro ? AppTheme.Dark : AppTheme.Light;
    }
}

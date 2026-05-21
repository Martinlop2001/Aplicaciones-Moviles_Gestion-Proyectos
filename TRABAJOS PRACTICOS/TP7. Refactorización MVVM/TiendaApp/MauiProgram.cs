using Microsoft.Extensions.Logging;
using TiendaApp.Services;
using TiendaApp.ViewModels;
using TiendaApp.Views;

namespace TiendaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registrar Servicios
            builder.Services.AddSingleton<IProductoService, ProductoService>();

            // Registrar ViewModels
            builder.Services.AddTransient<ProductosViewModel>();
            builder.Services.AddTransient<DetalleViewModel>();
            builder.Services.AddTransient<AgregarViewModel>();

            // Registrar Views
            builder.Services.AddTransient<ProductosPage>();
            builder.Services.AddTransient<DetallePage>();
            builder.Services.AddTransient<AgregarPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

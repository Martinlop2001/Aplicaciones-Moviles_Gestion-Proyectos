using TiendaApp.Views;

namespace TiendaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("DetallePage", typeof(DetallePage));
            Routing.RegisterRoute("AgregarPage", typeof(AgregarPage));
        }
    }
}

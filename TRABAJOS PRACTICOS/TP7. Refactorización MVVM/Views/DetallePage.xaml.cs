using TiendaApp.ViewModels;

namespace TiendaApp.Views
{
    public partial class DetallePage : ContentPage
    {
        public DetallePage(DetalleViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

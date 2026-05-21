using TiendaApp.ViewModels;

namespace TiendaApp.Views
{
    public partial class AgregarPage : ContentPage
    {
        public AgregarPage(AgregarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

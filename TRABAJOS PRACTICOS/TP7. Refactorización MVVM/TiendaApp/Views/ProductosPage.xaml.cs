using TiendaApp.ViewModels;

namespace TiendaApp.Views
{
    public partial class ProductosPage : ContentPage
    {
        public ProductosPage(ProductosViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ProductosViewModel vm)
            {
                await vm.CargarCommand.ExecuteAsync(null);
            }
        }
    }
}

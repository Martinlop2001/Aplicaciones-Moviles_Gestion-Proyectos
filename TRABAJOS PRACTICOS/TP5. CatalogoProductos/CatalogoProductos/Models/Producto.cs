using System.ComponentModel;

namespace CatalogoProductos.Models
{
    public class Producto : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public double Calificacion { get; set; }

        private bool _isFavorito;
        public bool IsFavorito
        {
            get => _isFavorito;
            set
            {
                _isFavorito = value;
                OnPropertyChanged(nameof(IsFavorito));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

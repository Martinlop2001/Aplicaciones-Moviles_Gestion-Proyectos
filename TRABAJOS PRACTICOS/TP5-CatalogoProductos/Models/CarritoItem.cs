namespace CatalogoProductos.Models
{
    public class CarritoItem
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal => Producto.Precio * Cantidad;
    }
}

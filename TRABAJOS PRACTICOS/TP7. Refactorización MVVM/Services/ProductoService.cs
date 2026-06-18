using TiendaApp.Models;

namespace TiendaApp.Services
{
    public class ProductoService : IProductoService
    {
        private List<Producto> productos = new()
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 999.99m, Imagen = "laptop.png", Descripcion = "Laptop HP 15.6 pulgadas", Categoria = "Electrónica", Stock = 15, Calificacion = 4.5 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 29.99m, Imagen = "mouse.png", Descripcion = "Mouse inalámbrico", Categoria = "Electrónica", Stock = 50, Calificacion = 4.2 },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 79.99m, Imagen = "teclado.png", Descripcion = "Teclado mecánico RGB", Categoria = "Electrónica", Stock = 30, Calificacion = 4.7 }
        };

        public Task<List<Producto>> ObtenerTodosAsync()
        {
            return Task.FromResult(productos.ToList());
        }

        public Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return Task.FromResult(productos.FirstOrDefault(p => p.Id == id));
        }

        public Task AgregarAsync(Producto producto)
        {
            producto.Id = productos.Max(p => p.Id) + 1;
            productos.Add(producto);
            return Task.CompletedTask;
        }

        public Task ActualizarAsync(Producto producto)
        {
            var index = productos.FindIndex(p => p.Id == producto.Id);
            if (index >= 0)
                productos[index] = producto;
            return Task.CompletedTask;
        }

        public Task EliminarAsync(int id)
        {
            productos.RemoveAll(p => p.Id == id);
            return Task.CompletedTask;
        }
    }
}

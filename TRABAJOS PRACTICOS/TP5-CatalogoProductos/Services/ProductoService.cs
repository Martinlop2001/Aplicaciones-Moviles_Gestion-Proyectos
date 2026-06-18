using CatalogoProductos.Models;

namespace CatalogoProductos.Services
{
    public class ProductoService
    {
        private static List<Producto> productos;
        private static List<Categoria> categorias;
        private static List<CarritoItem> carrito;

        public ProductoService()
        {
            InicializarDatos();
        }

        void InicializarDatos()
        {
            if (productos == null)
            {
                productos = new List<Producto>
                {
                    new Producto
                    {
                        Id = 1,
                        Nombre = "Laptop HP",
                        Descripcion = "Laptop HP 15.6 pulgadas, Intel Core i5, 8GB RAM, 256GB SSD",
                        Precio = 899.99m,
                        Imagen = "laptop.png",
                        Categoria = "Electrónica",
                        Stock = 15,
                        Calificacion = 4.5
                    },
                    new Producto
                    {
                        Id = 2,
                        Nombre = "Mouse Logitech",
                        Descripcion = "Mouse inalámbrico Logitech M185, ergonómico",
                        Precio = 19.99m,
                        Imagen = "mouse.png",
                        Categoria = "Electrónica",
                        Stock = 50,
                        Calificacion = 4.2
                    },
                    new Producto
                    {
                        Id = 3,
                        Nombre = "Teclado Mecánico",
                        Descripcion = "Teclado mecánico RGB, switches azules",
                        Precio = 79.99m,
                        Imagen = "teclado.png",
                        Categoria = "Electrónica",
                        Stock = 30,
                        Calificacion = 4.7
                    },
                    new Producto
                    {
                        Id = 4,
                        Nombre = "Monitor Samsung",
                        Descripcion = "Monitor Samsung 24 pulgadas Full HD",
                        Precio = 199.99m,
                        Imagen = "monitor.png",
                        Categoria = "Electrónica",
                        Stock = 20,
                        Calificacion = 4.6
                    },
                    new Producto
                    {
                        Id = 5,
                        Nombre = "Auriculares Sony",
                        Descripcion = "Auriculares Sony con cancelación de ruido",
                        Precio = 149.99m,
                        Imagen = "auriculares.png",
                        Categoria = "Audio",
                        Stock = 25,
                        Calificacion = 4.8
                    },
                    new Producto
                    {
                        Id = 6,
                        Nombre = "Webcam Logitech",
                        Descripcion = "Webcam Logitech C920 Full HD 1080p",
                        Precio = 69.99m,
                        Imagen = "webcam.png",
                        Categoria = "Electrónica",
                        Stock = 40,
                        Calificacion = 4.4
                    },
                    new Producto
                    {
                        Id = 7,
                        Nombre = "Parlante Bluetooth",
                        Descripcion = "Parlante Bluetooth portátil con sonido envolvente",
                        Precio = 59.99m,
                        Imagen = "parlante.png",
                        Categoria = "Audio",
                        Stock = 35,
                        Calificacion = 4.3
                    },
                    new Producto
                    {
                        Id = 8,
                        Nombre = "Mousepad RGB",
                        Descripcion = "Mousepad gaming con iluminación RGB personalizable",
                        Precio = 29.99m,
                        Imagen = "mousepad.png",
                        Categoria = "Gaming",
                        Stock = 60,
                        Calificacion = 4.1
                    },
                    new Producto
                    {
                        Id = 9,
                        Nombre = "Silla Gamer",
                        Descripcion = "Silla ergonómica gaming con soporte lumbar ajustable",
                        Precio = 299.99m,
                        Imagen = "silla.png",
                        Categoria = "Gaming",
                        Stock = 10,
                        Calificacion = 4.9
                    },
                    new Producto
                    {
                        Id = 10,
                        Nombre = "Audífonos HyperX",
                        Descripcion = "Audífonos gaming HyperX Cloud II con sonido 7.1",
                        Precio = 89.99m,
                        Imagen = "hyperx.png",
                        Categoria = "Audio",
                        Stock = 22,
                        Calificacion = 4.6
                    }
                };
            }
            if (categorias == null)
            {
                categorias = new List<Categoria>
                {
                    new Categoria { Id = 1, Nombre = "Electrónica", Icono = "\U0001F4F1", Color = "#2196F3" },
                    new Categoria { Id = 2, Nombre = "Audio", Icono = "\U0001F50A", Color = "#4CAF50" },
                    new Categoria { Id = 3, Nombre = "Accesorios", Icono = "\U00002328", Color = "#FF9800" },
                    new Categoria { Id = 4, Nombre = "Gaming", Icono = "\U0001F3AE", Color = "#9C27B0" }
                };
            }
            if (carrito == null)
            {
                carrito = new List<CarritoItem>();
            }
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            return productos;
        }

        public List<Producto> BuscarProductos(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return productos;
            return productos
                .Where(p => p.Nombre.ToLower().Contains(termino.ToLower())
                    || p.Descripcion.ToLower().Contains(termino.ToLower()))
                .ToList();
        }

        public List<Producto> BuscarProductosAvanzado(string? termino, decimal? precioMin, decimal? precioMax, double? califMin, string? categoria)
        {
            var query = productos.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(termino))
                query = query.Where(p => p.Nombre.ToLower().Contains(termino.ToLower())
                    || p.Descripcion.ToLower().Contains(termino.ToLower()));

            if (precioMin.HasValue)
                query = query.Where(p => p.Precio >= precioMin.Value);

            if (precioMax.HasValue)
                query = query.Where(p => p.Precio <= precioMax.Value);

            if (califMin.HasValue)
                query = query.Where(p => p.Calificacion >= califMin.Value);

            if (!string.IsNullOrWhiteSpace(categoria))
                query = query.Where(p => p.Categoria == categoria);

            return query.ToList();
        }

        public List<Producto> ObtenerProductosPorCategoria(string categoria)
        {
            return productos.Where(p => p.Categoria == categoria).ToList();
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public List<Categoria> ObtenerCategorias()
        {
            return categorias;
        }

        public void AgregarAlCarrito(Producto producto, int cantidad = 1)
        {
            var existente = carrito.FirstOrDefault(c => c.Producto.Id == producto.Id);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
            }
            else
            {
                carrito.Add(new CarritoItem { Producto = producto, Cantidad = cantidad });
            }
        }

        public void EliminarDelCarrito(int productoId)
        {
            carrito.RemoveAll(c => c.Producto.Id == productoId);
        }

        public void ActualizarCantidad(int productoId, int cantidad)
        {
            var item = carrito.FirstOrDefault(c => c.Producto.Id == productoId);
            if (item != null)
            {
                if (cantidad <= 0)
                    carrito.Remove(item);
                else
                    item.Cantidad = cantidad;
            }
        }

        public List<CarritoItem> ObtenerCarrito()
        {
            return carrito;
        }

        public decimal ObtenerTotalCarrito()
        {
            return carrito.Sum(c => c.Subtotal);
        }

        public void LimpiarCarrito()
        {
            carrito.Clear();
        }

        public void AlternarFavorito(int productoId)
        {
            var producto = productos.FirstOrDefault(p => p.Id == productoId);
            if (producto != null)
            {
                producto.IsFavorito = !producto.IsFavorito;
            }
        }

        public List<Producto> ObtenerFavoritos()
        {
            return productos.Where(p => p.IsFavorito).ToList();
        }
    }
}

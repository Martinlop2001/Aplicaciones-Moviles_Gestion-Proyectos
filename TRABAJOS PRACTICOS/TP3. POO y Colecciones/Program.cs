using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Biblioteca biblioteca = new Biblioteca("Biblioteca Central");
    static List<Usuario> usuarios = new List<Usuario>();
    static List<Prestamo> prestamos = new List<Prestamo>();
    static List<Publicacion> publicaciones = new List<Publicacion>();
    static int nextLibroId = 1;
    static int nextUsuarioId = 1;
    static int nextPrestamoId = 1;

    static void Main()
    {
        CargarDatosEjemplo();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("  SISTEMA DE BIBLIOTECA - TP3 POO");
            Console.WriteLine("===========================================");
            Console.WriteLine("  1. Gestionar Libros");
            Console.WriteLine("  2. Gestionar Usuarios");
            Console.WriteLine("  3. Prestar / Devolver Libro");
            Console.WriteLine("  4. Mostrar Estadísticas (LINQ)");
            Console.WriteLine("  5. Consultas LINQ Avanzadas");
            Console.WriteLine("  6. Mostrar Publicaciones (Herencia)");
            Console.WriteLine("  7. Salir");
            Console.WriteLine("===========================================");
            Console.Write("  Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": MenuLibros(); break;
                case "2": MenuUsuarios(); break;
                case "3": MenuPrestamos(); break;
                case "4": MostrarEstadisticas(); break;
                case "5": ConsultasLINQ(); break;
                case "6": MostrarPublicaciones(); break;
                case "7": return;
                default:
                    Console.WriteLine("Opción inválida. Presione Enter...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CargarDatosEjemplo()
    {
        var libro1 = new Libro(nextLibroId++, "Cien años de soledad", "Gabriel García Márquez", 1967, "978-0307474728");
        var libro2 = new Libro(nextLibroId++, "1984", "George Orwell", 1949, "978-0451524935");
        var libro3 = new Libro(nextLibroId++, "Don Quijote de la Mancha", "Miguel de Cervantes", 1605, "978-8420471895");
        var libro4 = new Libro(nextLibroId++, "El Principito", "Antoine de Saint-Exupéry", 1943, "978-0156012195");
        var libro5 = new Libro(nextLibroId++, "Orgullo y Prejuicio", "Jane Austen", 1813, "978-0141439518");

        biblioteca.AgregarLibro(libro1);
        biblioteca.AgregarLibro(libro2);
        biblioteca.AgregarLibro(libro3);
        biblioteca.AgregarLibro(libro4);
        biblioteca.AgregarLibro(libro5);

        var user1 = new Usuario(nextUsuarioId++, "Martin Lopez", "martin@email.com");
        var user2 = new Usuario(nextUsuarioId++, "Ana Garcia", "ana@email.com");
        usuarios.Add(user1);
        usuarios.Add(user2);

        publicaciones.Add(new Revista(1, "National Geographic", 2024, 250, "National Geographic Society"));
        publicaciones.Add(new Revista(2, "Muy Interesante", 2023, 489, "Zinet"));
        publicaciones.Add(new Revista(3, "Science", 2024, 6700, "AAAS"));

        foreach (var libro in new[] { libro1, libro2, libro3, libro4, libro5 })
        {
            publicaciones.Add(new LibroComoPublicacion(libro));
        }
    }

    static void MenuLibros()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE LIBROS ===");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Mostrar todos los libros");
            Console.WriteLine("3. Buscar libro por ID");
            Console.WriteLine("4. Buscar libros por autor");
            Console.WriteLine("5. Mostrar libros disponibles");
            Console.WriteLine("6. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();
                    Console.Write("Año de publicación: ");
                    int año = int.Parse(Console.ReadLine());
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    biblioteca.AgregarLibro(new Libro(nextLibroId++, titulo, autor, año, isbn));
                    break;
                case "2":
                    biblioteca.MostrarTodosLosLibros();
                    break;
                case "3":
                    Console.Write("Ingrese ID del libro: ");
                    int id = int.Parse(Console.ReadLine());
                    var libro = biblioteca.BuscarPorId(id);
                    if (libro != null) libro.MostrarInfo();
                    else Console.WriteLine("Libro no encontrado.");
                    break;
                case "4":
                    Console.Write("Ingrese nombre del autor: ");
                    string auth = Console.ReadLine();
                    var resultados = biblioteca.BuscarPorAutor(auth);
                    Console.WriteLine($"\nLibros de '{auth}':");
                    foreach (var l in resultados)
                        Console.WriteLine($"  - {l.Titulo} ({l.AñoPublicacion})");
                    break;
                case "5":
                    var disponibles = biblioteca.LibrosDisponibles();
                    Console.WriteLine("\nLibros disponibles:");
                    foreach (var l in disponibles)
                        Console.WriteLine($"  - {l.Titulo} ({l.Autor})");
                    break;
                case "6": return;
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }

    static void MenuUsuarios()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Mostrar usuarios");
            Console.WriteLine("3. Mostrar historial de préstamos");
            Console.WriteLine("4. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    usuarios.Add(new Usuario(nextUsuarioId++, nombre, email));
                    Console.WriteLine($"Usuario '{nombre}' registrado exitosamente.");
                    break;
                case "2":
                    Console.WriteLine($"\nTotal de usuarios: {usuarios.Count}");
                    foreach (var u in usuarios) u.MostrarInfo();
                    break;
                case "3":
                    Console.Write("ID del usuario: ");
                    int uid = int.Parse(Console.ReadLine());
                    var user = usuarios.FirstOrDefault(u => u.Id == uid);
                    if (user != null) user.MostrarHistorial();
                    else Console.WriteLine("Usuario no encontrado.");
                    break;
                case "4": return;
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }

    static void MenuPrestamos()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== PRÉSTAMOS ===");
            Console.WriteLine("1. Prestar libro");
            Console.WriteLine("2. Devolver libro");
            Console.WriteLine("3. Mostrar préstamos activos");
            Console.WriteLine("4. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("ID del libro: ");
                    int libId = int.Parse(Console.ReadLine());
                    Console.Write("ID del usuario: ");
                    int usrId = int.Parse(Console.ReadLine());

                    var libro = biblioteca.BuscarPorId(libId);
                    var usuario = usuarios.FirstOrDefault(u => u.Id == usrId);

                    if (libro == null) { Console.WriteLine("Libro no encontrado."); break; }
                    if (usuario == null) { Console.WriteLine("Usuario no encontrado."); break; }
                    if (!libro.Disponible) { Console.WriteLine("Libro no disponible."); break; }

                    if (biblioteca.PrestarLibro(libId))
                    {
                        var prestamo = new Prestamo(nextPrestamoId++, libro, usuario);
                        prestamos.Add(prestamo);
                        usuario.HistorialPrestamos.Add(prestamo);
                        Console.WriteLine($"Préstamo #{prestamo.Id} registrado.");
                    }
                    break;

                case "2":
                    Console.Write("ID del libro a devolver: ");
                    int devId = int.Parse(Console.ReadLine());

                    var prestamoActivo = prestamos.FirstOrDefault(p => p.Libro.Id == devId && p.FechaDevolucion == null);
                    if (prestamoActivo != null)
                    {
                        prestamoActivo.Devolver();
                        Console.WriteLine($"Libro '{prestamoActivo.Libro.Titulo}' devuelto.");
                    }
                    else
                    {
                        biblioteca.DevolverLibro(devId);
                    }
                    break;

                case "3":
                    var activos = prestamos.Where(p => p.FechaDevolucion == null).ToList();
                    Console.WriteLine($"\nPréstamos activos: {activos.Count}");
                    foreach (var p in activos) p.MostrarInfo();
                    break;

                case "4": return;
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }

    static void MostrarEstadisticas()
    {
        Console.Clear();
        biblioteca.MostrarEstadisticas();
        Console.WriteLine($"\nTotal de usuarios: {usuarios.Count}");
        Console.WriteLine($"Total de préstamos registrados: {prestamos.Count}");

        if (prestamos.Any())
        {
            var masActivo = usuarios
                .OrderByDescending(u => u.HistorialPrestamos.Count)
                .First();
            Console.WriteLine($"Usuario más activo: {masActivo.Nombre} ({masActivo.HistorialPrestamos.Count} préstamos)");

            var libroMasPrestado = prestamos
                .GroupBy(p => p.Libro.Titulo)
                .OrderByDescending(g => g.Count())
                .First();
            Console.WriteLine($"Libro más prestado: {libroMasPrestado.Key} ({libroMasPrestado.Count()} veces)");
        }

        Console.WriteLine($"\nPublicaciones totales: {publicaciones.Count} (Revistas: {publicaciones.OfType<Revista>().Count()}, Libros: {publicaciones.OfType<LibroComoPublicacion>().Count()})");

        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }

    static void ConsultasLINQ()
    {
        var todosLibros = new List<Libro>();
        for (int i = 1; i < nextLibroId; i++)
        {
            var l = biblioteca.BuscarPorId(i);
            if (l != null) todosLibros.Add(l);
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== CONSULTAS LINQ AVANZADAS ===");
            Console.WriteLine("1. Libros ordenados por año (ascendente)");
            Console.WriteLine("2. Libros ordenados por año (descendente)");
            Console.WriteLine("3. Libros agrupados por década");
            Console.WriteLine("4. Buscar libros por palabra en título");
            Console.WriteLine("5. Promedio de antigüedad de los libros");
            Console.WriteLine("6. Libros del siglo XX (1900-1999)");
            Console.WriteLine("7. Libros del siglo XXI (2000-actual)");
            Console.WriteLine("8. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("\nLibros ordenados por año (antiguos primero):");
                    MostrarLibros(todosLibros.OrderBy(l => l.AñoPublicacion).ToList());
                    break;
                case "2":
                    Console.WriteLine("\nLibros ordenados por año (recientes primero):");
                    MostrarLibros(todosLibros.OrderByDescending(l => l.AñoPublicacion).ToList());
                    break;
                case "3":
                    var grupos = todosLibros.GroupBy(l => (l.AñoPublicacion / 10) * 10);
                    Console.WriteLine("\nLibros agrupados por década:");
                    foreach (var g in grupos.OrderBy(g => g.Key))
                    {
                        Console.WriteLine($"\nDécada de {g.Key}:");
                        foreach (var libro in g)
                            Console.WriteLine($"  - {libro.Titulo} ({libro.AñoPublicacion})");
                    }
                    break;
                case "4":
                    Console.Write("Ingrese palabra a buscar: ");
                    string palabra = Console.ReadLine();
                    var filtro = todosLibros.Where(l => l.Titulo.ToLower().Contains(palabra.ToLower()));
                    Console.WriteLine($"\nLibros que contienen '{palabra}':");
                    MostrarLibros(filtro.ToList());
                    break;
                case "5":
                    if (todosLibros.Any())
                    {
                        double promedio = todosLibros.Average(l => l.CalcularAntiguedad());
                        Console.WriteLine($"\nPromedio de antigüedad de todos los libros: {promedio:F1} años");
                        Console.WriteLine($"Libro más antiguo: {todosLibros.OrderBy(l => l.AñoPublicacion).First().Titulo} ({todosLibros.OrderBy(l => l.AñoPublicacion).First().AñoPublicacion})");
                        Console.WriteLine($"Libro más nuevo: {todosLibros.OrderByDescending(l => l.AñoPublicacion).First().Titulo} ({todosLibros.OrderByDescending(l => l.AñoPublicacion).First().AñoPublicacion})");
                    }
                    break;
                case "6":
                    var sigloXX = todosLibros.Where(l => l.AñoPublicacion >= 1900 && l.AñoPublicacion <= 1999);
                    Console.WriteLine($"\nLibros del siglo XX ({sigloXX.Count()} encontrados):");
                    MostrarLibros(sigloXX.ToList());
                    break;
                case "7":
                    var sigloXXI = todosLibros.Where(l => l.AñoPublicacion >= 2000);
                    Console.WriteLine($"\nLibros del siglo XXI ({sigloXXI.Count()} encontrados):");
                    MostrarLibros(sigloXXI.ToList());
                    break;
                case "8": return;
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }

    static void MostrarPublicaciones()
    {
        Console.Clear();
        Console.WriteLine("=== PUBLICACIONES (Herencia y Polimorfismo) ===");
        Console.WriteLine("Demostración de polimorfismo - todas las publicaciones\n");

        foreach (var pub in publicaciones)
        {
            pub.MostrarInfo();
            Console.WriteLine($"  Antigüedad: {pub.CalcularAntiguedad()} años");
            Console.WriteLine($"  Tipo real: {(pub is Revista ? "Revista" : "Libro")}");
        }

        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }

    static void MostrarLibros(List<Libro> listaLibros)
    {
        if (listaLibros.Count == 0)
        {
            Console.WriteLine("No se encontraron libros.");
            return;
        }
        foreach (var l in listaLibros)
        {
            string estado = l.Disponible ? "Disponible" : "Prestado";
            Console.WriteLine($"  [{l.Id}] {l.Titulo} | {l.Autor} ({l.AñoPublicacion}) - {estado}");
        }
    }
}

class LibroComoPublicacion : Publicacion
{
    public string Autor { get; set; }
    public string ISBN { get; set; }

    public LibroComoPublicacion(Libro libro) : base(libro.Id, libro.Titulo, libro.AñoPublicacion)
    {
        Autor = libro.Autor;
        ISBN = libro.ISBN;
        Disponible = libro.Disponible;
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"\n=== LIBRO (como Publicacion) ===");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Año: {AñoPublicacion}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Estado: {(Disponible ? "Disponible" : "Prestado")}");
    }
}

RESUMEN DE TRABAJOS PRACTICOS
Aplicaciones Moviles - ITES


TP1 - HolaMundoMAUI (HelloMAUI)
=================================


Primer proyecto introductorio "Hello, World!" que demuestra la estructura basica de una aplicacion .NET MAUI. Incluye interfaz simple con imagen del bot de .NET, label de bienvenida y boton contador de clics. Soporta tema claro/oscuro (AppThemeBinding), accesibilidad (SemanticProperties), fuentes OpenSans. Usa XAML Source Generation (MauiXamlInflator = SourceGen).

Archivos clave: MauiProgram.cs, App.xaml/.cs, AppShell.xaml, MainPage.xaml/.cs, Resources/Styles/

Proposito educativo: Entender la anatomia de un proyecto MAUI, recursos, configuracion multiplataforma, XAML y code-behind.


TP2 - Ejercicios Basicos de C#
===============================

Tecnologia: Consola C# - .NET 10.0
Plataformas: Consola (Windows/macOS/Linux)

Coleccion de 13 ejercicios de fundamentos de C# en 3 partes:

Parte 1 - Variables y Operadores (Ej. 1-5): Calculadora basica, conversor temperatura, calculadora IMC, calculadora edad, calculadora propina.

Parte 2 - Estructuras de Control (Ej. 6-10): Dia de la semana (switch), tabla multiplicar (for), pares/impares (ternario), juego adivinanza (while), calculadora menu (do-while).

Parte 3 - Metodos (Ej. 11-13): Validador (metodos estaticos), calculadora con metodos (expression-bodied), generador de contrasenas.

Proposito educativo: Variables, operadores, estructuras de control (if/else, switch, for, while), metodos, fundamentos de C#.


TP3 - POO y Colecciones
========================

Tecnologia: Consola C# - .NET 10.0
Plataformas: Consola (Windows/macOS/Linux)

Sistema de gestion de biblioteca que demuestra POO y colecciones con LINQ.

Clases: Publicacion (abstracta), Revista (hereda), Libro, LibroComoPublicacion (wrapper polimorfismo), Usuario (con historial), Prestamo (relaciona libro+usuario+fechas).

Servicio: Biblioteca con CRUD, busqueda ID/autor, prestamo/devolucion, estadisticas LINQ.

Funcionalidades: Gestion libros/usuarios, prestamos, estadisticas, consultas LINQ avanzadas (OrderBy, GroupBy, Average, filtros), polimorfismo.

Proposito educativo: POO (herencia, polimorfismo, encapsulamiento), colecciones (List<T>), LINQ (Where, Select, OrderBy, GroupBy, Average, OfType).


TP4 - PerfilPersonalApp
========================

Tecnologia: .NET MAUI - .NET 10.0
Plataformas: Android, iOS, Mac Catalyst, Windows

Aplicacion de perfil personal con 3 pantallas:
1. WelcomePage: Bienvenida con logo, titulo, boton "Comenzar"
2. ProfileFormPage: Formulario (nombre, email, telefono, fecha nac., pais, genero, bio, notificaciones). Validacion basica.
3. ProfileViewPage: Perfil tarjeta con avatar iniciales, nombre, edad calculada, contacto, bio, genero, notificaciones.

Modelo: UserProfile (FullName, Email, Phone, BirthDate, Country, Bio, Gender, AcceptsNotifications, Age computado).

Proposito educativo: Navegacion entre paginas (PushAsync/PopToRootAsync), formularios con validacion, pase de datos entre paginas, calculo edad, estilos claro/oscuro.


TP5 - CatalogoProductos
========================

Tecnologia: .NET MAUI - .NET 10.0
Plataformas: Android, iOS, Mac Catalyst, Windows

Aplicacion e-commerce con 8 paginas:
- SplashPage (animacion fade + login)
- LoginPage (email+pass, recordarme, animacion)
- HomePage (dashboard, busqueda, categorias, grilla)
- ProductosPage (filtros avanzados, responsive, pull-to-refresh)
- DetallePage (info producto, selector cantidad, carrito, favoritos)
- CarritoPage (items, +/- cantidad, totales)
- FavoritosPage (grilla + empty state)
- ConfiguracionPage (toggle oscuro persistido)

Modelos: Producto (INotifyPropertyChanged), Categoria (emoji+color), CarritoItem (Subtotal).

Servicio: ProductoService (10 productos, 3 categorias, busqueda avanzada, carrito, favoritos).

Proposito educativo: CollectionView, OnIdiom responsive, animaciones (FadeToAsync), tema oscuro (AppThemeBinding), Preferences, patron servicio, UI compleja.


TP6 - Aplicacion con Shell Navigation (BibliotecaApp)
======================================================

Tecnologia: .NET MAUI - .NET 10.0 + CommunityToolkit.Mvvm 8.4.0
Plataformas: Android, iOS, Mac Catalyst, Windows

App "Mi Biblioteca" para gestion de libros con Shell Navigation y MVVM.

Navegacion: TabBar (Inicio, Libros, Favoritos, Perfil) + FlyoutItem (Configuracion, Acerca de) + navegacion programatica con query params.

7 Paginas: HomePage (estadisticas), LibrosPage (lista+search), FavoritosPage (empty view+refresh), DetallePage (info+toggle favorito), PerfilPage (avatar+stats), ConfigPage (oscuro), AcercaDePage.

MVVM: 5 ViewModels con [ObservableProperty] y [RelayCommand], QueryProperty para params. Data binding completo.

Servicio: LibroService (5 libros classicos hardcodeados).

Proposito educativo: Shell (TabBar+FlyoutItem+rutas), MVVM con CommunityToolkit source generators, query properties, separacion de capas.


TP7 - Refactorizacion MVVM (TiendaApp)
=======================================

Tecnologia: .NET MAUI - .NET 10.0 + CommunityToolkit.Mvvm 8.4.0 + DI
Plataformas: Android, iOS, Mac Catalyst, Windows

App "TiendaApp" para gestion de productos, refactorizada a MVVM puro.

Arquitectura limpia: Views -> ViewModels -> Services (interfaz+DI) -> Models
DI registrado en MauiProgram.cs (AddSingleton/AddTransient).

3 Paginas:
- ProductosPage: SearchBar, RefreshView, SwipeView eliminar, FAB, ActivityIndicator
- DetallePage: Info producto, Eliminar, Volver
- AgregarPage: Formulario con validacion (nombre req., precio positivo), error msg

ViewModels: ProductosViewModel (OC, carga, busqueda, CRUD), DetalleViewModel (QueryProperty, confirmacion), AgregarViewModel (validacion).

Servicio: IProductoService (CRUD async), ProductoService in-memory (3 productos: Laptop, Mouse, Teclado).

Proposito educativo: Refactorizacion a MVVM, inyeccion de dependencias, CommunityToolkit.Mvvm avanzado, interfaz de servicio, validacion formularios, navegacion Shell params.

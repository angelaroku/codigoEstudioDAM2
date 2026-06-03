using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using ClaseComponentes.Models;

/*
 * Aqui, vamos a crear nuestro ViewModel, y lo vamos a usar como DataContext de la pagina.
 * El dataContext es la propiedad donde se buscan los bindings. Como va a ser el VM, ahora podemos referirnos a sus comandos y lista de productos.
 * Todo lo demas lo podemos quitar, ya no tenemos que tener aqui la lista de productos; el VM es el que se ocupa de ellos.
 * 
 * 
 * Vamos a cambiar ahora el boton que teniamos, para que funcione con nuestro VM. Ir a xaml
 */

namespace ClaseComponentes
{
    public sealed partial class MainPage : Page
    {
        // Quitar
        //public ObservableCollection<Producto> Productos { get; set; }
        ProductViewModel productViewModel {  get; set; }

        public MainPage()
        {
            productViewModel = new ProductViewModel();
            this.DataContext = productViewModel;
            this.InitializeComponent();

            // Quitar
            //Productos = new ObservableCollection<Producto>
            //{
            //    new Producto {Nombre="Producto A", Descripcion="Bueno", Precio =50},
            //    new Producto {Nombre="Producto B", Descripcion="Bonito", Precio =147},
            //    new Producto {Nombre="Producto C", Descripcion="Barato", Precio =5}
            //};
        }

        // Quitar
        //private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    Productos.Add(new Producto
            //{
            //    Nombre = "Nuevo producto",
            //    Descripcion = "Auto-generado",
            //    Precio = 124
            //});
        //}
    }
}

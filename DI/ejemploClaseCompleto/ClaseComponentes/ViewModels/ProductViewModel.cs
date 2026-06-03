using ClaseComponentes.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;


/*
 * El ViewModel es la capa intermedia entre la vista (XAML / controles) y el modelo (datos). 
 * Su papel es coordinar datos y lógica de presentación sin que la vista sepa cómo se obtienen o manipulan los datos.
 * 
 * Separación de responsabilidades (Single Responsibility):
 * - La vista solo dibuja y captura la interaccion ocn botones y otros controles.
 * - El modelo solo tiene datos. 
 * - El ViewModel coordina; expone colecciones, comandos, valida y transforma los datos para la vista.
 * 
 * Reutlización:
 * - Un mismo Viewmodel se puede usar para distintas vistas; para escritorio y movil, por ejemplo.
 * - El Viewmodel, idealmente, no depende de la libreria de UI, por lo que su logica se puede mover a otro proyecto
 * 
 * Claridad:
 * - Sabemos donde buscar la logica y donde cambiarla. 
 * - Varias vistas compartiran logica, podemos ponerla en el viewmodel para evitar repeticiones
 * 
 * ------
 * 
 * Qué cosas tiene que tener este Viewmodel:
 * -Los productos: es la coleccion que enlaza la vista, de la que bebe. ObservableCollection para que se notifique automaticamente a la UI.
 *  Al ponerla en VM, la UI solo muestra la coleccion, peor no tiene nada de logica.
 *  
 *  
 * - Comandos:
 *  Aqui vamos a enlazar con la UI el comando que hemos creado antes.
 *  
 *  
 *  
 *  Por ultimo, nos queda crear el viewmodel en mainPage. (MainPage.xaml.cs)
 */

public class ProductViewModel
{
    private JsonDataService dataService;
    public ObservableCollection<Producto> Productos { get; set; }

    public ICommand AddProductCommand { get; set; }
    public ICommand DeleteProductCommand { get; set; }
    public ICommand EditProductCommand { get; set; }

    public ProductViewModel()
    {
        Productos = new ObservableCollection<Producto>
        {
            new Producto { Nombre="Mesa", Descripcion="Madera", Precio=120 },
            new Producto { Nombre="Lámpara", Descripcion="LED", Precio=40 }
        };









        /*
         * Creamos el Command que hemos puesto en el MainPage.xaml hace un segundo. Hace exactamente lo mismo que teniamos antes en el callback.
         * Porque, repito, todo lo que estamos haciendo ahora es solo para mejorar la separacion en capas del proyecto. No estmaos cambiando nada 
         * del funcionamiento, solo estamos mejorando la arquitectiura.
         * 
         */
        AddProductCommand = new RelayCommand(_ =>
        {
            Productos.Add(new Producto
            {
                Nombre = "Nuevo producto",
                Descripcion = "Auto-generado",
                Precio = 124
            });

            // ESTO ES DE LA CLASE 2. SI NO HAS LLEGADO A ESE PUNTO, NO LO DESCOMENTES TODAVIA.
            dataService.Save(Productos);
        });

        /*
         * Despues de esto, podriamos crear otros botones, con otros comandos, y toda la funcionalidad estaria aqui.
         * Podriamos borrar, seleccionar productos, duplicarlos, etc., lo importante es que la View no sepa NADA de que hace la app.
         * 
         * Hasta aquí la clase 1. En el siguiente comentario empieza la clase 2.
         */


        /*
         * Clase 2.
         * 
         * Por ultimo, nos qeda como persistir los datos. No lo vamos a ver con bases de datos, porque no es el objetivo del módulo. Pero si 
         * entendeis esto con un json, con BBDD es exactamente lo mismo; solo cambiamos de servicio del que leemos.
         * Vamos a crear un JsonDataService.cs en la carpeta Model, y ahora veremos lo que hace.
         */










        /*
         * Ahora que ya tenemos el servicio implementado, empezamos a usarlo.
         * Creamos un atributo de clase JsonDataService, y lo usamos aqui, en el constructor.
         * Comentad las lineas 49-53, porque ya no hacen falta. Aqui vamos a leer del json nuestros productos.
         * Descomentad estas para que veais que funcionan (estan comentadas para la clase 1).
         * 
         * Por ultimo, quedan dos preguntas importantes:
         * 
         * - ¿cuando guardamos en el json? Cada vez que hay un cambio en nuestros datos:
         * Por ahora, solo cambian al anadir un nuevo producto, con nuestro comando. Por tanto, en ese comando (linea 79), es donde hacemos el save();
         * 
         * - ¿donde se guarda el json?
         * La carpeta donde tenemos nuestro json esta en la ruta C:/Users/<VuestroUsuario>/AppData/Local/Packages/<IdDeLaApp>/LocalState.
         * La IdDeLaApp la podeis ver y cambiar haciendo click derecho en Package.appxmanifest->Propiedades->Empaquetado->Nombre del Paquete.
         * Cada vez que se guarda algo en el json, vereis que en la siguiente ejecucion, se carga sin problemas.
         * 
         * Con esto, ya podemos guardar el estado de la aplicacion en cualquier momento; hemos implementado la persistencia. 
         * Si usais BBDD en lugar de json, solo tendriais que cambiar el JsonDataService, el resto de la aplicacion funciona exactamente igual. Para eso
         * sirve estructurar la aplicacion por capas, y tener claro donde va cada nueva pieza de codigo que escribimos; para no repetir codigo, y para que
         * si manana cambiamos un componente visual, no haya que cambiar la logica de la aplicacion; si cambimos la logica, no haya que cambiar los datos ni 
         * la vista; y si cambiamos los datos, o de donde vienen, no haya que cambiar nada mas.
         * 
         */
        dataService = new JsonDataService();
        Productos = dataService.Load();
    }
}

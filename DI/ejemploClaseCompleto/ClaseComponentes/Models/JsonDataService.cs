using ClaseComponentes.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Windows.Storage;


/*
 * Hasta ahora, el VM se encarga de todo: tiene los datos, decide que hacer con ellos... 
 * Pero en una aplicacion "real", esto no funciona asi. Ya hemos visto que la lista de 
 * productos, por ejemplo, debería leerse de una BBDD, pero que por ahora la estabamos simulando. 
 * Hoy vamos a ver como se leen y se guardan esos datos que va a utilizar nuestra aplicacion.
 * 
 * El ViewModel no deberia saber si los datos se guardan en un archivo, una BBDD, en internet...
 * Solo deberia ser capaz de decir "quiero estos datos" o "guarda estos datos", y otra parte de la aplicacion
 * sera la que sepa como hacerlo. Mas concretamente, se va a hacer desde aqui. 
 * 
 * Este servicio sirve para dos cosas: 
 * - Cargar datos desde un .json
 * - Guardar datos en un .json
 * 
 * Pero no valida los datos, ni decide cuando se guardan, ni sabe quien la llama... 
 * esa toma de decisiones no le corresponde. 
 * 
 * Una vez implementado, lo tenemos que usar desde el VM, que es el que toma esas decisiones, y va a necesitar los datos.
 */

public class JsonDataService
{
    // Nombre de la carpeta donde va a leer nuestro archivo, y donde lo va a guardar. Tambien un nombre de archivo,
    // que no deberia estar hard-coded aqui, pero para nuestra clase nos sirve
    string Folder = ApplicationData.Current.LocalFolder.Path.ToString() + "\\";
    private string FileName = "productos.json";

    /*
     * Metodo para cargar datos. 
     * Si no existe el archivo de dodne vamos a leer datos, NO HAY DATOS. Por tanto, devuelve una lista vacia de objetos Producto.
     * Si existe, lee el archivo y lo desserializa (es decir, lo convierte en objetos de tipo Producto, y los guarda en la lista).
     * 
     * Es decir, ya no vamos a crear objetos a mano, sino que los vamos a leer de un archivo donde esten guardados.
     */
    public ObservableCollection<Producto> Load()
    {
        if (!File.Exists(Folder + FileName))
            return new ObservableCollection<Producto>();

        var json = File.ReadAllText(Folder + FileName);
        return JsonSerializer.Deserialize<ObservableCollection<Producto>>(json);
    }

    /*
     * Para guardar, seializamos los datos (los convertimos de un objeto de tipo Producto a un texto que se guarda en un archivo .json).
     */
    public void Save(ObservableCollection<Producto> productos)
    {
        var json = JsonSerializer.Serialize(productos, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(Folder + FileName, json);
    }

    // Como ya hemos dicho, una vez hemos implementado todo esto, nos moevmos al VM para empezar a utilizarlo. (Vamos a ProductViewModel.cs)
}

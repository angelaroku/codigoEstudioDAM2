using System;
using System.Windows.Input;
/*
 * Al heredar de ICommand, nos pide implementar ciertos métodos:
 * CanExecute, que devuelve un booleano. Nos sirve de control, determina si se va a poder ejecutar el comando en el estado actual.
 * Nosotros, de momento, vamos a hacer que siempre devuelva true; siempre queremos que se ejecute el comando.
 * 
 * Execute, que es lo que va a hacer cuando se invoque.
 * 
 * El evento CanExecuteChanged se ejecuta cuando pasa algo que afecta a si el comando se puede ejecutar. De momento, lo vamos a dejar quieto.
 * 
 */

public class RelayCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    /*
     * Vamos a crear un atributo de tipo Action<object>, porque el comando no sabe lo que tiene que hacer.
     * Solo va a ejecutar lo que le digamos, desde fuera. El comando es solo un ejecutor:
     * - La vista invoca al comando
     * - El comando llama a la accion
     * - La accion contiene la logica que se va a ejecutar.
     * 
     * ¿Por qué? Si el comando tuviera la logica, cada comando tendria que ser una clase distinta, una por accion...
     * Al pasarle un Action desde el ViewMode, los comandos son genericos y reutilizables.
     * 
     * Para eso, ademas, tenemos que crear un constructor que reciba el Action; esa action es la que realmente hace el trabajo,
     * y la definiremos en el viewmodel.
     * 
     * Asi, el comando no tiene que tener ni idea de que es un Producto, que es un precio, ni siquiera de la pantalla en la que estamos.
     * Asi conseguimos la separación entre vista y logica
     */

    public Action<object> accion;

    public RelayCommand(Action<object> action)
    {
        accion = action;
    }

    //public bool CanExecute(object parameter) => true;
    public bool CanExecute(object parameter)
    {
        //throw new NotImplementedException();
        return true;

    }

    /*
     * En Execute, simplemente ejecutamos la accion que le hemos pasado en le constructor.
     */
    public void Execute(object parameter)
    {
        accion(parameter);
    }

    // Vamos ahora a crear el ViewModel del Producto. 
}

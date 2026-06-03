using ClaseComponentes.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ClaseComponentes.Components
{
    public sealed partial class ProductListControl : UserControl
    {
        public ObservableCollection<Producto> Items { get; set; }

        public ProductListControl()
        {
            this.InitializeComponent();
        }

        /*
         * Como queremos que la exposicion sea para leer, no para escribir, el binding mode tiene que ser TwoWay (es decir, que el bindeo vaya tambien en el "otro sentido".
         * Eso nos obliga a definir una DependencyProperty, con su callback...
         */
        public Producto ProductoSeleccionado
        {
            get => (Producto)GetValue(SelectedProductProperty);
            set => SetValue(SelectedProductProperty, value);
        }

        public static readonly DependencyProperty SelectedProductProperty =
            DependencyProperty.Register(nameof(ProductoSeleccionado),
                typeof(Producto),
                typeof(ProductListControl),
                new PropertyMetadata(null));



    }
}
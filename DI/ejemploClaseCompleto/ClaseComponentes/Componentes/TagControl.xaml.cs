using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ClaseComponentes.Components
{
    public sealed partial class TagControl : UserControl
    {
        public TagControl()
        {
            this.InitializeComponent();
        }

        public string TextoEtiqueta { get; set; }
        public Symbol IconoEtiqueta { get; set; }

        public Color ColorFondoEtiqueta
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);

        }

        private static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(ColorFondoEtiqueta), typeof(Color), typeof(TagControl), new PropertyMetadata(string.Empty, OnColorFondoEtiquetaChanged));

        private static void OnColorFondoEtiquetaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (TagControl)d;
            control.TagBorder.Background = new SolidColorBrush((Color)e.NewValue);
        }

    }

}

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ClaseComponentes.Components
{
    public sealed partial class CustomCardControl : UserControl
    {
        public CustomCardControl()
        {
            this.InitializeComponent();
        }

        public string NombreExpuesto
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string DescripcionExpuesta
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }

        public string PrecioExpuesto
        {
            get => (string)GetValue(PriceProperty);
            set => SetValue(PriceProperty, value);
        }


        private static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(NombreExpuesto), typeof(string), typeof(CustomCardControl), new PropertyMetadata(string.Empty, OnTitleChanged));
		
        private static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.Register(nameof(DescripcionExpuesta), typeof(string), typeof(CustomCardControl), new PropertyMetadata(string.Empty, OnSubtitleChanged));
        
        private static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register(nameof(PrecioExpuesto), typeof(string), typeof(CustomCardControl), new PropertyMetadata("$0.00", OnPriceChanged));


        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CustomCardControl)d;
		    control.nombreTarjeta.Text = (string)e.NewValue;
        }


        private static void OnSubtitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CustomCardControl)d;
            control.descripcionTarjeta.Text = (string)e.NewValue;
        }


        private static void OnPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CustomCardControl)d;
            control.precioTarjeta.Text = (string)e.NewValue;
        }

    }
}

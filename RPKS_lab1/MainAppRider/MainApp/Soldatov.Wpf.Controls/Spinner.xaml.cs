using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Soldatov.Wpf.Controls
{
    public partial class Spinner : UserControl
	{
        public Spinner()
		{
			InitializeComponent();
            SizeChanged += Spinner_SizeChanged;
            this.DataContext = this;
        }
        
        public uint Size
        {
            get { return (uint)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        public uint Count
        {
            get { return (uint)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        public enum DirectionEnum
        {
            ClockWise=360,
            CounterClockWise=-360
        }
        public DirectionEnum Direction
        {
            get { return (DirectionEnum)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }
        public float Speed
        {
            get { return (float)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public float Transparency
        {
            get { return (float)GetValue(TransparencyProperty); }
            set { SetValue(TransparencyProperty, value); }
        }
        public static readonly DependencyProperty SizeProperty         = DependencyProperty.Register("Size",         typeof(uint),  typeof(Spinner), new PropertyMetadata((uint)20, OnSizePropertyChanged, OnCoerceSize));
        public static readonly DependencyProperty CountProperty        = DependencyProperty.Register("Count",        typeof(uint),  typeof(Spinner), new PropertyMetadata((uint)15, null, OnCoerceCount));
        public static readonly DependencyProperty DirectionProperty    = DependencyProperty.Register("Direction",    typeof(DirectionEnum), typeof(Spinner), new PropertyMetadata(DirectionEnum.ClockWise));
        public static readonly DependencyProperty SpeedProperty        = DependencyProperty.Register("Speed",        typeof(float), typeof(Spinner), new PropertyMetadata((float)1.0, null, OnCoerceSpeed));
        public static readonly DependencyProperty ColorProperty        = DependencyProperty.Register("Color",        typeof(Brush), typeof(Spinner), new PropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty TransparencyProperty = DependencyProperty.Register("Transparency", typeof(float), typeof(Spinner), new PropertyMetadata((float)0.5, null, OnCoerceTransparency));

        private static void OnSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SizeProperty);
            d.CoerceValue(CountProperty);
            d.CoerceValue(SpeedProperty);
            d.CoerceValue(TransparencyProperty);
        }
        private static object OnCoerceSize(DependencyObject d, object baseValue)
        {
            Spinner control = (Spinner)d;
            uint value = (uint)baseValue;
            
            if (value < 10 || value > 50)
                return control.GetValue(CountProperty);
            return value;
        }
        private static object OnCoerceCount(DependencyObject d, object baseValue)
        {
            var control = (Spinner)d;
            uint value = (uint)baseValue;
            
            return value > 60 ? control.GetValue(CountProperty) : value;
        }
        private static object OnCoerceSpeed(DependencyObject d, object baseValue)
        {
            var control = (Spinner)d;
            float value = (float)baseValue;
            
            return value > 10.0 ? control.GetValue(CountProperty) : value;
        }
        private static object OnCoerceTransparency(DependencyObject d, object baseValue)
        {
            var control = (Spinner)d;
            float value = (float)baseValue;
            
            return value > 1.0 ? control.GetValue(CountProperty) : value;
        }
        
        private void Spinner_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Transform.CenterX = ActualWidth / 2;
            Transform.CenterY = ActualHeight / 2;
            Redraw();
        }

        private void Redraw()
        {
            double count = Count;
            double size = Size, half_size=size/2;
            double center_x = ActualWidth / 2, center_y = ActualHeight / 2, x, y;
            double r = Math.Min(center_x, center_y) - half_size;

            canvas.Children.Clear();
            
            for (double i = 1; i <= count; i++)
            {
                var ellipse = new Ellipse { Fill = Color, Opacity = Transparency, Height = size, Width = size };
                x = center_x + Math.Cos(i / count * 2 * Math.PI) * r - half_size;
                y = center_y + Math.Sin(i / count * 2 * Math.PI) * r - half_size;
                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);
                canvas.Children.Add(ellipse);
            };
        }
    }
}

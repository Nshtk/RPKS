using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Soldatov.Wpf.Controls
{
    public partial class LoadingDialog : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty StyleStringProperty = DependencyProperty.Register("StyleString", typeof(string), typeof(LoadingDialog), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Brush), typeof(LoadingDialog), new PropertyMetadata(Brushes.Black));
        public static readonly DependencyProperty FontProperty = DependencyProperty.Register("Font", typeof(string), typeof(LoadingDialog), new PropertyMetadata());
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(uint), typeof(LoadingDialog), new PropertyMetadata());
        public static readonly DependencyProperty WeightProperty = DependencyProperty.Register("Weight", typeof(uint), typeof(LoadingDialog), new PropertyMetadata());
        public event PropertyChangedEventHandler PropertyChanged;

        public string StyleString
        {
            get { return (string)GetValue(StyleStringProperty); }
            set { SetValue(StyleStringProperty, value); }
        }
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public string Font
        {
            get { return (string)GetValue(FontProperty); }
            set { SetValue(FontProperty, value); }
        }
        public uint Size
        {
            get { return (uint)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        public uint Weight
        {
            get { return (uint)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }
        
        public LoadingDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
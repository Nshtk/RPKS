using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Soldatov.Wpf.MVVM.Core;

namespace Soldatov.Wpf.Controls
{
    public partial class NumericKeyboard : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty StyleStringProperty = DependencyProperty.Register("StyleString", typeof(string), typeof(NumericKeyboard), new PropertyMetadata());
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ICommand AddChar { get; }
        public ICommand DeleteChar { get; }
        public ICommand DeleteString { get; }
        public string _Text;
        
        public string StyleString
        {
            get { return (string)GetValue(StyleStringProperty); }
            set { SetValue(StyleStringProperty, value); }
        }

        public string Text
        {
            get { return _Text; }
            set { _Text = value; OnPropertyChanged("Text"); }
        }

        public NumericKeyboard()
        {
            InitializeComponent();
            this.DataContext = this;
            AddChar = new DelegateCommand(x =>
            {
                Text+=(string)x;
            });
            DeleteChar = new DelegateCommand(x =>
            {
                if(Text!=null && Text.Length>0)
                    Text=Text.Remove(Text.Length-1, 1);
            });
            DeleteString = new DelegateCommand(x =>
            {
                Text="";
            });
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
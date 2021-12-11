using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Soldatov.Wpf.MVVM.Core;

namespace Soldatov.Wpf.Controls
{
    public partial class DialogHost : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty HostContentProperty = DependencyProperty.Register("HostContent", typeof(object), typeof(DialogHost), new PropertyMetadata(null));
        public static readonly DependencyProperty RoundingProperty = DependencyProperty.Register("Rounding", typeof(string), typeof(DialogHost), new PropertyMetadata("0,0,0,0"));
        public static readonly DependencyProperty TransparencyProperty = DependencyProperty.Register("Transparency", typeof(float), typeof(DialogHost), new PropertyMetadata((float)0.4));
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _CmdOpen;
        private ICommand _CmdBackground;
        private Visibility _dialogVisibility = Visibility.Collapsed;
        private bool _isOpen = false;
        private bool? _HostContentResult=null;

        public float Transparency
        {
            get { return (float)GetValue(TransparencyProperty);}
            set { SetValue(TransparencyProperty, value);}
        }
        public string Rounding
        {
            get { return (string)GetValue(RoundingProperty);}
            set { SetValue(RoundingProperty, value);}
        }
        public INotifyPropertyChanged HostContent
        {
            get { return (INotifyPropertyChanged)GetValue(HostContentProperty);}
            set { SetValue(HostContentProperty, value); }
        }
        public ICommand CmdOpen
        {
            get { return _CmdOpen; }
        }
        public ICommand CmdBackground
        {
            get { return _CmdBackground; }
        }
        public Visibility DialogVisibility
        {
            get { return _dialogVisibility; }
            set { _dialogVisibility = value; RaisePropertyChanged("DialogVisibility"); }
        }
        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; RaisePropertyChanged("HostContent");}
        }
        public bool? HostContentResult
        {
            get { return _HostContentResult; }
            set { _HostContentResult = value; }
        }

        public DialogHost()
        {
            InitializeComponent();
            this.DataContext = this;
            _CmdOpen = new DelegateCommand(x => 
            { 
                IsOpen=true;
                DialogVisibility = Visibility.Visible;
            });
            _CmdBackground = new DelegateCommand(x => 
            { 
                IsOpen=false;
                DialogVisibility = Visibility.Collapsed;
            });
        }
        public void OnChildChange(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            IsOpen=false;
            DialogVisibility = Visibility.Collapsed;
        }
        public void RaisePropertyChanged(string property)
        {
            if(IsOpen)
                HostContent.PropertyChanged += OnChildChange;
            else
                HostContent.PropertyChanged -= OnChildChange;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
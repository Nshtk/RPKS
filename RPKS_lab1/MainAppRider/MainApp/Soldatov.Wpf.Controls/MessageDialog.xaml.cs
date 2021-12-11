using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
//using MainApp.Annotations;
using Soldatov.Wpf.MVVM.Core;

namespace Soldatov.Wpf.Controls
{
    public partial class MessageDialog : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty StyleStringProperty = DependencyProperty.Register("StyleString", typeof(string), typeof(MessageDialog), new PropertyMetadata());
        public static readonly DependencyProperty FontProperty = DependencyProperty.Register("Font", typeof(string), typeof(MessageDialog), new PropertyMetadata());
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(uint), typeof(MessageDialog), new PropertyMetadata());
        public static readonly DependencyProperty WeightProperty = DependencyProperty.Register("Weight", typeof(uint), typeof(MessageDialog), new PropertyMetadata());
        public static readonly DependencyProperty OkButtonProperty = DependencyProperty.Register("OkButton", typeof(OkButtonEnum), typeof(MessageDialog), new PropertyMetadata(OkButtonEnum.Disabled));
        public static readonly DependencyProperty OkCancelButtonProperty = DependencyProperty.Register("OkCancelButton", typeof(OkCancelButtonEnum), typeof(MessageDialog), new PropertyMetadata(OkCancelButtonEnum.Disabled));
        public static readonly DependencyProperty YesNoButtonProperty = DependencyProperty.Register("YesNoButton", typeof(YesNoButtonEnum), typeof(MessageDialog), new PropertyMetadata(YesNoButtonEnum.Enabled));
        public event PropertyChangedEventHandler PropertyChanged;
        private bool? _Result;
        
        public ICommand CmdTrue { get; }
        public ICommand CmdFalse { get; }

        public enum OkButtonEnum
        {
            Enabled=1,
            Disabled=0
        }
        public enum OkCancelButtonEnum
        {
            Enabled=1,
            Disabled=0
        }
        public enum YesNoButtonEnum
        {
            Enabled=1,
            Disabled=0
        }
        public string StyleString
        {
            get { return (string)GetValue(StyleStringProperty); }
            set { SetValue(StyleStringProperty, value); }
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
        
        public bool? Result
        {
            get { return _Result; }
            set { _Result = value; OnPropertyChanged("Result");}
        }
        public OkButtonEnum OkButton
        {
            get { return (OkButtonEnum)GetValue(OkButtonProperty); }
            set { SetValue(OkButtonProperty, value); }
        }
        public OkCancelButtonEnum OkCancelButton
        {
            get { return (OkCancelButtonEnum)GetValue(OkCancelButtonProperty); }
            set { SetValue(OkCancelButtonProperty, value); }
        }
        public YesNoButtonEnum YesNoButton
        {
            get { return (YesNoButtonEnum)GetValue(YesNoButtonProperty); }
            set { SetValue(YesNoButtonProperty, value); }
        }
        
        public MessageDialog()
        {
            InitializeComponent();
            this.DataContext = this;
            CmdTrue = new DelegateCommand(x => 
            { 
                Result=true;
            });
            CmdFalse = new DelegateCommand(x => 
            { 
                Result=false; 
            });
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
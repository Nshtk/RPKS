using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Soldatov.Wpf.Controls
{
    public partial class NumericUpDown : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnValueChanged)));
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(10000, new PropertyChangedCallback(OnValueChanged)));
        public static readonly DependencyProperty ValueProperty    = DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnValueChanged), new CoerceValueCallback(CoerceValue)), ValidateValue);
        public static readonly DependencyProperty StepProperty     = DependencyProperty.Register("Step", typeof(uint), typeof(NumericUpDown), new FrameworkPropertyMetadata((uint)1, new PropertyChangedCallback(OnValueChangedStep), new CoerceValueCallback(CoerceValueStep)));
        
        public int MinValue
        {
            get { return (int) GetValue(MinValueProperty);}
            set {SetValue(MinValueProperty, value);}
        }
        public int MaxValue
        {
            get { return (int) GetValue(MaxValueProperty);}
            set {SetValue(MaxValueProperty, value);}
        }
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); OnPropertyChanged("Value");}
        }
        public uint Step
        {
            get { return (uint)GetValue(StepProperty); }
            set { SetValue(StepProperty, value);}
        }
        
        public NumericUpDown()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            d.CoerceValue(ValueProperty);
        }
        private static object CoerceValue(DependencyObject d, object value)
        {
            NumericUpDown control = (NumericUpDown)d;

            return control.CoerceValue((int)value);
        }
        private int CoerceValue(int value)
        {
            return Math.Max(MinValue, Math.Min(MaxValue, value));
        }
        private static void OnValueChangedStep(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            d.CoerceValue(ValueProperty);
        }
        private static object CoerceValueStep(DependencyObject d, object value)
        {
            int v = Convert.ToInt32(value);
            if (v < 0)
                return 1;
            return value;
        }
        private static bool ValidateValue(object value)
        {
            return ((int)value > Int32.MinValue || (int)value<Int32.MaxValue);
        }
        private void Button_Click_Up(object sender, EventArgs e)
        {
            Value+=(int)Step;
        }
        private void Button_Click_Down(object sender, EventArgs e)
        {
            Value-=(int)Step;
        }
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

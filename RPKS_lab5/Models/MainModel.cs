using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace RPKS_lab5.Models
{
    public static class FontAttributes
    {
        public enum FormatEnum
        {
            Normal,
            Oblique,
            Italic
        }
        
        public static Random random = new Random();
        private static readonly Array formats = Enum.GetValues(typeof(FormatEnum));
        public static readonly List<string> names = new List<string>()
        {
            "Arial",
            "Impact",
            "Times New Roman",
            "Comic Sans MS",
            "MS Gothic",
            "Lucida",
            "Franklin Gothic",
            "Symbol",
            "Verdana"
        };
        public static readonly List<int> sizes = new List<int>()
        {
            8, 10, 12, 14, 16, 18, 20, 22, 24, 26
        };
        public static readonly List<Brush> colors = new List<Brush>()
        {
            Brushes.Yellow,
            Brushes.Orange,
            Brushes.Red,
            Brushes.Green,
            Brushes.Aqua,
            Brushes.Violet,
            Brushes.Blue,
            Brushes.Black
        };

        public static dynamic getRandomValue(string attribute_name)
        {
            dynamic value;
            
            switch (attribute_name)
            {
                case ("Name"):
                    value = names[random.Next(names.Count)];
                    break;
                case ("Size"):
                    value = sizes[random.Next(sizes.Count)];
                    break;
                case ("Format"):
                    value = formats.GetValue(random.Next(formats.Length));
                    break;
                case ("Color"):
                    value = colors[random.Next(colors.Count)];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attribute_name),"Invalid attribute.");
            }

            return value;
        }
    }
    
    public class Font : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _FontName;
        private int _FontSize;
        private FontAttributes.FormatEnum _FontFormat;
        private Brush _FontColor;

        public string FontName
        {
            get { return _FontName;}
            set { _FontName = value; OnPropertyChanged("FontName"); }
        }
        public int FontSize 
        {
            get { return _FontSize;}
            set { _FontSize = value; OnPropertyChanged("FontSize"); }
        }
        public FontAttributes.FormatEnum FontFormat 
        {
            get { return _FontFormat;}
            set { _FontFormat = value; OnPropertyChanged("FontFormat"); }
        }
        public Brush FontColor 
        {
            get { return _FontColor;}
            set { _FontColor = value; OnPropertyChanged("FontColor"); }
        }

        public Font()
        { }

        public void randomiseProperties()
        {
            FontName = (string)FontAttributes.getRandomValue("Name");
            FontSize = (int)FontAttributes.getRandomValue("Size");
            FontFormat = (FontAttributes.FormatEnum)FontAttributes.getRandomValue("Format");
            FontColor = (Brush)FontAttributes.getRandomValue("Color");
        }

        private void OnPropertyChanged(string property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {}
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute=execute;
            _canExecute=canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute==null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged!=null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
    
    
}
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Soldatov.Wpf.MVVM.Core;

namespace Soldatov.Wpf.Controls
{
    public partial class LetterKeyboard : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty StyleStringProperty = DependencyProperty.Register("StyleString", typeof(string), typeof(LetterKeyboard), new PropertyMetadata());
        public static readonly DependencyProperty CommandStringProperty = DependencyProperty.Register("CommandString", typeof(string), typeof(LetterKeyboard), new PropertyMetadata("AddChar"));
        public event PropertyChangedEventHandler PropertyChanged;
                
        public string _Text;
        public bool _CapsLock = false;
        public string _CurrentCulture="en";
        public string _CultureImage = "images/image_ru.png";
        
        public ICommand AddChar { get; }
        public ICommand DeleteChar { get; }
        public ICommand DeleteString { get; }
        public ICommand ChangeCulture { get; }
        public ICommand CapitalLetters { get; }

        public string StyleString
        {
            get { return (string)GetValue(StyleStringProperty); }
            set { SetValue(StyleStringProperty, value); }
        }
        public string CommandString
        {
            get { return (string)GetValue(CommandStringProperty); }
            set { SetValue(CommandStringProperty, value); }
        }
        public string Text
        {
            get { return _Text; }
            set { _Text = value; OnPropertyChanged("Text"); }
        }
        public string CurrentCulture
        {
            get { return _CurrentCulture; }
            set { _CurrentCulture = value; OnPropertyChanged("CurrentCulture"); }
        }
        public bool CapsLock
        {
            get { return _CapsLock; }
            set { _CapsLock = value; OnPropertyChanged("CapsLock"); }
        }
        public string CultureImage 
        {
            get { return _CultureImage; }
            set { _CultureImage = value; OnPropertyChanged("CultureImage");}
        }

        public List<string[]> _Letters = new List<string[]>()
        {
            {new string[] {"q", "Q", "й", "Й"}},
            {new string[] {"w", "W", "ц", "Ц"}},
            {new string[] {"e", "E", "у", "У"}},
            {new string[] {"r", "R", "к", "К"}},
            {new string[] {"t", "T", "е", "Е"}},
            {new string[] {"y", "Y", "н", "Н"}},
            {new string[] {"u", "U", "г", "Г"}},
            {new string[] {"i", "I", "ш", "Ш"}},
            {new string[] {"o", "O", "щ", "Щ"}},
            {new string[] {"p", "P", "з", "З"}},
            {new string[] {"a", "A", "ф", "Ф"}},
            {new string[] {"s", "S", "ы", "Ы"}},
            {new string[] {"d", "D", "в", "В"}},
            {new string[] {"f", "F", "а", "А"}},
            {new string[] {"g", "G", "п", "П"}},
            {new string[] {"h", "H", "р", "Р"}},
            {new string[] {"j", "J", "о", "О"}},
            {new string[] {"k", "K", "л", "Л"}},
            {new string[] {"l", "L", "д", "Д"}},
            {new string[] {"z", "Z", "я", "Я"}},
            {new string[] {"x", "X", "ч", "Ч"}},
            {new string[] {"c", "C", "с", "С"}},
            {new string[] {"v", "V", "м", "М"}},
            {new string[] {"b", "B", "и", "И"}},
            {new string[] {"n", "N", "т", "Т"}},
            {new string[] {"m", "M", "ь", "Ь"}},
            {new string[] {"", "", "ё", "Ё"}},
            {new string[] {"", "", "х", "Х"}},
            {new string[] {"", "", "ъ", "Ъ"}},
            {new string[] {"", "", "ж", "Ж"}},
            {new string[] {"", "", "ю", "Ю"}},
            {new string[] {"", "", "б", "Б"}}
            //{new string[] {"Eng", "ENG", "Рус", "РУС"}}
        };
        public List<string[]> Letters
        {
            get { return _Letters; }
            set { _Letters=value; }
        }

        public LetterKeyboard()
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
            ChangeCulture = new DelegateCommand(x =>
            {
                if (CurrentCulture == "en")
                {
                    CurrentCulture = "ru";
                    CultureImage = "images/image_en.png";
                }
                else
                {
                    CultureImage = "images/image_ru.png";
                    CurrentCulture = "en";
                }
            });
            CapitalLetters = new DelegateCommand(x =>
            {
                if(CapsLock)
                    CapsLock = false;
                else
                    CapsLock = true;
            });
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
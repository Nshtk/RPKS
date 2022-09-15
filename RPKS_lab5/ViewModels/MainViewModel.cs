using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using RPKS_lab5.Models;

namespace RPKS_lab5.ViewModels
{
    public sealed class  MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CmdStart { get; }
        public ICommand CmdEnd { get; }
        public ICommand CmdCheck { get; }
        public ICommand CmdNextPage { get; }
        public ICommand CmdPreviousPage { get; }
        

        private uint _CurrentPage = 0;
        private string _Text="Sample text";
        private string _Hint="";
        private int _Score=0;
        private Font _EnvisionedFont = new Font();
        private Font _DevisionedFont = new Font();
        private bool[] _Enabled = new bool[]
        {
            true,
            true,
            true,
            true,
            true
        };
        private Visibility _CheckButtonVisibility = Visibility.Collapsed;
        private Visibility _SideButtonsVisibility = Visibility.Hidden;
        private Visibility[] _Pages = new Visibility[]
        {
            Visibility.Visible,
            Visibility.Collapsed,
            Visibility.Collapsed,
            Visibility.Collapsed,
            Visibility.Collapsed
        };
        public Visibility CheckButtonVisibility
        {
            get { return _CheckButtonVisibility; }
            set { _CheckButtonVisibility=value; OnPropertyChanged("CheckButtonVisibility");}
        }
        public Visibility SideButtonsVisibility
        {
            get { return _SideButtonsVisibility; }
            set { _SideButtonsVisibility=value; OnPropertyChanged("SideButtonsVisibility");}
        }
        public bool[] Enabled
        {
            get { return _Enabled; }
        }
        public Visibility[] Pages
        {
            get { return _Pages; }
        }
        private Visibility CurrentPage
        {
            get { return Pages[_CurrentPage]; }
            set {  Pages[_CurrentPage] = value; OnPropertyChanged("Pages");}
        }
        public string Text
        {
            get { return _Text; }
            set { _Text = value; OnPropertyChanged("Text"); }
        }
        public string Hint
        {
            get { return _Hint; }
            set { _Hint = value; OnPropertyChanged("Hint"); }
        }

        public Font EnvisionedFont
        {
            get { return _EnvisionedFont; }
        }
        public Font DevisionedFont
        {
            get { return _DevisionedFont; }
        }
        public int Score
        {
            get { return _Score; }
            set { _Score = value; OnPropertyChanged("Score"); }
        }
        public MainViewModel()
        {
            CmdStart = new DelegateCommand(x => 
            {
                _EnvisionedFont.randomiseProperties();
                CurrentPage = Visibility.Collapsed;
                _CurrentPage+=1;
                CurrentPage = Visibility.Visible;
                SideButtonsVisibility = Visibility.Visible;
                CheckButtonVisibility = Visibility.Visible;
            });
            
            CmdEnd = new DelegateCommand(x => 
            {
                CurrentPage = Visibility.Collapsed;
                _CurrentPage=0;
                CurrentPage = Visibility.Visible;
                MessageBox.Show("Your score is "+Score.ToString());
            });
            CmdCheck = new DelegateCommand(x => 
            {
                if (Enabled[_CurrentPage])
                {
                    switch (_CurrentPage)
                    {
                        case 1:
                            if (DevisionedFont.FontName == EnvisionedFont.FontName)
                            {
                                Score += 20;
                                Enabled[_CurrentPage] = false;
                                OnPropertyChanged("Enabled");
                            }
                            else
                                Score -= 10;
                            break;
                        case 2:
                            if (DevisionedFont.FontSize == EnvisionedFont.FontSize)
                            {
                                Score += 10;
                                Enabled[_CurrentPage] = false;
                                OnPropertyChanged("Enabled");
                            }
                            else
                                Score -= 10;
                            break;
                        case 3:
                            if (DevisionedFont.FontFormat == EnvisionedFont.FontFormat)
                            {
                                Score += 10;
                                Enabled[_CurrentPage] = false;
                                OnPropertyChanged("Enabled");
                            }
                            else
                                Score -= 5;
                            break;
                        case 4:
                            if (DevisionedFont.FontColor == EnvisionedFont.FontColor)
                            {
                                Score += 5;
                                Enabled[_CurrentPage] = false;
                                OnPropertyChanged("Enabled");
                            }
                            else
                                Score -= 10;
                            break;
                    }
                }
                
            });
            CmdNextPage = new DelegateCommand(x => 
            {
                if (_CurrentPage>3)
                    return;
                CurrentPage = Visibility.Collapsed;
                _CurrentPage+=1;
                CurrentPage = Visibility.Visible;
            });
            CmdPreviousPage = new DelegateCommand(x => 
            { 
                if (_CurrentPage<2)
                    return;
                CurrentPage = Visibility.Collapsed;
                _CurrentPage-=1;
                CurrentPage = Visibility.Visible;
            });
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
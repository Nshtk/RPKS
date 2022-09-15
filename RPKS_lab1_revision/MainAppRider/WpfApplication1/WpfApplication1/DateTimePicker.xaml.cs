using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public partial class DateTimePicker : UserControl
    {
        public static DependencyProperty YearProperty = DependencyProperty.Register("Year", typeof(int), typeof(DateTimePicker), new FrameworkPropertyMetadata(2021, new PropertyChangedCallback(PropertyChanged)));
        public static DependencyProperty MonthProperty = DependencyProperty.Register("Mounth", typeof(int), typeof(DateTimePicker), new FrameworkPropertyMetadata(4, new PropertyChangedCallback(PropertyChanged)));
        public static DependencyProperty DayProperty = DependencyProperty.Register("Day", typeof(int), typeof(DateTimePicker), new FrameworkPropertyMetadata(3, new PropertyChangedCallback(PropertyChanged)));
        public static DependencyProperty HourProperty = DependencyProperty.Register("Hour", typeof(int), typeof(DateTimePicker), new FrameworkPropertyMetadata(1, new PropertyChangedCallback(PropertyChanged)));
        public static DependencyProperty MinuteProperty = DependencyProperty.Register("Minute", typeof(int), typeof(DateTimePicker), new FrameworkPropertyMetadata(1, new PropertyChangedCallback(PropertyChanged)));
        public static DependencyProperty SecondProperty = DependencyProperty.Register("Second", typeof(int), typeof(DateTimePicker), new FrameworkPropertyMetadata(1, new PropertyChangedCallback(PropertyChanged)));
        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
        }
        public int Year
        {
            get
            {
                return (int)GetValue(MonthProperty);
            }
            set
            {
                SetValue(MonthProperty, value);
            }
        }
        public int Month
        {
            get
            {
                return (int)GetValue(YearProperty);
            }
            set
            {
                SetValue(YearProperty, value);
            }
        }
        public int Day
        {
            get
            {
                return (int)GetValue(DayProperty);
            }
            set
            {
                SetValue(DayProperty, value);
            }
        }
        public int Hour
        {
            get
            {
                return (int)GetValue(HourProperty);

            }
            set
            {
                SetValue(HourProperty, value);
            }
        }
        public int Minute
        {
            get
            {
                return (int)GetValue(MinuteProperty);
            }
            set
            {
                SetValue(MinuteProperty, value);
            }
        }
        
        public int Second
        {
            get
            {
                return (int)GetValue(SecondProperty);
            }
            set
            {
                SetValue(SecondProperty, value);
            }
        }
 

        public DateTimePicker()
        {
            InitializeComponent();

            this.DataContext = this;

            Loaded += (o, r) =>
            {
                int i;
                List<ComboBoxItem> years = new List<ComboBoxItem>();
                List<ComboBoxItem> months = new List<ComboBoxItem>();
                List<ComboBoxItem> days = new List<ComboBoxItem>();
                List<ComboBoxItem> hours = new List<ComboBoxItem>();
                List<ComboBoxItem> minutes = new List<ComboBoxItem>();
                List<ComboBoxItem> seconds = new List<ComboBoxItem>();
                for (i = 1930; i <= 2021; i++)
                    years.Add(new ComboBoxItem() { Content = i });
                for (i = 1; i <= 12; i++)
                    months.Add(new ComboBoxItem() { Content = i });
                for (i = 1; i <= 30; i++)
                    days.Add(new ComboBoxItem() { Content = i });
                for (i = 1; i <= 30; i++)
                    hours.Add(new ComboBoxItem() { Content = i });
                for (i = 1; i <= 12; i++)
                {
                    minutes.Add(new ComboBoxItem() { Content = i });
                    seconds.Add(new ComboBoxItem() { Content = i });
                }

                Months.ItemsSource = months;
                Months.Text = Month.ToString();
                Years.ItemsSource = years;
                Years.Text = Year.ToString();
                Days.ItemsSource = months;
                Days.Text = Month.ToString();
                Hours.ItemsSource = hours;
                Hours.Text = Year.ToString();
                Minutes.ItemsSource = minutes;
                Minutes.Text = Year.ToString();
                Seconds.ItemsSource = seconds;
                Seconds.Text = Year.ToString();
            };
        }
    }
}
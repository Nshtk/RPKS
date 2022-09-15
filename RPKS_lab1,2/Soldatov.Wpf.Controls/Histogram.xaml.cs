using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Soldatov.Wpf.MVVM.Core;

namespace Soldatov.Wpf.Controls
{
    public partial class Histogram : UserControl, INotifyPropertyChanged
    {
        public DependencyProperty ValueMinProperty=DependencyProperty.Register("ValueMin", typeof(int), typeof(Histogram), new PropertyMetadata(0));
        public DependencyProperty ValueMaxProperty=DependencyProperty.Register("ValueMax", typeof(int), typeof(Histogram), new PropertyMetadata(1000));
        public event PropertyChangedEventHandler PropertyChanged;

        private int size;
        public string BarName { set; get; }
        public int ValueMin { set; get; }
        public int ValueMax { set; get; }
        public Sorting Sorting { set; get; }

        public ObservableCollection<Chart> Charts { get; set; }

        Histogram()
        {
            InitializeComponent();
            this.DataContext = this;
            size=Math.Abs(ValueMax - ValueMin);
            Randomise();
        }

        public void Randomise()
        {
            //int[] positions = new int[size];
            List<int> positions = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                positions[i] = i;
            }
            IOrderedEnumerable<int> randomized = positions.OrderBy(item => rnd.Next());
            foreach (var chart in Charts)
            {
                chart.position = randomized.Last();
                //randomized.
            }
        }
        
        protected void OnPropertyChanged(string property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
    
    public class Chart
    {
        internal int value;
        internal int position;
        
        Chart()
        {
            
        }
    }
    
    
    
    public class Sorting : ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set {name = value;}
        }
        private uint[] array;
        private uint size;
        public uint Size
        {
            get { return size; }
            set { size = value; OnPropertyChanged("Size"); }
        }

        public Sorting()
        {
            array = new uint[size];
            for (uint i = 1; i <= size; i++)
                array[size] = i;
        }
        public virtual void sort() {}
    }
    public class InsertionSorting : Sorting
    {
        public override void sort()
        {

        }
    }
    public class SelectionSorting : Sorting
    {
        public override void sort()
        {

        }
    }
    public class RankSorting : Sorting
    {
        public override void sort()
        {

        }
    }
    public class MergeSorting : Sorting
    {
        public override void sort()
        {

        }
    }
    public class PyramidSorting : Sorting
    {
        public override void sort()
        {

        }
    }
}
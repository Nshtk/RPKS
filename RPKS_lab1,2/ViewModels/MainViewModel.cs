using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MainApp.Models;
using Soldatov.Wpf.Controls;
using Soldatov.Wpf.MVVM.Core;

namespace MainApp.ViewModels
{
	class MainViewModel : ViewModelBase
	{
		private string start_button_text;
		public Sorting selected_sorting;
		public ObservableCollection<Sorting> Sortings { get; set; }
		/*private DialogHost _DialogHost = new DialogHost();
		public DialogHost DialogHost { get { return _DialogHost;} set{} }*/
		public MainViewModel()
		{
			Sortings = new ObservableCollection<Sorting>() {
				new InsertionSorting { Name="Insertion sorting", Size=10000},
				new SelectionSorting { Name="Selection sorting", Size=10000},
				new RankSorting		 { Name="Rank sorting",		 Size=10000},
				new MergeSorting	 { Name="Merge sorting",	 Size=10000},
				new PyramidSorting	 { Name="Pyramid sorting",	 Size=10000},
			};
			SelectedSorting = Sortings[0];
			StartButtonText = "Start";
		}
		
		public string StartButtonText
		{
			get { return start_button_text; }
			set { start_button_text = value; }
		}
		public Sorting SelectedSorting
		{
			get { return selected_sorting; }
			set { selected_sorting = value; OnPropertyChanged("SelectedSorting"); }
		}
	}
}
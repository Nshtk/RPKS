﻿using System;
using System.Windows;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace Soldatov.Wpf.MVVM.Core
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void invokePropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

		protected void invokePropertiesChanged(params string[] properties)
		{
			foreach (var property in properties)
				invokePropertyChanged(property);
		}
	}
	
	public abstract class ValueConverterBase<TConverter> : MarkupExtension, IValueConverter where TConverter : class, new()
	{
		private static TConverter _ValueToProvide;

		protected virtual bool Check(in object value, in object parameter)
		{
			if(value==null)
				throw new ArgumentException("value is null", nameof(value));

			return true;
		}
		public virtual object Convert(object value, Type target_type, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public virtual object ConvertBack(object value, Type target_type, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override sealed object ProvideValue(IServiceProvider ServiceProvider)
		{
			return _ValueToProvide ??= new TConverter();
		}
	}
	public abstract class MultiValueConverterBase<TMultiConverter> : MarkupExtension, IMultiValueConverter where TMultiConverter : class, new()
	{
		private static TMultiConverter _ValueToProvide;

		protected virtual bool Check(in object[] values, in object parameter)
		{
			if (!(parameter is string))
				throw new ArgumentException("Invalid input: operator is not of type String.", nameof(parameter));
			if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
				return false;

			return true;
		}
		public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return _ValueToProvide ??= new TMultiConverter();
		}
	}

	public sealed class RelayCommand : ICommand
	{
		private readonly Action<object> _execute;
		private readonly Predicate<object> _canExecute;

		public RelayCommand(Action<object> execute, Predicate<object> canExecute=null)
		{
			_execute=execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute=canExecute;
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}
		public bool CanExecute(object parameter)
		{
			return _canExecute?.Invoke(parameter) ?? true;
		}

		public event EventHandler CanExecuteChanged
		{
			add {CommandManager.RequerySuggested+=value;}
			remove {CommandManager.RequerySuggested-=value;}
		}
	}

	public sealed class RelayCommandAsync : ICommand
	{
		private readonly Func<Task> _execute;
		private readonly Predicate<object> _canExecute;
		private readonly Action<Exception> _onException;
		private bool _is_executing;
		public bool IsExecuting
		{
			get {return _is_executing;}
			set
			{
				_is_executing = value;
				//CanExecuteChanged-=
				//CanExecuteChanged?.Invoke(this, new EventArgs());
			}
		}

		public RelayCommandAsync(Func<Task> execute, Predicate<object> canExecute, Action<Exception> onException)
		{
			_onException=onException;
			_canExecute= canExecute ?? ((object p)=>!IsExecuting);
			_execute=execute;
		}
		
		public async void Execute(object parameter)
		{
			IsExecuting = true;
			Task tsk;
			tsk=ExecuteAsync(parameter);
			/*try
			{
				tsk=ExecuteAsync(parameter);
				tsk.Wait();
			}
			catch (Exception ex)
			{
				_onException?.Invoke(ex);
			}*/
			tsk.ContinueWith(task  =>
			{
				IsExecuting=false;
			});

		}
		private async Task ExecuteAsync(object parameter)
		{
			await _execute();
		}
		public bool CanExecute(object parameter)
		{
			return _canExecute?.Invoke(parameter) ?? true;
		}
		
		public event EventHandler CanExecuteChanged
		{
			add {CommandManager.RequerySuggested+=value;}
			remove {CommandManager.RequerySuggested-=value;}
		}
	}
	
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged
        {
	        add { CommandManager.RequerySuggested += value; }
	        remove { CommandManager.RequerySuggested -= value; }
        }

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
        
        /*public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged!=null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.Windows;
using System.Globalization;
using System.Text;
using System.Numerics;
using System.Windows.Markup;
using Soldatov.Wpf.MVVM.Core;
using System.Windows.Data;
using System.Windows.Media;

namespace Soldatov.Wpf.MVVM
{
	public enum ArithmeticEnum
	{
		Addition,
		Substraction,
		Multiplication,
		Division,
		Modulo
	}
	public enum EqualityEnum
	{
		Equal,
		NotEqual
	}
	public enum CompareEnum
	{
		GreaterThan,
		GreaterOrEqual,
		LessThan,
		LessOrEqual
	}
	public enum LogicalEnum
	{
		And,
		Or,
		Not
	}
	public enum BitwiseEnum
	{
		And,
		Or,
		Complement,
		ExclusiveOr
	}
	internal sealed class ArithmeticConverter : MultiValueConverterBase<ArithmeticConverter>
	{
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if(!Check(in values, parameter))
				return DependencyProperty.UnsetValue;

			var left_operand = (dynamic)values[0]; var right_operand = (dynamic)values[1];
			ArithmeticEnum operation = (ArithmeticEnum)parameter;
			
			switch (operation)
			{
				case (ArithmeticEnum.Addition):
					return (left_operand + right_operand).ToString();
				case (ArithmeticEnum.Substraction):
					return (left_operand - right_operand).ToString();
				case (ArithmeticEnum.Multiplication):
					return (left_operand * right_operand).ToString();
				case (ArithmeticEnum.Division):
					return (left_operand / right_operand).ToString();
				case (ArithmeticEnum.Modulo):
					return (left_operand % right_operand).ToString();
				default:
					throw new ArgumentOutOfRangeException(nameof(parameter),"Invalid operation");
			}
		}
	}
	public sealed class EqualityConverter : MultiValueConverterBase<EqualityConverter>
	{
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!Check(in values, parameter))
				return DependencyProperty.UnsetValue;

			var left_operand = (dynamic)values[0]; var right_operand = (dynamic)values[1];
			EqualityEnum operation= (EqualityEnum)parameter;
			
			switch (parameter)
			{
				case (EqualityEnum.Equal):
					return (left_operand == right_operand).ToString();
				case (EqualityEnum.NotEqual):
					return (left_operand != right_operand).ToString();
				default:
					throw new ArgumentOutOfRangeException(nameof(parameter),"Invalid operation.");
			}
		}
	}
	public sealed class CompareConverter : MultiValueConverterBase<CompareConverter>
	{
		protected override bool Check(in object[] values, in object parameter)
		{
			if (values.Length != 2)
				throw new ArgumentException("Number of values should be 2.", nameof(values));
			if (!(parameter is Enum))
				throw new ArgumentException("Invalid input: operator is not of type Enum.", nameof(parameter));
			if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
				return false;

			return true;
		}

		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!Check(in values, parameter))
				return DependencyProperty.UnsetValue;

			var left_operand = (dynamic)values[0]; var right_operand = (dynamic)values[1];
			CompareEnum operation = (CompareEnum)parameter;
			
			switch (operation)
			{
				case (CompareEnum.GreaterThan):
					return (left_operand > right_operand).ToString();
				case (CompareEnum.LessThan):
					return (left_operand < right_operand).ToString();
				case (CompareEnum.GreaterOrEqual):
					return (left_operand >= right_operand).ToString();
				case (CompareEnum.LessOrEqual):
					return (left_operand <= right_operand).ToString();
				default:
					throw new ArgumentOutOfRangeException(nameof(parameter),"Invalid operation");
			}
		}
	}
	public sealed class LogicalConverter : MultiValueConverterBase<LogicalConverter>
	{
		protected override bool Check(in object[] values, in object parameter)
		{
			if (values.Length != 2)
				throw new ArgumentException("Number of values should be 2.", nameof(values));
			if (!(parameter is Enum))
				throw new ArgumentException("Invalid input: operator is not of type Enum.", nameof(parameter));
			if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
				return false;

			return true;
		}
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!Check(in values, parameter))
				return DependencyProperty.UnsetValue;

			var left_operand = (dynamic)values[0]; var right_operand = (dynamic)values[1];
			LogicalEnum operation= (LogicalEnum)parameter;
			
			switch (parameter)
			{
				case (LogicalEnum.Or):
					return (left_operand || right_operand).ToString();
				case (LogicalEnum.And):
					return (left_operand && right_operand).ToString();
				case (LogicalEnum.Not):
					return (left_operand != right_operand).ToString();
				default:
					throw new ArgumentOutOfRangeException(nameof(parameter),"Invalid operation.");
			}
		}
	}
	public sealed class BitwiseConverter : MultiValueConverterBase<BitwiseConverter>
	{
		protected override bool Check(in object[] values, in object parameter)
		{
			if (values.Length != 2)
				throw new ArgumentException("Number of values should be 2.", nameof(values));
			if (!(parameter is Enum))
				throw new ArgumentException("Invalid input: operator is not of type Enum.", nameof(parameter));
			if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
				return false;

			return true;
		}
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!Check(in values, parameter))
				return DependencyProperty.UnsetValue;

			var left_operand = (dynamic)values[0]; var right_operand = (dynamic)values[1];
			BitwiseEnum operation= (BitwiseEnum)parameter;
			
			switch (parameter)
			{
				case (BitwiseEnum.And):
					return (left_operand | right_operand).ToString();
				case (BitwiseEnum.Or):
					return (left_operand & right_operand).ToString();
				case (BitwiseEnum.Complement):
					return (~left_operand).ToString();
				case (BitwiseEnum.ExclusiveOr):
					return (left_operand ^ right_operand).ToString();
				default:
					throw new ArgumentOutOfRangeException(nameof(parameter),"Invalid operation.");
			}
		}
	}
	public sealed class RoundConverter : ValueConverterBase<RoundConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!Check(in value, parameter))
				return DependencyProperty.UnsetValue;

			return value;
		}
		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!Check(in value, parameter))
				return DependencyProperty.UnsetValue;

			return value;
		}
	}
	public sealed class IsNullConverter : ValueConverterBase<IsNullConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value is null).ToString();
		}
	}
	public class BoolConverter : ValueConverterBase<BoolConverter>
	{
		protected override bool Check(in object value, in object parameter)
		{
			if (!(value is bool @bool))
				throw new ArgumentException("Value is not of type Bool.", nameof(value));
			return @bool;
		}
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Check(value, parameter) ? "true" : "false";
		}
	}
	public class EnumConverter : ValueConverterBase<EnumConverter>
	{
		protected override bool Check(in object value, in object parameter)
		{
			if (!(value is Enum))
				throw new ArgumentException("value is not of type Enum", nameof(value));
			return true;
		}
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(!Check(value, parameter))
				return DependencyProperty.UnsetValue;
			
			return (int)value==0;
		}
	}
	public class ConverterEnumBool : ValueConverterBase<ConverterEnumBool>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value?.Equals(parameter);
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value?.Equals(true) == true ? parameter : Binding.DoNothing;
		}
	}
	
	public class ConverterByteArrayString : ValueConverterBase<ConverterByteArrayString>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value!=null ?System.Convert.ToBase64String((byte[])value) :Binding.DoNothing;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.IsNullOrWhiteSpace((string)value) ?null :BigInteger.Parse((string)value).ToByteArray();
		}
	}
	
	public class EnumButtonConverter : ValueConverterBase<EnumButtonConverter>
	{
		protected override bool Check(in object value, in object parameter)
		{
			if (!(value is Enum))
				throw new ArgumentException("value is not of type System.Enum", nameof(value));
			return true;
		}
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (Check(value, parameter))
				if ((int) value == 1)
					return Visibility.Visible;
			
			return Visibility.Collapsed;;
		}
	}
	public class ListToCharConverter : MultiValueConverterBase<ListToCharConverter>
	{
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			List<string[]> letters = new List<string[]>((IEnumerable<string[]>) values[0]);
			string localisation = values[2].ToString();
			int button_id = System.Convert.ToInt32(parameter), letter_type = button_id;
			bool caps = (bool) values[1];
			
			switch (localisation)
			{
				case ("en"):
				{
					letter_type = 0;
					break;
				}
				case ("ru"):
				{
					letter_type = 2;
					break;
				}
				default:
					letter_type = 0;
					break;
			}

			if (caps)
				letter_type += 1;
			
			return letters[button_id][letter_type];
		}
	}
	public class SpeedConverter : ValueConverterBase<SpeedConverter>
	{
		protected override bool Check(in object value, in object parameter)
		{
			if (!(value is Enum))
				throw new ArgumentException("value is not of type System.Enum", nameof(value));
			return true;
		}
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//Check(value, parameter);
			
			string speed = "0:0:" + value.ToString();
			
			return speed;
		}
	}
	public class TransparencyConverter : ValueConverterBase<TransparencyConverter>
	{
		protected override bool Check(in object value, in object parameter)
		{
			if (!(value is Enum))
				throw new ArgumentException("value is not of type System.Enum", nameof(value));
			return true;
		}
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			float val = (float) value;
			
			if (val < 0.3)
				return Brushes.White;
			if (val < 0.6)
				return Brushes.Gray;
				
			return Brushes.Black;
		}
	}
	public class StyleConverter : MultiValueConverterBase<StyleConverter> 
	{
		public override object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			FrameworkElement target_element = values[0] as FrameworkElement; 
			string style_name = values[1] as string;

			if (style_name == null)
				return null;

			Style new_style = (Style)target_element.TryFindResource(style_name);

			if (new_style == null)
				new_style = (Style)target_element.TryFindResource("MyDefaultStyleName");

			return new_style;
		}

		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public class NestedMultiBindingCollection : System.Collections.ObjectModel.Collection<BindingBase>
	{
		protected override void InsertItem(int index, BindingBase item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));
			ValidateItem(item);

			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, BindingBase item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));
			ValidateItem(item);

			base.SetItem(index, item);
		}

		private void ValidateItem(BindingBase binding)
		{
			if (binding == null)
				throw new ArgumentNullException(nameof(binding));
		}
	}

	[ContentProperty(nameof(Bindings))]
	public class NestedMultiBinding : MarkupExtension
	{
		public MultiBinding MultiBinding { get; set; }
		public IMultiValueConverter Converter { get; set; }
		public CultureInfo ConverterCulture { get; set; }
		public object ConverterParameter { get; set; }
		public NestedMultiBindingCollection Bindings { get; }

		public NestedMultiBinding()
		{
			Bindings = new NestedMultiBindingCollection();
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var target = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
			
			if (target.TargetObject.GetType().FullName == "System.Windows.SharedDp")
				return this;

			if (MultiBinding != null)
			{
				Converter = MultiBinding.Converter;
				ConverterParameter = MultiBinding.ConverterParameter;
				ConverterCulture = MultiBinding.ConverterCulture;
				foreach (var binding_base in MultiBinding.Bindings)
					Bindings.Add(binding_base);
			}

			if (target.TargetObject is NestedMultiBindingCollection)
			{
				var binding = new Binding
				{
					Source = this
				};
				return binding;
			}

			var multiBinding = new MultiBinding
			{
				Mode = BindingMode.OneWay
			};

			return multiBinding.ProvideValue(serviceProvider);
		}

		public void AddChild(object value)
		{
			var binding = value as BindingBase;
			if (binding != null)
				Bindings.Add(binding);
			else
				throw new ArgumentNullException(nameof(value));
		}

		public void AddText(string text)
		{
			if (string.IsNullOrEmpty(text))
				return;
			if (!string.IsNullOrWhiteSpace(text))
				throw new ArgumentException();
		}
	}
}

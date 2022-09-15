using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace RPKS_lab5.Models
{
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

        public class VisibilityConverter : ValueConverterBase<VisibilityConverter>
        {
            protected override bool Check(in object value, in object parameter)
            {
                if (!(value is Enum))
                    throw new ArgumentException("value is not of type System.Enum", nameof(value));
                return true;
            }
            public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                IList enumerable = value as IList;
                Visibility vis = Visibility.Collapsed;
                
                if(enumerable!=null)
                    vis = (Visibility) enumerable[System.Convert.ToInt32(parameter)];
                
                return vis;
            }
        }
        public class EnumConverter : ValueConverterBase<EnumConverter>
        {
            protected override bool Check(in object value, in object parameter)
            {
                if (!(value is Enum))
                    throw new ArgumentException("value is not of type System.Enum", nameof(value));
                return true;
            }
            public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string str = Enum.GetName(value.GetType(), value);
                
                return str;
            }
            public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                FontAttributes.FormatEnum enumValue = default(FontAttributes.FormatEnum);
                if (value != null)
                    enumValue= (FontAttributes.FormatEnum)value;

                return enumValue;
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
                IList enumerable = value as IList;
                bool enabled = false;
                
                if(enumerable!=null)
                    enabled = (bool)enumerable[System.Convert.ToInt32(parameter)];
                
                return enabled;
                //return Check(value, parameter) ? "True" : "False";
            }
        }
        public class BrushConverter : ValueConverterBase<BrushConverter>
        {
            public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                Brush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
                return brush;
            }
            public override object ConvertBack(object value, Type target_type, object parameter, CultureInfo culture)
            {
                Brush brush=null;
                if(value!=null)
                    brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));

                return brush;
            }
        }
}
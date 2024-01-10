using System.Globalization;
using System.Windows.Data;

namespace SW.MB.UI.WPF.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => value is bool boolean ? !boolean : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => Convert(value, targetType, parameter, culture);
    }
}

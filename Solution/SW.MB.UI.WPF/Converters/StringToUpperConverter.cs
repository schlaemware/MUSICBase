using System.Globalization;
using System.Windows.Data;

namespace SW.MB.UI.WPF.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class StringToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string str ? str.ToUpper() : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

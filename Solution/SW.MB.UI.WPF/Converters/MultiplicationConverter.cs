using System.Globalization;
using System.Windows.Data;

namespace SW.MB.UI.WPF.Converters
{
    [ValueConversion(typeof(double), typeof(double), ParameterType = typeof(double))]
    public class MultiplicationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double valDouble && parameter is double parDouble ? valDouble * parDouble : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double valDouble && parameter is double parDouble && parDouble != 0.0 ? valDouble / parDouble : value;
        }
    }
}

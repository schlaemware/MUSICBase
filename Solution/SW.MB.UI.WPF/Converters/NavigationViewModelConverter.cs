using System.Globalization;
using System.Windows.Data;

namespace SW.MB.UI.WPF.Converters
{
    [ValueConversion(typeof(Type), typeof(bool), ParameterType = typeof(Type))]
    public class NavigationViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => parameter is Type type && value.GetType() == type;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => throw new NotSupportedException();
    }
}

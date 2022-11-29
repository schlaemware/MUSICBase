using System;
using Microsoft.UI.Xaml.Data;

namespace SW.MB.UI.WinUI3.Converters {
    public class BooleanInvertingConverter: IValueConverter {
    public object Convert(object value, Type targetType, object parameter, string language) {
      if (value is bool boolean) {
        return !boolean;
      }

      throw new ArgumentException($"{GetType().Name}: value must be boolean!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) {
      if (value is bool boolean) {
        return !boolean;
      }

      throw new ArgumentException($"{GetType().Name}: value must be boolean!");
    }
  }
}

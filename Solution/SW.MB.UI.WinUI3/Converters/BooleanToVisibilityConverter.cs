using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace SW.MB.UI.WinUI3.Converters {
  public class BooleanToVisibilityConverter: IValueConverter {
    public object Convert(object value, Type targetType, object parameter, string language) {
      if (value is bool boolean) {
        if (parameter != null && bool.TryParse(parameter.ToString(), out bool inverted) && inverted) {
          return boolean ? Visibility.Collapsed : Visibility.Visible;
        }

        return boolean ? Visibility.Visible : Visibility.Collapsed;
      }

      throw new ArgumentException($"{GetType().Name}: value must be boolean!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) {
      if (value is Visibility visibility) {
        return visibility == Visibility.Visible;
      }

      throw new ArgumentException($"{GetType().Name}: value must be visibility!");
    }
  }
}

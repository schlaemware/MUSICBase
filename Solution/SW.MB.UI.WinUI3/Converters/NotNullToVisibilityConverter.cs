using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace SW.MB.UI.WinUI3.Converters {
  public class NotNullToVisibilityConverter: IValueConverter {
    public object Convert(object value, Type targetType, object parameter, string language) {
      return value != null ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) {
      throw new NotSupportedException();
    }
  }
}

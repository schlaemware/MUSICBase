using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace SW.MB.UI.WinUI3.Converters {
  public class EnumToBooleanConverter: IValueConverter {
    public object Convert(object value, Type targetType, object parameter, string language) {
      if (parameter is string enumString) {
        if (!Enum.IsDefined(typeof(ElementTheme), value)) {
          throw new ArgumentException("EnumToBooleanConverter: value must be an enum!");
        }

        object enumValue = Enum.Parse(typeof(ElementTheme), enumString);

        return enumValue.Equals(value);
      }

      throw new ArgumentException("EnumToBooleanConverter: parameter must be an enum name!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) {
      if (parameter is string enumString) {
        return Enum.Parse(typeof(ElementTheme), enumString);
      }

      throw new ArgumentException("EnumToBooleanConverter: parameter must be an enum name!");
    }
  }
}

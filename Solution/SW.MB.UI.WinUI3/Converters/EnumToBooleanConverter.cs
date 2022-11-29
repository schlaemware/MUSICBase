using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using SW.MB.UI.WinUI3.Models.Enumerations;

namespace SW.MB.UI.WinUI3.Converters {
  public class EnumToBooleanConverter: IValueConverter {
    public object Convert(object value, Type targetType, object parameter, string language) {
      if (parameter is string enumString) {
        object enumValue;

        if (value is ElementTheme) {
          enumValue = Enum.Parse(typeof(ElementTheme), enumString);
        } else if (value is PersonsDisplayMode) {
          enumValue = Enum.Parse(typeof(PersonsDisplayMode), enumString);
        } else if (value is PersonsOrderingMode) {
          enumValue = Enum.Parse(typeof(PersonsOrderingMode), enumString);
        } else {
          throw new ArgumentException("EnumToBooleanConverter: value must be an enum!");
        }

        return enumValue.Equals(value);
      }

      throw new ArgumentException("EnumToBooleanConverter: parameter must be an enum name!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) {
      if (parameter is string enumString) {
        if (Enum.TryParse(enumString, out ElementTheme theme)) {
          return theme;
        } else if (Enum.TryParse(enumString, out PersonsDisplayMode displayMode)) {
          return displayMode;
        } else if (Enum.TryParse(enumString, out PersonsOrderingMode orderingMode)) {
          return orderingMode;
        }
      }

      throw new ArgumentException("EnumToBooleanConverter: parameter must be an enum name!");
    }
  }
}

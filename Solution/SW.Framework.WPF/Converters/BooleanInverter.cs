using System;
using System.Globalization;
using System.Windows.Data;

namespace SW.Framework.WPF.Converters {
  /// <summary>
  /// Inverts the value of a <see cref="bool"/>.
  /// </summary>
  [ValueConversion(typeof(bool), typeof(bool))]
  public class BooleanInverter: IValueConverter {
    /// <summary>
    /// Inverts the value of a <see cref="bool"/>.
    /// </summary>
    /// <param name="value"><see cref="bool"/> to invert.</param>
    /// <param name="targetType">UNUSED</param>
    /// <param name="parameter">UNUSED</param>
    /// <param name="culture">UNUSED</param>
    /// <returns>Der invertierte Wert.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      return value is bool boolean || bool.TryParse(value.ToString(), out boolean) ? !boolean : value;
    }

    /// <summary>
    /// Inverts the value of a <see cref="bool"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="bool"/>s are binary values. So function is same as <see cref="Convert(object, Type, object, CultureInfo)"/>.
    /// </remarks>
    /// <param name="value"><see cref="bool"/> to invert.</param>
    /// <param name="targetType">UNUSED</param>
    /// <param name="parameter">UNUSED</param>
    /// <param name="culture">UNUSED</param>
    /// <returns>Der invertierte Wert.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      return Convert(value, targetType, parameter, culture);
    }
  }
}

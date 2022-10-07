using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SW.Framework.WPF {
  /// <summary>
  /// Abstract base class for all observable classes.
  /// </summary>
  public abstract class ObservableObject: INotifyPropertyChanged {
    /// <summary>
    /// Occurs when a property value has changed.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Triggers the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="propertyName">Name of the property that changed.</param>
    protected void OnPropertyChanged(string propertyName) {
      VerifyPropertyName(propertyName);
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Sets value for property.
    /// </summary>
    /// <remarks>
    /// Triggers the <see cref="PropertyChanged"/> event if value has changed.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="reference">The reference object.</param>
    /// <param name="newValue">The new value.</param>
    /// <param name="propertyName">The name of the property to change.</param>
    /// <returns><c>TRUE</c>, if a new value is set.</returns>
    protected bool SetProperty<T>(ref T reference, T newValue, [CallerMemberName] string? propertyName = null) {
      if (!Equals(reference, newValue)) {
        reference = newValue;
#pragma warning disable CS8604 // Possible null reference argument.
        OnPropertyChanged(propertyName);
#pragma warning restore CS8604 // Possible null reference argument.

        return true;
      }

      return false;
    }

    /// <summary>
    /// Check if property exists.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <exception cref="ArgumentNullException"></exception>
    [Conditional("DEBUG")]
    private void VerifyPropertyName(string propertyName) {
      if (TypeDescriptor.GetProperties(this)[propertyName] == null) {
        throw new ArgumentNullException($"{GetType().Name} does not contain property {propertyName}");
      }
    }
  }
}

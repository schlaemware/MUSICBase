using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Local.Framework.WPF.Contracts.Stores;
using Local.Framework.WPF.ViewModels;
using SW.Framework.Extensions;
using SW.Framework.WPF.Models;

namespace Local.Framework.WPF.Stores {
  public abstract class NavigationStore : ObservableObject, INavigationStore {
    private static readonly Dispatcher _Dispatcher = Application.Current.Dispatcher;

    public ObservableCollection<ExtendedViewModelBase> ViewModelCollection { get; } = new();

    public void NavigateTo<T>(Func<T> factory) where T : ExtendedViewModelBase {
      if (!ViewModelCollection.OfType<T>().Any()) {
        _Dispatcher.Invoke(() => ViewModelCollection.Add(factory()));
      }

      ViewModelCollection.ForEach(x => x.IsActive = x.GetType() == typeof(T));
    }

    public void NavigateTo<T, K>(Func<K?, T> factory, K? parameter) where T : ExtendedViewModelBase where K : struct {
      _Dispatcher.Invoke(() => ViewModelCollection.Add(factory(parameter)));
      ViewModelCollection.ForEach(x => x.IsActive = x.GetType() == typeof(T));
    }
  }
}

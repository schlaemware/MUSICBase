using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Local.Framework.WPF.ViewModels;

namespace Local.Framework.WPF.Contracts.Stores {
  public interface INavigationStore : INotifyPropertyChanged {
    public ObservableCollection<ExtendedViewModelBase> ViewModelCollection { get; }

    public void NavigateTo<T>(Func<T> factory) where T : ExtendedViewModelBase;
    public void NavigateTo<T, K>(Func<K?, T> factory, K? parameter) where T : ExtendedViewModelBase where K : struct;
  }
}

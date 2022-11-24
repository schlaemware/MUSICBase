using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;

namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface INavigationViewService {
    public IList<object>? MenuItems { get; }
    public object? SettingsItem { get; }

    public NavigationViewItem? GetSelectedItem(Type pageType);
    public void Initialize(NavigationView navigationView);
    public void UnregisterEvents();
  }
}

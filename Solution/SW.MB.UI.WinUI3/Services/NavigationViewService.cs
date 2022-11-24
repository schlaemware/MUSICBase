using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Helpers;
using SW.MB.UI.WinUI3.ViewModels;

namespace SW.MB.UI.WinUI3.Services {
  internal class NavigationViewService: INavigationViewService {
    private readonly INavigationService _NavigationService;
    private readonly IPageService _PageService;

    private NavigationView? _NavigationView;

    public IList<object>? MenuItems => _NavigationView?.MenuItems;

    public object? SettingsItem => _NavigationView?.SettingsItem;

    #region CONSTRUCTORS
    public NavigationViewService(INavigationService navigationService, IPageService pageService) {
      _NavigationService = navigationService;
      _PageService = pageService;
    }
    #endregion CONSTRUCTORS

    public NavigationViewItem? GetSelectedItem(Type pageType) {
      if (_NavigationView != null) {
        return GetSelectedItem(_NavigationView.MenuItems, pageType) ?? GetSelectedItem(_NavigationView.FooterMenuItems, pageType);
      }

      return null;
    }

    [MemberNotNull(nameof(_NavigationView))]
    public void Initialize(NavigationView navigationView) {
      _NavigationView = navigationView;
      _NavigationView.BackRequested += NavigationView_BackRequested;
      _NavigationView.ItemInvoked += NavigationView_ItemInvoked;
    }

    public void UnregisterEvents() {
      if (_NavigationView != null) {
        _NavigationView.BackRequested -= NavigationView_BackRequested;
        _NavigationView.ItemInvoked -= NavigationView_ItemInvoked;
      }
    }

    private NavigationViewItem? GetSelectedItem(IEnumerable<object> menuItems, Type pageType) {
      foreach (NavigationViewItem item in menuItems.OfType<NavigationViewItem>()) {
        if (IsMenuItemForPageType(item, pageType)) {
          return item;
        }

        NavigationViewItem? selectedChild = GetSelectedItem(item.MenuItems, pageType);
        if (selectedChild != null) {
          return selectedChild;
        }
      }

      return null;
    }

    private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType) {
      if (menuItem.GetValue(NavigationHelper.NavigateToProperty) is string pageKey) {
        return _PageService.GetPageType(pageKey) == sourcePageType;
      }

      return false;
    }

    #region CALLBACKS
    private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args) {
      _NavigationService.GoBack();
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args) {
      if (args.IsSettingsInvoked) {
        _NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);
      } else {
        NavigationViewItem? selectedItem = args.InvokedItemContainer as NavigationViewItem;

        if (selectedItem?.GetValue(NavigationHelper.NavigateToProperty) is string pageKey) {
          _NavigationService.NavigateTo(pageKey);
        }
      }
    }
    #endregion CALLBACKS
  }
}

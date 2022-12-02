using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Contracts.ViewModels;
using SW.MB.UI.WinUI3.Extensions;

namespace SW.MB.UI.WinUI3.Services {
  internal class NavigationService: INavigationService {
    private readonly IPageService _PageService;

    private object? _LastParameterUsed;
    private Frame? _Frame;

    [MemberNotNullWhen(true, nameof(Frame), nameof(_Frame))]
    public bool CanGoBack => Frame != null && Frame.CanGoBack;

    public Frame? Frame {
      get {
        if (_Frame == null) {
          _Frame = App.MainWindow.Content as Frame;
          RegisterFrameEvents();
        }

        return _Frame;
      }
      set {
        UnregisterFrameEvents();
        _Frame = value;
        RegisterFrameEvents();
      }
    }

    #region EVENTS
    public event NavigatedEventHandler? Navigated;
    #endregion EVENTS

    #region CONSTRUCTORS
    public NavigationService(IPageService pageService) {
      _PageService = pageService;
    }
    #endregion CONSTRUCTORS

    public bool GoBack() {
      if (CanGoBack) {
        var vmBeforeNavigation = _Frame.GetPageViewModel();
        _Frame.GoBack();
        if (vmBeforeNavigation is INavigationAware navigationAware) {
          navigationAware.OnNavigatedFrom();
        }

        return true;
      }

      return false;
    }

    public bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false) {
      Type pageType = _PageService.GetPageType(pageKey);

      if (_Frame != null && (_Frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_LastParameterUsed)))) {
        _Frame.Tag = clearNavigation;
        object? vmBeforeNavigation = _Frame.GetPageViewModel();
        bool navigated = _Frame.Navigate(pageType, parameter);

        if (navigated) {
          _LastParameterUsed = parameter;
          if (vmBeforeNavigation is INavigationAware navigationAware) {
            navigationAware.OnNavigatedFrom();
          }
        }

        return navigated;
      }

      return false;
    }

    private void RegisterFrameEvents() {
      if (_Frame != null) {
        _Frame.Navigated += Frame_Navigated;
      }
    }

    private void UnregisterFrameEvents() {
      if (_Frame != null) {
        _Frame.Navigated -= Frame_Navigated;
      }
    }

    #region CALLBACKS
    private void Frame_Navigated(object sender, NavigationEventArgs e) {
      if (sender is Frame frame) {
        bool clearNavigation = (bool)frame.Tag;
        if (clearNavigation) {
          frame.BackStack.Clear();
        }

        if (frame.GetPageViewModel() is INavigationAware navigationAware) {
          navigationAware.OnNavigatedTo(e.Parameter);
        }

        Navigated?.Invoke(sender, e);
      }
    }
    #endregion CALLBACKS
  }
}

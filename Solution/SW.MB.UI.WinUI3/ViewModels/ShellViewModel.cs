using System;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Models.Messages;
using SW.MB.UI.WinUI3.Models.Observables;
using SW.MB.UI.WinUI3.ViewModels.Abstracts;
using SW.MB.UI.WinUI3.Views.Pages;

namespace SW.MB.UI.WinUI3.ViewModels {
  public class ShellViewModel: BaseViewModel {
    private bool _IsBackEnabled;
    private object? _Selected;
    private bool _IsCompositionsModuleEnabled;
    private bool _IsMandatorsModuleEnabled;
    private bool _IsMembersModuleEnabled;
    private bool _IsMusiciansModuleEnabled;
    private bool _IsProgramsModuleEnabled;
    private bool _IsUsersModuleEnabled;
    private bool _IsUserLoggedIn;
    private string? _LoggedInUserName;

    public INavigationService NavigationService { get; }

    public INavigationViewService NavigationViewService { get; }

    public bool IsBackEnabled {
      get => _IsBackEnabled;
      set => SetProperty(ref _IsBackEnabled, value);
    }

    public object? Selected {
      get => _Selected;
      set => SetProperty(ref _Selected, value);
    }

    #region MODULES
    public bool IsCompositionsModuleEnabled {
      get => _IsCompositionsModuleEnabled;
      private set => SetProperty(ref _IsCompositionsModuleEnabled, value);
    }

    public bool IsMandatorsModuleEnabled {
      get => _IsMandatorsModuleEnabled;
      private set => SetProperty(ref _IsMandatorsModuleEnabled, value);
    }

    public bool IsMembersModuleEnabled {
      get => _IsMembersModuleEnabled;
      private set => SetProperty(ref _IsMembersModuleEnabled, value);
    }

    public bool IsMusiciansModuleEnabled {
      get => _IsMusiciansModuleEnabled;
      private set => SetProperty(ref _IsMusiciansModuleEnabled, value);
    }

    public bool IsProgramsModuleEnabled {
      get => _IsProgramsModuleEnabled;
      private set => SetProperty(ref _IsProgramsModuleEnabled, value);
    }

    public bool IsUsersModuleEnabled {
      get => _IsUsersModuleEnabled;
      private set => SetProperty(ref _IsUsersModuleEnabled, value);
    }
    #endregion MODULES

    public bool IsUserLoggedIn {
      get => _IsUserLoggedIn;
      private set => SetProperty(ref _IsUserLoggedIn, value);
    }

    public string? LoggedInUserName {
      get => _LoggedInUserName;
      set => SetProperty(ref _LoggedInUserName, value);
    }

    public string ActiveMandantString => "Musikverein Berneck";

    #region CONSTRUCTORS
    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService) {
      NavigationService = navigationService;
      NavigationService.Navigated += NavigationService_Navigated;
      NavigationViewService = navigationViewService;

      App.LoggedInUserChanged += App_LoggedInUserChanged;

      NavigationService.NavigateTo(typeof(HomeViewModel).FullName!);
    }
    #endregion CONSTRUCTORS

    protected override void OnActivated() {
      base.OnActivated();

      Messenger.Register<ShellViewModel, PermissionsChangedMessage>(this, (r, _) => r.Receive());
    }

    private void Receive() {
      IPermissionsService permissionsService = App.GetService<IPermissionsService>();

      IsCompositionsModuleEnabled = permissionsService.IsCompositionsModuleEnabled;
      IsMandatorsModuleEnabled = permissionsService.IsMandatorsModuleEnabled;
      IsMembersModuleEnabled = permissionsService.IsMembersModuleEnabled;
      IsMusiciansModuleEnabled = permissionsService.IsMusiciansModuleEnabled;
      IsProgramsModuleEnabled = permissionsService.IsProgramsModuleEnabled;
      IsUsersModuleEnabled = permissionsService.IsUsersModuleEnabled;
    }

    #region CALLBACKS
    private void App_LoggedInUserChanged(object? sender, UserRecord e) {
      IsUserLoggedIn = e != null;
      LoggedInUserName = new ObservableUser(e).Fullname;
    }

    private void NavigationService_Navigated(object sender, NavigationEventArgs e) {
      IsBackEnabled = NavigationService.CanGoBack;

      if (e.SourcePageType == typeof(SettingsPage)) {
        Selected = NavigationViewService.SettingsItem;
        return;
      }

      NavigationViewItem? selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
      if (selectedItem != null) {
        Selected = selectedItem;
      }
    }
    #endregion CALLBACKS
  }
}

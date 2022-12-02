using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.ViewModels;

namespace SW.MB.UI.WinUI3.Activation {
  public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs> {
    private readonly INavigationService _NavigationService;

    #region CONSTRUCTORS
    public DefaultActivationHandler(INavigationService navigationService) {
      _NavigationService = navigationService;
    }
    #endregion CONSTRUCTORS

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args) {
      // None of the ActivationHandlers has handled the activation.
      return _NavigationService.Frame?.Content == null;
    }

    protected override async Task HandleInternalAsync(LaunchActivatedEventArgs args) {
      if (App.IsUserLoggedIn) {
        _NavigationService.NavigateTo(typeof(HomeViewModel).FullName!, args.Arguments);
      } else {
        _NavigationService.NavigateTo(typeof(LoginViewModel).FullName!, args.Arguments);
      }

      await Task.CompletedTask;
    }
  }
}

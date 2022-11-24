using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SW.MB.UI.WinUI3.Activation;
using SW.MB.UI.WinUI3.Contracts.Activation;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Views.Pages;

namespace SW.MB.UI.WinUI3.Services {
  public class ActivationService: IActivationService {
    private readonly ActivationHandler<LaunchActivatedEventArgs> _DefaultHandler;
    private readonly IEnumerable<IActivationHandler> _ActivationHandlers;
    private readonly IThemeSelectorService _ThemeSelectorService;

    private UIElement? _Shell = null;

    #region CONSTRUCTORS
    public ActivationService(ActivationHandler<LaunchActivatedEventArgs> defaultHandler, IEnumerable<IActivationHandler> activationHandlers,
      IThemeSelectorService themeSelectorService) {
      _DefaultHandler = defaultHandler;
      _ActivationHandlers = activationHandlers;
      _ThemeSelectorService = themeSelectorService;
    }
    #endregion CONSTRUCTORS

    public async Task ActivateAsync(object activationArgs) {
      // Execute tasks before activation.
      await InitializeAsync();

      // Set the MainWindow Content.
      if (App.MainWindow.Content == null) {
        _Shell = App.GetService<ShellPage>();
        App.MainWindow.Content = _Shell ?? new Frame();
      }

      // Handle activation via ActivationHandlers.
      await HandleActivationAsync(activationArgs);

      // Activate the MainWindow.
      App.MainWindow.Activate();

      // Execute tasks after activation.
      await StartupAsync();
    }

    private async Task HandleActivationAsync(object activationArgs) {
      IActivationHandler? activationHandler = _ActivationHandlers.FirstOrDefault(h => h.CanHandle(activationArgs));

      if (activationHandler != null) {
        await activationHandler.HandleAsync(activationArgs);
      }

      if (_DefaultHandler.CanHandle(activationArgs)) {
        await _DefaultHandler.HandleAsync(activationArgs);
      }
    }

    private async Task InitializeAsync() {
      await _ThemeSelectorService.InitializeAsync().ConfigureAwait(false);
      await Task.CompletedTask;
    }

    private async Task StartupAsync() {
      await _ThemeSelectorService.SetRequestedThemeAsync();
      await Task.CompletedTask;
    }
  }
}

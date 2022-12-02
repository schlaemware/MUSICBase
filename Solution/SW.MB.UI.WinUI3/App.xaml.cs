using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.HostBuilder;
using SW.MB.UI.WinUI3.Views.Pages;
using SW.MB.UI.WinUI3.Views.Windows;

namespace SW.MB.UI.WinUI3 {
  /// <summary>
  /// Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  public partial class App: Application {
    private static UserRecord? _LoggedInUser;

    protected IHost Host { get; } = MyHostBuilder.Build();

    public static DispatcherQueue Dispatcher { get; set; } = DispatcherQueue.GetForCurrentThread();
    public static Window MainWindow { get; } = new MainWindow();

    public static bool IsUserLoggedIn => LoggedInUser != null;
    public static UserRecord? LoggedInUser {
      get => _LoggedInUser;
      private set {
        if (value != null && _LoggedInUser != value) {
          _LoggedInUser = value;
          LoggedInUserChanged?.Invoke(Current as App, _LoggedInUser);
        }
      }
    }

    #region EVENTS
    public static event EventHandler<UserRecord>? LoggedInUserChanged;
    #endregion EVENTS

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App() {
      InitializeComponent();

      UnhandledException += App_UnhandledException;
    }

    public static T GetService<T>() where T : class {
      if ((Current as App)!.Host.Services.GetService(typeof(T)) is not T service) {
        throw new ArgumentException($"{typeof(T)} needs to be registered in {typeof(MyHostBuilder).Name}!");
      }

      return service;
    }

    public static bool TryLogin(string name, string password, bool storeLogin) {
      //Task.Delay(3000).Wait();

      if (GetService<IUsersDataService>().TryLogIn(name, password, storeLogin, out UserRecord loggedInUser)) {
        Dispatcher.TryEnqueue(() => {
          LoggedInUser = loggedInUser;
          //LoggedInUserChanged?.Invoke(Current as App, loggedInUser);
        });
        
        return true;
      }

      return false;
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override async void OnLaunched(LaunchActivatedEventArgs args) {
      base.OnLaunched(args);

      await GetService<IActivationService>().ActivateAsync(args);
    }

    #region CALLBACKS
    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e) {
      throw new Exception(e.Message);
    }
    #endregion CALLBACKS
  }
}

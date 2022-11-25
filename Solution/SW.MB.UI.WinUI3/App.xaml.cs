using System;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.HostBuilder;
using SW.MB.UI.WinUI3.Views.Windows;

namespace SW.MB.UI.WinUI3 {
  /// <summary>
  /// Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  public partial class App: Application {
    protected IHost Host { get; } = MyHostBuilder.Build();

    public static DispatcherQueue Dispatcher { get; set; } = DispatcherQueue.GetForCurrentThread();
    public static Window MainWindow { get; } = new MainWindow();

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App() {
      InitializeComponent();

      UnhandledException += App_UnhandledException;
    }

    public static T GetService<T>() where T : class {
      if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service) {
        throw new ArgumentException($"{typeof(T)} needs to be registered in {typeof(MyHostBuilder).Name}!");
      }

      return service;
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
      throw new NotImplementedException();
    }
    #endregion CALLBACKS
  }
}

using System;
using System.Runtime.ExceptionServices;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Data;
using SW.MB.Domain;
using SW.MB.UI.WPF.Services;
using SW.MB.UI.WPF.ViewModels;
using SW.MB.UI.WPF.Views.Windows;

namespace SW.MB.UI.WPF {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App: Application {
    private ServiceProvider _ServiceProvider;

    public App() {
      AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
      AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

      ServiceCollection services = new();
      ConfigureServices(services);
      _ServiceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);

      MainWindow = _ServiceProvider.GetRequiredService<AppWindow>();
      MainWindow.DataContext = _ServiceProvider.GetRequiredService<AppViewModel>();
      MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e) {
      base.OnExit(e);
    }

    private void ConfigureServices(ServiceCollection services) {
      DataFactory.Instance.ConfigureServices(services);
      DomainFactory.Instance.ConfigureServices(services);

      services.AddSingleton<AppViewModel>();
      services.AddSingleton<AppWindow>();
    }

    #region CALLBACKS
    private void CurrentDomain_FirstChanceException(object? sender, FirstChanceExceptionEventArgs e) {
      // TODO Logging...
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      // TODO Logging...
      DialogService.ShowUnhandledExceptionDialog(e.IsTerminating);
    }
    #endregion CALLBACKS
  }
}

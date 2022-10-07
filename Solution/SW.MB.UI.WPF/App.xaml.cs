using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
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

      SplashWindow splash = new();
      splash.Show();

      Task.Factory.StartNew(() => {
        LoadApplication(status => Dispatcher.Invoke(() => splash.Update(status)));
        Dispatcher.Invoke(() => {
          StartMainApplication();
          splash.Close();
        });
      });
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

    private void LoadApplication(Action<string> printStatus) {
      for (int n = 0; n <= 100; n++) {
        printStatus($"Loading data {n:###} %...");
        Task.Delay(10).Wait();
      }
    }

    private void StartMainApplication() {
      MainWindow = _ServiceProvider.GetRequiredService<AppWindow>();
      MainWindow.DataContext = _ServiceProvider.GetRequiredService<AppViewModel>();
      MainWindow.Show();
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

using System;
using System.Windows;
using SW.MB.UI.WPF.Views.Windows;

namespace SW.MB.UI.WPF {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App: Application {
    public App() {
      AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
      AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    }

    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);

      MainWindow = new SplashWindow();
      MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e) {
      base.OnExit(e);
    }

    #region CALLBACKS
    private void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e) {
      throw new NotImplementedException();
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      throw new NotImplementedException();
    }
    #endregion CALLBACKS
  }
}

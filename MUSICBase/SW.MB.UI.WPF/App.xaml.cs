using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SW.MB.UI.WPF.Desktop.Views.Windows;
using SW.MB.UI.WPF.HostBuilder;

namespace SW.MB.UI.WPF {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App: Application {
    private static readonly IHost _Host = MyHostBuilder.Build();

    #region CONSTRUCTORS
    public App() {
      AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
      AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    }
    #endregion CONSTRUCTORS

    public static T? GetService<T>()
      => _Host.Services.GetService<T>();

    public static T GetRequiredService<T>() where T : notnull
      => _Host.Services.GetRequiredService<T>();

    protected override void OnStartup(StartupEventArgs e) {
      System.Diagnostics.Debug.WriteLine("OnStartup - START");
      base.OnStartup(e);

      MainWindow = _Host.Services.GetRequiredService<AppWindow>();
      MainWindow.Show();

      System.Diagnostics.Debug.WriteLine("OnStartup - END");
    }

    protected override void OnLoadCompleted(NavigationEventArgs e) {
      System.Diagnostics.Debug.WriteLine("OnLoadCompleted - START");
      base.OnLoadCompleted(e);
      System.Diagnostics.Debug.WriteLine("OnLoadCompleted - END");
    }

    protected override void OnExit(ExitEventArgs e) {
      System.Diagnostics.Debug.WriteLine("OnExit - START");
      base.OnExit(e);
      System.Diagnostics.Debug.WriteLine("OnExit - END");
    }

    #region CALLBACKS
    private void CurrentDomain_FirstChanceException(object? sender, FirstChanceExceptionEventArgs e) {
      System.Diagnostics.Debug.WriteLine($"{sender} -> {e}");
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      System.Diagnostics.Debug.WriteLine($"{sender} -> {e}");
    }
    #endregion CALLBACKS
  }
}

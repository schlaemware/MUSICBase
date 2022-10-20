using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SW.MB.UI.WPF.HostBuilder;
using SW.MB.UI.WPF.Services;
using SW.MB.UI.WPF.ViewModels;
using SW.MB.UI.WPF.Views.Windows;

namespace SW.MB.UI.WPF {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App: Application {
    private readonly IHost _Host;

    #region CONSTRUCTORS
    public App() {
      AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
      AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

      _Host = MyHostBuilder.Build();
    }
    #endregion CONSTRUCTORS

    #region PROTECTED METHODS
    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);

      CreateLogger();
      StartAppCenter();

      SplashWindow? splash = null;
      splash = new();
      splash?.Show();

      Task.Factory.StartNew(() => {
        Log.Logger.Information("Load application...");
        Analytics.TrackEvent("Application", new Dictionary<string, string> {
          { "Status", "Load" }
        });

        AppViewModel vm = LoadApplication(status => Dispatcher.Invoke(() => splash?.Update(status)));

        Log.Logger.Information("Start application...");
        Analytics.TrackEvent("Application", new Dictionary<string, string> {
          { "Status", "Start" }
        });

        Dispatcher.Invoke(() => {
          StartMainApplication(vm);
          splash?.Close();
        });
      });
    }

    protected override void OnExit(ExitEventArgs e) {
      Log.Logger.Information("Exit application...");
      Analytics.TrackEvent("Application", new Dictionary<string, string> {
        { "Status", "Exit" }
      });

      base.OnExit(e);
    }
    #endregion PROTECTED METHODS

    private static void CreateLogger() {
      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Debug(Serilog.Events.LogEventLevel.Debug)
        .WriteTo.File("logs/mb.log", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
        .CreateLogger();

      Log.Logger.Debug("Logger started...");
    }

    private void StartAppCenter() {
      if (_Host.Services.GetService<IConfiguration>() is IConfiguration configuration) {
        string appSecretString = configuration.GetValue<string>("AppCenter:AppSecret");

        if (Guid.TryParse(appSecretString, out Guid appSecret)) {
          AppCenter.SetCountryCode(RegionInfo.CurrentRegion.TwoLetterISORegionName);
          AppCenter.Start(appSecret.ToString(), typeof(Analytics), typeof(Crashes));
        }
      }
    }

    private AppViewModel LoadApplication(Action<string> printStatus) {
      Log.Logger.Debug($"Start {nameof(LoadApplication)}");
      printStatus($"Loading data  10 %...");
      AppViewModel vm = _Host.Services.GetRequiredService<AppViewModel>();
      printStatus($"Loading data  90 %...");
      Log.Logger.Debug($"End {nameof(LoadApplication)}");

      return vm;
    }

    private void StartMainApplication(AppViewModel vm) {
      Log.Logger.Debug($"Start {nameof(StartMainApplication)}");
      MainWindow = _Host.Services.GetRequiredService<AppWindow>();
      MainWindow.DataContext = vm;
      MainWindow.Show();
      Log.Logger.Debug($"End {nameof(StartMainApplication)}");
    }

    #region CALLBACKS
    private void CurrentDomain_FirstChanceException(object? sender, FirstChanceExceptionEventArgs e) {
      Log.Logger.Error(e.Exception, $"FirstChangeException from {sender}");
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      Log.Logger.Fatal(e.ExceptionObject as Exception, $"UnhandledException from {sender}");
      DialogService.ShowUnhandledExceptionDialog(e.IsTerminating);
    }
    #endregion CALLBACKS
  }
}

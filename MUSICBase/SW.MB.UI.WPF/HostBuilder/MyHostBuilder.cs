using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SW.MB.BL.Contracts.Services;
using SW.MB.BL.Services;
using SW.MB.DA.Backuped;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;
using SW.MB.DA.MySql;
using SW.MB.DA.Sqlite;
using SW.MB.UI.WPF.Desktop.ViewModels;
using SW.MB.UI.WPF.Desktop.Views.Windows;

namespace SW.MB.UI.WPF.HostBuilder {
  public static class MyHostBuilder {
    public static IHost Build() => Host.CreateDefaultBuilder()
      .ConfigureMyAppConfiguration()
      .ConfigureMyServices()
      .Build();

    private static IHostBuilder ConfigureMyAppConfiguration(this IHostBuilder builder) => builder.ConfigureAppConfiguration((context, configuration) => {
      //configuration.Sources.Clear();

      //IHostEnvironment env = context.HostingEnvironment;

      //configuration
      //  .AddJsonFile("appsettings.json", true, true)
      //  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

      configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
    });

    private static IHostBuilder ConfigureMyServices(this IHostBuilder builder) => builder.ConfigureServices((context, services) => {
      // DATA ACCESS LAYER
      /// DbContexts
      services.AddDbContext<IRemoteStorage, MySQLDbContext>();
      services.AddDbContext<ILocalStorage, SQLiteDbContext>();

      /// Storage
      services.AddSingleton<IStorage, BackupedStorage>();

      /// Repositories
      services.AddSingleton<ICompositionsRepository>(s => s.GetRequiredService<IStorage>());
      services.AddSingleton<IMusiciansRepository>(s => s.GetRequiredService<IStorage>());

      // BUSINESS LOGIC LAYER
      /// Services
      services.AddTransient<ICompositionsDataService, DefaultCompositionsDataService>();
      services.AddTransient<IMusiciansDataService, DefaultMusiciansDataService>();

      // PRESENTATION LAYER
      // ViewModels
      services.AddSingleton<AppViewModel>();

      // Views
      services.AddSingleton(s => new AppWindow() { DataContext = s.GetRequiredService<AppViewModel>() });
    });
  }
}

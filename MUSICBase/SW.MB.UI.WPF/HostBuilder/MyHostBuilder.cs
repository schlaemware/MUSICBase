using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SW.MB.BL.Contracts.Services;
using SW.MB.BL.Services;
using SW.MB.DA.Contracts.Repositories;
using SW.MB.DA.Contracts.Storages;
using SW.MB.DA.MySql;
using SW.MB.DA.Sqlite;
using SW.MB.UI.WPF.Compositions.Commands;
using SW.MB.UI.WPF.Compositions.ViewModels;
using SW.MB.UI.WPF.Core.Contracts.Commands;
using SW.MB.UI.WPF.Dashboard.Commands;
using SW.MB.UI.WPF.Dashboard.ViewModels;
using SW.MB.UI.WPF.Desktop.Commands;
using SW.MB.UI.WPF.Desktop.Contracts.Stores;
using SW.MB.UI.WPF.Desktop.Stores;
using SW.MB.UI.WPF.Desktop.ViewModels;
using SW.MB.UI.WPF.Desktop.Views.Windows;
using SW.MB.UI.WPF.Members.Commands;
using SW.MB.UI.WPF.Members.ViewModels;
using SW.MB.UI.WPF.Musicians.Commands;
using SW.MB.UI.WPF.Musicians.ViewModels;

namespace SW.MB.UI.WPF.HostBuilder {
  public static class MyHostBuilder {
    public static IHost Build() => Host.CreateDefaultBuilder()
      .ConfigureMyAppConfiguration()
      .ConfigureMyServices()
      .Build();

    private static IHostBuilder ConfigureMyAppConfiguration(this IHostBuilder builder) => builder.ConfigureAppConfiguration((context, configuration) => {
      configuration.AddInMemoryCollection(new Dictionary<string, string>() {
        { typeof(Version).FullName ?? "Version", (Assembly.GetExecutingAssembly().GetName().Version ?? new Version()).ToString() }
      });

      configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true, true);
    });

    private static IHostBuilder ConfigureMyServices(this IHostBuilder builder) => builder.ConfigureServices((context, services) => {
      // DATA ACCESS LAYER
      /// DbContexts
      services.AddDbContext<IRemoteStorage, MySQLDbContext>();
      services.AddDbContext<ILocalStorage, SQLiteDbContext>();

      /// Storage
#if LOCAL
      services.AddSingleton<IStorage>(s => s.GetRequiredService<ILocalStorage>());
#else
      services.AddSingleton<IStorage, BackupedStorage>();
#endif

      /// Repositories
      services.AddSingleton<ICompositionsRepository>(s => s.GetRequiredService<IStorage>());
      services.AddSingleton<IMusiciansRepository>(s => s.GetRequiredService<IStorage>());

      // BUSINESS LOGIC LAYER
      /// Services
      services.AddTransient<ICompositionsDataService, DefaultCompositionsDataService>();
      services.AddTransient<IMusiciansDataService, DefaultMusiciansDataService>();

      // PRESENTATION LAYER
      /// Stores
      services.AddSingleton<IModulesNavigationStore, ModulesNavigationStore>();

      /// Commands
      services.AddScoped<INavigateCompositionsCommand>(s => CreateNavigateCompositionsCommand(s));
      services.AddScoped<INavigateDashboardCommand>(s => CreateNavigateDashboardCommand(s));
      services.AddScoped<INavigateMembersCommand>(s => CreateNavigateMembersCommand(s));
      services.AddScoped<INavigateMusiciansCommand>(s => CreateNavigateMusiciansCommand(s));
      services.AddScoped<INavigateSettingsCommand>(s => CreateNavigateSettingsCommand(s));
      services.AddScoped<INavigateUpdatesCommand>(s => CreateNavigateUpdatesCommand(s));

      // ViewModels
      services.AddSingleton<CompositionsViewModel>();
      services.AddSingleton<DashboardViewModel>();
      services.AddSingleton<MembersViewModel>();
      services.AddSingleton<MusiciansViewModel>();
      services.AddSingleton<SettingsViewModel>();
      services.AddSingleton<UpdatesViewModel>();
      services.AddSingleton<AppViewModel>();

      // Views
      services.AddSingleton<Window>(s => new AppWindow() { DataContext = s.GetService<AppViewModel>() });
    });

    #region FACTORY METHODS
    private static NavigateCompositionsCommand CreateNavigateCompositionsCommand(IServiceProvider s) => new(
      s.GetRequiredService<IModulesNavigationStore>(),
      () => s.GetRequiredService<CompositionsViewModel>());

    private static NavigateDashboardCommand CreateNavigateDashboardCommand(IServiceProvider s) => new(
      s.GetRequiredService<IModulesNavigationStore>(),
      () => s.GetRequiredService<DashboardViewModel>());

    private static NavigateMembersCommand CreateNavigateMembersCommand(IServiceProvider s) => new(
      s.GetRequiredService<IModulesNavigationStore>(),
      () => s.GetRequiredService<MembersViewModel>());

    private static NavigateMusiciansCommand CreateNavigateMusiciansCommand(IServiceProvider s) => new(
      s.GetRequiredService<IModulesNavigationStore>(),
      () => s.GetRequiredService<MusiciansViewModel>());

    //private static NavigateCompositionsDetailCommand CreateNavigateCompositionsDetailCommand(IServiceProvider s) => new(
    //  s.GetRequiredService<ICompositionsNavigationStore>(),
    //  id => new CompositionsDetailViewModel(id, s.GetRequiredService<ICompositionsService>(), s.GetRequiredService<INavigateCompositionsOverviewCommand>()));

    //private static NavigateCompositionsOverviewCommand CreateNavigateCompositionsOverviewCommand(IServiceProvider s) => new(
    //  s.GetRequiredService<ICompositionsNavigationStore>(),
    //  () => s.GetRequiredService<CompositionsOverviewViewModel>());

    //private static NavigateMembersDetailCommand CreateNavigateMembersDetailCommand(IServiceProvider s) => new(
    //  s.GetRequiredService<IMembersNavigationStore>(),
    //  id => new MembersDetailViewModel(id, s.GetRequiredService<IMembersService>(), s.GetRequiredService<INavigateMembersOverviewCommand>()));

    //private static NavigateMembersOverviewCommand CreateNavigateMembersOverviewCommand(IServiceProvider s) => new(
    //  s.GetRequiredService<IMembersNavigationStore>(),
    //  () => s.GetRequiredService<MembersOverviewViewModel>());

    //private static NavigateMusiciansDetailCommand CreateNavigateMusiciansDetailCommand(IServiceProvider s) => new(
    //  s.GetRequiredService<IMusiciansNavigationStore>(),
    //  id => new MusiciansDetailViewModel(id, s.GetRequiredService<IMusiciansService>(), s.GetRequiredService<INavigateMusiciansOverviewCommand>()));

    //private static NavigateMusiciansOverviewCommand CreateNavigateMusiciansOverviewCommand(IServiceProvider s) => new(
    //  s.GetRequiredService<IMusiciansNavigationStore>(),
    //  () => s.GetRequiredService<MusiciansOverviewViewModel>());

    private static NavigateSettingsCommand CreateNavigateSettingsCommand(IServiceProvider s) => new(
        s.GetRequiredService<IModulesNavigationStore>(),
        () => s.GetRequiredService<SettingsViewModel>());

    private static NavigateUpdatesCommand CreateNavigateUpdatesCommand(IServiceProvider s) => new(
        s.GetRequiredService<IModulesNavigationStore>(),
        () => s.GetRequiredService<UpdatesViewModel>());
    #endregion FACTORY METHODS
  }
}

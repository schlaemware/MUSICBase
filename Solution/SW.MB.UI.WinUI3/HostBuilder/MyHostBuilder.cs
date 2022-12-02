using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using SW.MB.Data;
using SW.MB.Domain;
using SW.MB.UI.WinUI3.Activation;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Services;
using SW.MB.UI.WinUI3.ViewModels;
using SW.MB.UI.WinUI3.Views.Pages;

namespace SW.MB.UI.WinUI3.HostBuilder {
  internal static class MyHostBuilder {
    public static IHost Build() => Host.CreateDefaultBuilder().UseContentRoot(AppContext.BaseDirectory)
      .ConfigureMyServices()
      .Build();

    private static IHostBuilder ConfigureMyServices(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices((context, services) => {
      DataFactory.Instance.ConfigureServices(services, context.Configuration);
      DomainFactory.Instance.ConfigureServices(services, context.Configuration);

      // Activation handlers
      /// Default
      services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

      /// Others
      

      // Services
      /// Transient
      services.AddTransient<INavigationViewService, NavigationViewService>();

      /// Singleton
      services.AddSingleton<IActivationService, ActivationService>();
      services.AddSingleton<IDisplaySettingsService, DisplaySettingsService>();
      services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
      services.AddSingleton<INavigationService, NavigationService>();
      services.AddSingleton<IPageService, PageService>();
      services.AddSingleton<IPermissionsService, PermissionsService>();
      services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();

      // Views and ViewModels
      services.AddSingleton<CompositionsPage>();
      services.AddSingleton<CompositionsViewModel>();
      services.AddSingleton<HomePage>();
      services.AddSingleton<HomeViewModel>();
      services.AddSingleton<LoginPage>();
      services.AddSingleton<LoginViewModel>();
      services.AddSingleton<MandatorsPage>();
      services.AddSingleton<MandatorsViewModel>();
      services.AddSingleton<MembersPage>();
      services.AddSingleton<MembersViewModel>();
      services.AddSingleton<MusiciansPage>();
      services.AddSingleton<MusiciansViewModel>();
      services.AddSingleton<ProgramsPage>();
      services.AddSingleton<ProgramsViewModel>();
      services.AddSingleton<SettingsPage>();
      services.AddSingleton<SettingsViewModel>();
      services.AddSingleton<ShellPage>();
      services.AddSingleton<ShellViewModel>();
      services.AddSingleton<UpdatesPage>();
      services.AddSingleton<UpdatesViewModel>();
      services.AddSingleton<UsersPage>();
      services.AddSingleton<UsersViewModel>();
    });
  }
}

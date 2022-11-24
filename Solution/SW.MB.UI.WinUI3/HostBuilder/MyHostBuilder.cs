using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using SW.MB.UI.WinUI3.Activation;
using SW.MB.UI.WinUI3.Contracts.Services;
using SW.MB.UI.WinUI3.Services;
using SW.MB.UI.WinUI3.ViewModels;
using SW.MB.UI.WinUI3.Views.Pages;
using SW.MB.UI.WinUI3.Views.Windows;

namespace SW.MB.UI.WinUI3.HostBuilder {
  internal static class MyHostBuilder {
    public static IHost Build() => Host.CreateDefaultBuilder().UseContentRoot(AppContext.BaseDirectory)
      .ConfigureMyServices()
      .Build();

    private static IHostBuilder ConfigureMyServices(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices((context, services) => {
      // Activation handlers
      /// Default
      services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

      /// Others
      

      // Services
      /// Transient
      services.AddTransient<INavigationViewService, NavigationViewService>();

      /// Singleton
      services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
      services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
      services.AddSingleton<IActivationService, ActivationService>();
      services.AddSingleton<IPageService, PageService>();
      services.AddSingleton<INavigationService, NavigationService>();

      // Views and ViewModels
      services.AddTransient<CompositionsPage>();
      services.AddTransient<CompositionsViewModel>();
      services.AddTransient<HomePage>();
      services.AddTransient<HomeViewModel>();
      services.AddTransient<MandantsPage>();
      services.AddTransient<MandantsViewModel>();
      services.AddTransient<MembersPage>();
      services.AddTransient<MembersViewModel>();
      services.AddTransient<MusiciansPage>();
      services.AddTransient<MusiciansViewModel>();
      services.AddTransient<ProgramsPage>();
      services.AddTransient<ProgramsViewModel>();
      services.AddTransient<SettingsPage>();
      services.AddTransient<SettingsViewModel>();
      services.AddTransient<ShellPage>();
      services.AddTransient<ShellViewModel>();
      services.AddTransient<UpdatesPage>();
      services.AddTransient<UpdatesViewModel>();
      services.AddTransient<UsersPage>();
      services.AddTransient<UsersViewModel>();
    });
  }
}

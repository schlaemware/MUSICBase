using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SW.MB.Data;
using SW.MB.Domain;
using SW.MB.UI.WPF.ViewModels;
using SW.MB.UI.WPF.Views.Windows;

namespace SW.MB.UI.WPF.HostBuilder {
  internal static class MyHostBuilder {
    public static IHost Build() => Host.CreateDefaultBuilder()
      .ConfigureMyUserSecrets()
      .ConfigureMyServices()
      .Build();

    private static IHostBuilder ConfigureMyUserSecrets(this IHostBuilder hostBuilder) => hostBuilder.ConfigureAppConfiguration((context, configuration) => {
      configuration.AddUserSecrets<AppViewModel>(true, true);
    });

    private static IHostBuilder ConfigureMyServices(this IHostBuilder hostBuilder) => hostBuilder.ConfigureServices((context, services) => {
      DataFactory.Instance.ConfigureServices(services, context.Configuration);
      DomainFactory.Instance.ConfigureServices(services, context.Configuration);

      // ViewModels
      services.AddTransient<AppViewModel>();
      services.AddTransient<CompositionsViewModel>();
      services.AddTransient<DashboardViewModel>();
      services.AddTransient<MandatorsViewModel>();
      services.AddTransient<MembersViewModel>();
      services.AddTransient<MusiciansViewModel>();
      services.AddTransient<SettingsViewModel>();
      services.AddTransient<UpdatesViewModel>();
      services.AddTransient<UsersViewModel>();

      services.AddTransient<AppWindow>();
    });
  }
}

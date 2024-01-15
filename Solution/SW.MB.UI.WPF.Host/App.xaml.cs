using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.Application.Contracts.Records;
using SW.MB.Application.Contracts.Services;
using SW.MB.Application.WPF;
using SW.MB.Application.WPF.Services;
using SW.MB.Domain.Entities;
using SW.MB.Domain.Repositories;
using SW.MB.Domain.Shared;
using SW.MB.EFCore.EFCore;
using SW.MB.EFCore.Repositories;
using SW.MB.UI.WPF.Commands;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Models;
using SW.MB.UI.WPF.Stores;
using SW.MB.UI.WPF.ViewModels;
using SW.MB.UI.WPF.Views.Windows;

namespace SW.MB.UI.WPF.Host {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application {
        private readonly IServiceProvider _ServiceProvider = BuildServiceProvider();

        #region CONSTRUCTORS
        public App() {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            Models.App.RegisterServiceProvider(_ServiceProvider);
        }
        #endregion CONSTRUCTORS

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            MainWindow = _ServiceProvider.GetRequiredService<AppWindow>();
            MainWindow.Show();
        }

        private static IConfigurationRoot BuildConfiguration() {
            ConfigurationBuilder configBuilder = new();
            configBuilder.AddJsonFile("appsettings.json", false);
            configBuilder.AddJsonFile("appsettings.Development.json", true);
            configBuilder.AddJsonFile("appsettings.Production.json", true);
            configBuilder.AddInMemoryCollection(new Dictionary<string, string?> {
                // TODO
            });
            configBuilder.AddUserSecrets<App>();

            return configBuilder.Build();
        }

        private static ServiceProvider BuildServiceProvider() {
            ServiceCollection services = new();

            // Configuration
            IConfigurationRoot config = BuildConfiguration();
            services.AddSingleton(new MUSICBaseConfiguration {
                ApplicationDirectory = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MUSICBase")),
                MySQLConnectionString = config.GetConnectionString("MySQL")
            });

            // DbContext
            services.AddDbContext<MUSICBaseDbContext>(o => o.EnableSensitiveDataLogging());

            // Repositories
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            // Application.WPF
            services.AddAutoMapper(typeof(AppMapperProfile));
            services.AddTransient(typeof(IDataService<CompositionRecord, int>), typeof(DataService<CompositionRecord, Composition, int>));
            services.AddTransient(typeof(IDataService<MemberRecord, int>), typeof(DataService<MemberRecord, Member, int>));
            services.AddTransient(typeof(IDataService<MusicianRecord, int>), typeof(DataService<MusicianRecord, Musician, int>));

            // UI
            services.AddAutoMapper(typeof(UIMapperProfile));
            services.AddTransient(typeof(INavigateCommand<>), typeof(NavigateCommand<>));
            services.AddSingleton<INavigationStore, NavigationStore>();

            // ViewModels
            services.AddSingleton<AppViewModel>();
            services.AddSingleton<CompositionsViewModel>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<MembersViewModel>();
            services.AddSingleton<MusiciansViewModel>();

            // Views
            services.AddSingleton<AppWindow>();

            return services.BuildServiceProvider();
        }

        private void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e) {
            System.Diagnostics.Debug.WriteLine($"");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            System.Diagnostics.Debug.WriteLine($"");
        }
    }
}

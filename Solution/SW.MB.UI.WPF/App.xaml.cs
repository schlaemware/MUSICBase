using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SW.MB.UI.WPF.Commands;
using SW.MB.UI.WPF.Interfaces;
using SW.MB.UI.WPF.Stores;
using SW.MB.UI.WPF.ViewModels;
using SW.MB.UI.WPF.Views.Windows;

namespace SW.MB.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;

        public IServiceProvider ServiceProvider { get; } = BuildServiceProvider();

        public App() : base()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = ServiceProvider.GetRequiredService<AppWindow>();
            MainWindow.Show();
        }

        private static ServiceProvider BuildServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(INavigateCommand<>), typeof(NavigateCommand<>));
            services.AddSingleton<INavigationStore, NavigationStore>();

            services.AddSingleton<AppViewModel>();
            services.AddSingleton<CompositionsViewModel>();
            services.AddSingleton<DashboardViewModel>();

            services.AddTransient<AppWindow>();

            return services.BuildServiceProvider();
        }

        #region CALLBACKS
        private void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"FIRST CHANCE EXCEPTION: {e.Exception}");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"UNHANDLED EXCEPTION: {e.ExceptionObject}");
        }
        #endregion CALLBACKS
    }
}
